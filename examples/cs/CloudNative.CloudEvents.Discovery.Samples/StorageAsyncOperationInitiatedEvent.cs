using CloudNative.CloudEvents;
using CloudNative.CloudEvents.Discovery.Samples;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mime;

namespace Microsoft.Storage
{

    public partial class StorageStorageAsyncOperationInitiatedEventData : JsonSchemaSerializable
    {
        public StorageStorageAsyncOperationInitiatedEventData() : base(
            new Uri("https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/eventgrid/data-plane/Microsoft.Storage/stable/2018-01-01/Storage.json#/definitions/StorageStorageAsyncOperationInitiatedEventData"),
            new ContentType(MediaTypeNames.Application.Json))
        {

        }
    }

    public class StorageAsyncOperationInitiatedEvent : TypedCloudEventBase<StorageStorageAsyncOperationInitiatedEventData>
    {
        public const string CloudEventType = "Microsoft.Storage.StorageAsyncOperationInitiated";
        public StorageAsyncOperationInitiatedEvent(Uri source, string subject, StorageStorageAsyncOperationInitiatedEventData data) : base(CloudEventType, source, data)
        {
            this.Subject = subject;
        }

        public StorageAsyncOperationInitiatedEvent(CloudEvent receivedCloudEvent) : base(CloudEventType, receivedCloudEvent)
        {

        }
    }



}

