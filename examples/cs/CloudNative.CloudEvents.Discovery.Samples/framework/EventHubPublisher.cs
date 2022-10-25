using Azure.Messaging.EventHubs.Producer;
using CloudNative.CloudEvents;
using CloudNative.CloudEvents.Discovery.Samples;

namespace Azure.Messaging.EventHubs
{
    public class EventHubPublisher : ICloudEventPublisher
    {
        private readonly EventHubProducerClient sender;

        public EventHubPublisher(EventHubProducerClient sender)
        {
            this.sender = sender;
            
        }
        public Task SendAsync(CloudNative.CloudEvents.CloudEvent cloudEvent, ContentMode contentMode, CloudEventFormatter formatter)
        {
            return sender.SendAsync(new[] { cloudEvent.ToEventData(contentMode, formatter) });
        }

        public Task SendAsync<T>(TypedCloudEventBase<T> cloudEvent, ContentMode contentMode, CloudEventFormatter formatter) where T : ISchemaSerializable, new()
        {
            return this.SendAsync(cloudEvent.ToCloudEvent(contentMode, formatter), contentMode, formatter);
        }
    }
}