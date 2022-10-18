using CloudNative.CloudEvents;
using CloudNative.CloudEvents.Discovery.Samples;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mime;

namespace Microsoft.Storage
{

    public partial class StorageBlobRenamedEventData : JsonSchemaSerializable
    {
        public StorageBlobRenamedEventData() : base(
            new Uri("https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/eventgrid/data-plane/Microsoft.Storage/stable/2018-01-01/Storage.json#/definitions/StorageBlobRenamedEventData"),
            new ContentType(MediaTypeNames.Application.Json))
        {

        }
    }

    public class BlobRenamedEvent : TypedCloudEventBase<StorageBlobRenamedEventData>
    {
        public const string CloudEventType = "Microsoft.Storage.BlobRenamed";
        public BlobRenamedEvent(Uri source, string subject, StorageBlobRenamedEventData data) : base(CloudEventType, source, data)
        {
            this.Subject = subject;
        }

        public BlobRenamedEvent(CloudEvent receivedCloudEvent) : base(CloudEventType, receivedCloudEvent)
        {

        }
    }



}

