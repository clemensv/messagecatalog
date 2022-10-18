using CloudNative.CloudEvents;
using CloudNative.CloudEvents.Discovery.Samples;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mime;

namespace Microsoft.Storage
{

    public partial class StorageBlobCreatedEventData : JsonSchemaSerializable
    {
        public StorageBlobCreatedEventData() : base(
            new Uri("https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/eventgrid/data-plane/Microsoft.Storage/stable/2018-01-01/Storage.json#/definitions/StorageBlobCreatedEventData"),
            new ContentType(MediaTypeNames.Application.Json))
        {

        }
    }

    public class BlobCreatedEvent : TypedCloudEventBase<StorageBlobCreatedEventData>
    {
        public const string CloudEventType = "Microsoft.Storage.BlobCreated";
        public BlobCreatedEvent(Uri source, string subject, StorageBlobCreatedEventData data) : base(CloudEventType, source, data)
        {
            this.Subject = subject;
        }

        public BlobCreatedEvent(CloudEvent receivedCloudEvent) : base(CloudEventType, receivedCloudEvent)
        {

        }
    }



}

