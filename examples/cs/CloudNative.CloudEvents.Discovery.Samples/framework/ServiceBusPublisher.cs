using Azure.Messaging.ServiceBus;
using CloudNative.CloudEvents;
using CloudNative.CloudEvents.Discovery.Samples;

namespace Azure.Messaging.ServiceBus
{
    public class ServiceBusPublisher : ICloudEventPublisher
    {
        private readonly ServiceBusSender sender;

        public ServiceBusPublisher(ServiceBusSender sender)
        {
            this.sender = sender;
        }
        public Task SendAsync(CloudNative.CloudEvents.CloudEvent cloudEvent, ContentMode contentMode, CloudEventFormatter formatter)
        {
            return sender.SendMessageAsync(cloudEvent.ToServiceBusMessage(contentMode, formatter));
        }

        public Task SendAsync<T>(TypedCloudEventBase<T> cloudEvent, ContentMode contentMode, CloudEventFormatter formatter) where T : ISchemaSerializable, new()
        {
            return this.SendAsync(cloudEvent.ToCloudEvent(contentMode, formatter), contentMode, formatter);
        }
    }
}