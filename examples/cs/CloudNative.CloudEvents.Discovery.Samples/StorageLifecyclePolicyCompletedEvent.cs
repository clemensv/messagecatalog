using CloudNative.CloudEvents;
using CloudNative.CloudEvents.Discovery.Samples;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mime;

namespace Microsoft.Storage
{

    public partial class StorageStorageLifecyclePolicyCompletedEventData : JsonSchemaSerializable
    {
        public StorageStorageLifecyclePolicyCompletedEventData() : base(
            new Uri("https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/eventgrid/data-plane/Microsoft.Storage/stable/2018-01-01/Storage.json#/definitions/StorageStorageLifecyclePolicyCompletedEventData"),
            new ContentType(MediaTypeNames.Application.Json))
        {

        }
    }

    public class StorageLifecyclePolicyCompletedEvent : TypedCloudEventBase<StorageStorageLifecyclePolicyCompletedEventData>
    {
        public const string CloudEventType = "Microsoft.Storage.StorageLifecyclePolicyCompleted";
        public StorageLifecyclePolicyCompletedEvent(Uri source, string subject, StorageStorageLifecyclePolicyCompletedEventData data) : base(CloudEventType, source, data)
        {
            this.Subject = subject;
        }

        public StorageLifecyclePolicyCompletedEvent(CloudEvent receivedCloudEvent) : base(CloudEventType, receivedCloudEvent)
        {

        }
    }



}

