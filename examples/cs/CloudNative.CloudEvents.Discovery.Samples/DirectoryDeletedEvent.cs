using CloudNative.CloudEvents;
using CloudNative.CloudEvents.Discovery.Samples;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mime;

namespace Microsoft.Storage
{

    public partial class StorageDirectoryDeletedEventData : JsonSchemaSerializable
    {
        public StorageDirectoryDeletedEventData() : base(
            new Uri("https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/eventgrid/data-plane/Microsoft.Storage/stable/2018-01-01/Storage.json#/definitions/StorageDirectoryDeletedEventData"),
            new ContentType(MediaTypeNames.Application.Json))
        {

        }
    }

    public class DirectoryDeletedEvent : TypedCloudEventBase<StorageDirectoryDeletedEventData>
    {
        public const string CloudEventType = "Microsoft.Storage.DirectoryDeleted";
        public DirectoryDeletedEvent(Uri source, string subject, StorageDirectoryDeletedEventData data) : base(CloudEventType, source, data)
        {
            this.Subject = subject;
        }

        public DirectoryDeletedEvent(CloudEvent receivedCloudEvent) : base(CloudEventType, receivedCloudEvent)
        {

        }
    }



}

