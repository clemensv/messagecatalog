using CloudNative.CloudEvents;
using CloudNative.CloudEvents.Discovery.Samples;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mime;

namespace Microsoft.Storage
{

    public partial class StorageBlobDeletedEventData : JsonSchemaSerializable
    {
        public StorageBlobDeletedEventData() : base(
            new Uri("https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/eventgrid/data-plane/Microsoft.Storage/stable/2018-01-01/Storage.json#/definitions/StorageBlobDeletedEventData"),
            new ContentType(MediaTypeNames.Application.Json))
        {

        }
    }

    public class BlobDeletedEvent : TypedCloudEventBase<StorageBlobDeletedEventData>
    {
        public const string CloudEventType = "Microsoft.Storage.BlobDeleted";
        public BlobDeletedEvent(Uri source, string subject, StorageBlobDeletedEventData data) : base(CloudEventType, source, data)
        {
            this.Subject = subject;
        }

        public BlobDeletedEvent(CloudEvent receivedCloudEvent) : base(CloudEventType, receivedCloudEvent)
        {

        }
    }



}

