using CloudNative.CloudEvents;


namespace CloudNative.CloudEvents
{
    public interface ICloudEventPublisher
    {
        Task SendAsync(CloudEvent cloudEvent, ContentMode contentMode, CloudEventFormatter formatter);
    }
}