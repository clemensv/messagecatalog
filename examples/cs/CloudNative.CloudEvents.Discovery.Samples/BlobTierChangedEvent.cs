using CloudNative.CloudEvents;
using CloudNative.CloudEvents.Discovery.Samples;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mime;

namespace Microsoft.Storage
{

    public partial class StorageBlobTierChangedEventData : JsonSchemaSerializable
    {
        public StorageBlobTierChangedEventData() : base(
            new Uri("https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/eventgrid/data-plane/Microsoft.Storage/stable/2018-01-01/Storage.json#/definitions/StorageBlobTierChangedEventData"),
            new ContentType(MediaTypeNames.Application.Json))
        {

        }
    }

    public class BlobTierChangedEvent : TypedCloudEventBase<StorageBlobTierChangedEventData>
    {
        public const string CloudEventType = "Microsoft.Storage.BlobTierChanged";
        public BlobTierChangedEvent(Uri source, string subject, StorageBlobTierChangedEventData data) : base(CloudEventType, source, data)
        {
            this.Subject = subject;
        }

        public BlobTierChangedEvent(CloudEvent receivedCloudEvent) : base(CloudEventType, receivedCloudEvent)
        {

        }
    }



}

