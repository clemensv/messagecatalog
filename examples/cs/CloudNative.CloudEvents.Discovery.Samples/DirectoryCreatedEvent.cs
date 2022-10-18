using CloudNative.CloudEvents;
using CloudNative.CloudEvents.Discovery.Samples;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mime;

namespace Microsoft.Storage
{

    public partial class StorageDirectoryCreatedEventData : JsonSchemaSerializable
    {
        public StorageDirectoryCreatedEventData() : base(
            new Uri("https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/eventgrid/data-plane/Microsoft.Storage/stable/2018-01-01/Storage.json#/definitions/StorageDirectoryCreatedEventData"),
            new ContentType(MediaTypeNames.Application.Json))
        {

        }
    }

    public class DirectoryCreatedEvent : TypedCloudEventBase<StorageDirectoryCreatedEventData>
    {
        public const string CloudEventType = "Microsoft.Storage.DirectoryCreated";
        public DirectoryCreatedEvent(Uri source, string subject, StorageDirectoryCreatedEventData data) : base(CloudEventType, source, data)
        {
            this.Subject = subject;
        }

        public DirectoryCreatedEvent(CloudEvent receivedCloudEvent) : base(CloudEventType, receivedCloudEvent)
        {

        }
    }



}

