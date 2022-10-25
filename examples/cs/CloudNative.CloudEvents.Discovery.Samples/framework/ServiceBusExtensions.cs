// Copyright (c) Cloud Native Foundation.
// Licensed under the Apache 2.0 license.
// See LICENSE file in the project root for full license information.


using CloudNative.CloudEvents;
using CloudNative.CloudEvents.Core;
using CloudNative.CloudEvents.NewtonsoftJson;
using CloudNative.CloudEvents.Avro;
using System.Net.Mime;
using AvroEventFormatter = CloudNative.CloudEvents.Avro.AvroEventFormatter;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Extension methods to convert between CloudEvents and AMQP messages.
    /// </summary>
    public static class ServiceBusExtensions
    {
        static JsonEventFormatter jsonFormatter = new JsonEventFormatter();
        static AvroEventFormatter avroFormatter = new AvroEventFormatter();

        // This is internal in CloudEventsSpecVersion.
        private const string SpecVersionAttributeName = "specversion";

        internal const string AmqpHeaderUnderscorePrefix = "cloudEvents_";
        internal const string AmqpHeaderColonPrefix = "cloudEvents:";

        internal const string SpecVersionAmqpHeaderWithUnderscore = AmqpHeaderUnderscorePrefix + SpecVersionAttributeName;
        internal const string SpecVersionAmqpHeaderWithColon = AmqpHeaderColonPrefix + SpecVersionAttributeName;

        /// <summary>
        /// Indicates whether this <see cref="ServiceBusMessage"/> holds a single CloudEvent.
        /// </summary>
        /// <remarks>
        /// This method returns false for batch requests, as they need to be parsed differently.
        /// </remarks>
        /// <param name="message">The message to check for the presence of a CloudEvent. Must not be null.</param>
        /// <returns>true, if the request is a CloudEvent</returns>
        public static bool IsCloudEvent(this ServiceBusReceivedMessage message) =>
            HasCloudEventsContentType(Validation.CheckNotNull(message, nameof(message)), out _) ||
            message.ApplicationProperties.ContainsKey(SpecVersionAmqpHeaderWithUnderscore) ||
            message.ApplicationProperties.ContainsKey(SpecVersionAmqpHeaderWithColon);


        /// <summary>
        /// Converts this AMQP message into a CloudEvent object.
        /// </summary>
        /// <param name="message">The AMQP message to convert. Must not be null.</param>
        /// <param name="formatter">The event formatter to use to parse the CloudEvent. Must not be null.</param>
        /// <param name="extensionAttributes">The extension attributes to use when parsing the CloudEvent. May be null.</param>
        /// <returns>A reference to a validated CloudEvent instance.</returns>
        public static CloudNative.CloudEvents.CloudEvent ToCloudEvent(
            this ServiceBusReceivedMessage message,
            params CloudEventAttribute[]? extensionAttributes)
        {
            if (MimeUtilities.IsCloudEventsContentType(message.ContentType))
            {
                if (message.ContentType.Contains("+json"))
                {
                    return ToCloudEvent(message, jsonFormatter, (IEnumerable<CloudEventAttribute>?)extensionAttributes);
                }
                else if (message.ContentType.Contains("+avro"))
                {
                    return ToCloudEvent(message, avroFormatter, (IEnumerable<CloudEventAttribute>?)extensionAttributes);
                }
                else
                {
                    throw new InvalidOperationException($"Unsupported format {message.ContentType}");
                }
            }
            else
            { 
                return ToCloudEvent(message, jsonFormatter, (IEnumerable<CloudEventAttribute>?)extensionAttributes);
            }
        }

        /// <summary>
        /// Converts this AMQP message into a CloudEvent object.
        /// </summary>
        /// <param name="message">The AMQP message to convert. Must not be null.</param>
        /// <param name="formatter">The event formatter to use to parse the CloudEvent. Must not be null.</param>
        /// <param name="extensionAttributes">The extension attributes to use when parsing the CloudEvent. May be null.</param>
        /// <returns>A reference to a validated CloudEvent instance.</returns>
        public static CloudNative.CloudEvents.CloudEvent ToCloudEvent(
            this ServiceBusReceivedMessage message,
            CloudEventFormatter formatter,
            params CloudEventAttribute[]? extensionAttributes) =>
            ToCloudEvent(message, formatter, (IEnumerable<CloudEventAttribute>?)extensionAttributes);

        /// <summary>
        /// Converts this AMQP message into a CloudEvent object.
        /// </summary>
        /// <param name="message">The AMQP message to convert. Must not be null.</param>
        /// <param name="formatter">The event formatter to use to parse the CloudEvent. Must not be null.</param>
        /// <param name="extensionAttributes">The extension attributes to use when parsing the CloudEvent. May be null.</param>
        /// <returns>A reference to a validated CloudEvent instance.</returns>
        public static CloudNative.CloudEvents.CloudEvent ToCloudEvent(
            this ServiceBusReceivedMessage message,
            CloudEventFormatter formatter,
            IEnumerable<CloudEventAttribute>? extensionAttributes)
        {
            Validation.CheckNotNull(message, nameof(message));
            Validation.CheckNotNull(formatter, nameof(formatter));

            if (HasCloudEventsContentType(message, out var contentType))
            {
                return formatter.DecodeStructuredModeMessage(message.Body.ToStream(), new ContentType(contentType), extensionAttributes);
            }
            else
            {
                var propertyMap = message.ApplicationProperties;
                if (!propertyMap.TryGetValue(SpecVersionAmqpHeaderWithUnderscore, out var versionId) &&
                    !propertyMap.TryGetValue(SpecVersionAmqpHeaderWithColon, out versionId))
                {
                    throw new ArgumentException("Request is not a CloudEvent");
                }

                var version = CloudEventsSpecVersion.FromVersionId(versionId as string)
                    ?? throw new ArgumentException($"Unknown CloudEvents spec version '{versionId}'", nameof(message));

                var cloudEvent = new CloudNative.CloudEvents.CloudEvent(version, extensionAttributes)
                {
                    DataContentType = message.ContentType
                };

                foreach (var property in propertyMap)
                {
                    if (!(property.Key is string key &&
                        (key.StartsWith(AmqpHeaderColonPrefix) || key.StartsWith(AmqpHeaderUnderscorePrefix))))
                    {
                        continue;
                    }
                    // Note: both prefixes have the same length. If we ever need any prefixes with a different length, we'll need to know which
                    // prefix we're looking at.
                    string attributeName = key.Substring(AmqpHeaderUnderscorePrefix.Length).ToLowerInvariant();

                    // We've already dealt with the spec version.
                    if (attributeName == CloudEventsSpecVersion.SpecVersionAttribute.Name)
                    {
                        continue;
                    }

                    // Timestamps are serialized via DateTime instead of DateTimeOffset.
                    if (property.Value is DateTime dt)
                    {
                        if (dt.Kind != DateTimeKind.Utc)
                        {
                            // This should only happen for MinValue and MaxValue...
                            // just respecify as UTC. (We could add validation that it really
                            // *is* MinValue or MaxValue if we wanted to.)
                            dt = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
                        }
                        cloudEvent[attributeName] = (DateTimeOffset)dt;
                    }
                    // URIs are serialized as strings, but we need to convert them back to URIs.
                    // It's simplest to let CloudEvent do this for us.
                    else if (property.Value is string text)
                    {
                        cloudEvent.SetAttributeFromString(attributeName, text);
                    }
                    else
                    {
                        cloudEvent[attributeName] = property.Value;
                    }
                }
                // Populate the data after the rest of the CloudEvent
                if (message.GetRawAmqpMessage().Body.BodyType == Azure.Core.Amqp.AmqpMessageBodyType.Data)
                {
                    // Note: Fetching the Binary property will always retrieve the data. It will
                    // be copied from the Buffer property if necessary.
                    formatter.DecodeBinaryModeEventData(message.Body.ToArray(), cloudEvent);
                }
                else if (message.GetRawAmqpMessage().Body.BodyType == Azure.Core.Amqp.AmqpMessageBodyType.Value)
                {
                    throw new ArgumentException("Binary mode data in AMQP message must be in the application data section");
                }

                return Validation.CheckCloudEventArgument(cloudEvent, nameof(message));
            }
        }

        private static bool HasCloudEventsContentType(ServiceBusReceivedMessage message, out string? contentType)
        {
            contentType = message.ContentType?.ToString();
            return MimeUtilities.IsCloudEventsContentType(contentType);
        }

        /// <summary>
        /// Converts a CloudEvent to <see cref="ServiceBusMessage"/> using the default property prefix. Versions released prior to March 2023
        /// use a default property prefix of "cloudEvents:". Versions released from March 2023 onwards use a property prefix of "cloudEvents_".
        /// Code wishing to express the prefix explicitly should use <see cref="ToServiceBusMessageWithColonPrefix(CloudEvent, ContentMode, CloudEventFormatter)"/> or
        /// <see cref="ToServiceBusMessageWithUnderscorePrefix(CloudEvent, ContentMode, CloudEventFormatter)"/>.
        /// </summary>
        /// <param name="cloudEvent">The CloudEvent to convert. Must not be null, and must be a valid CloudEvent.</param>
        /// <param name="contentMode">Content mode. Structured or binary.</param>
        /// <param name="formatter">The formatter to use within the conversion. Must not be null.</param>
        public static ServiceBusMessage ToServiceBusMessage(this CloudNative.CloudEvents.CloudEvent cloudEvent, ContentMode contentMode, CloudEventFormatter formatter) =>
            ToServiceBusMessage(cloudEvent, contentMode, formatter, AmqpHeaderColonPrefix);

        /// <summary>
        /// Converts a CloudEvent to <see cref="ServiceBusMessage"/> using a property prefix of "cloudEvents_". This prefix was introduced as the preferred
        /// prefix for the AMQP binding in August 2022.
        /// </summary>
        /// <param name="cloudEvent">The CloudEvent to convert. Must not be null, and must be a valid CloudEvent.</param>
        /// <param name="contentMode">Content mode. Structured or binary.</param>
        /// <param name="formatter">The formatter to use within the conversion. Must not be null.</param>
        public static ServiceBusMessage ToServiceBusMessageWithUnderscorePrefix(this CloudNative.CloudEvents.CloudEvent cloudEvent, ContentMode contentMode, CloudEventFormatter formatter) =>
            ToServiceBusMessage(cloudEvent, contentMode, formatter, AmqpHeaderUnderscorePrefix);

        /// <summary>
        /// Converts a CloudEvent to <see cref="ServiceBusMessage"/> using a property prefix of "cloudEvents:". This prefix
        /// is a legacy retained only for compatibility purposes; it can't be used by JMS due to constraints in JMS property names.
        /// </summary>
        /// <param name="cloudEvent">The CloudEvent to convert. Must not be null, and must be a valid CloudEvent.</param>
        /// <param name="contentMode">Content mode. Structured or binary.</param>
        /// <param name="formatter">The formatter to use within the conversion. Must not be null.</param>
        public static ServiceBusMessage ToServiceBusMessageWithColonPrefix(this CloudNative.CloudEvents.CloudEvent cloudEvent, ContentMode contentMode, CloudEventFormatter formatter) =>
            ToServiceBusMessage(cloudEvent, contentMode, formatter, AmqpHeaderColonPrefix);

        private static ServiceBusMessage ToServiceBusMessage(CloudNative.CloudEvents.CloudEvent cloudEvent, ContentMode contentMode, CloudEventFormatter formatter, string prefix)
        {
            Validation.CheckCloudEventArgument(cloudEvent, nameof(cloudEvent));
            Validation.CheckNotNull(formatter, nameof(formatter));

            ServiceBusMessage message = new ServiceBusMessage();
            foreach (var item in MapHeaders(cloudEvent, prefix))
            {
                message.ApplicationProperties.Add(item);
            }            
            
            switch (contentMode)
            {
                case ContentMode.Structured:
                    message.Body =  new BinaryData(
                        BinaryDataUtilities.AsArray(formatter.EncodeStructuredModeMessage(cloudEvent, out var contentType))
                    );
                    message.ContentType = contentType.MediaType;
                    break;
                case ContentMode.Binary:
                    message.Body = new BinaryData(BinaryDataUtilities.AsArray(formatter.EncodeBinaryModeEventData(cloudEvent)));
                    message.ContentType = formatter.GetOrInferDataContentType(cloudEvent);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(contentMode), $"Unsupported content mode: {contentMode}");
            }
            return message;
        }

        private static IDictionary<string, object> MapHeaders(CloudNative.CloudEvents.CloudEvent cloudEvent, string prefix)
        {
            var applicationProperties = new Dictionary<string, object>();
            var properties = applicationProperties;
            properties.Add(prefix + SpecVersionAttributeName, cloudEvent.SpecVersion.VersionId);

            foreach (var pair in cloudEvent.GetPopulatedAttributes())
            {
                var attribute = pair.Key;

                // The content type is specified elsewhere.
                if (attribute == cloudEvent.SpecVersion.DataContentTypeAttribute)
                {
                    continue;
                }

                string propKey = prefix + attribute.Name;

                // TODO: Check that AMQP can handle byte[], bool and int values
                object propValue = pair.Value switch
                {
                    Uri uri => uri.ToString(),
                    // AMQPNetLite doesn't support DateTimeOffset values, so convert to UTC.
                    // That means we can't roundtrip events with non-UTC timestamps, but that's not awful.
                    DateTimeOffset dto => dto.UtcDateTime,
                    _ => pair.Value
                };
                properties.Add(propKey, propValue);
            }
            return applicationProperties;
        }
    }
}