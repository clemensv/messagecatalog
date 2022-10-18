using CloudNative.CloudEvents;
using CloudNative.CloudEvents.Discovery.Samples;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mime;

namespace Microsoft.Storage
{

    public partial class StorageDirectoryRenamedEventData : JsonSchemaSerializable
    {
        public StorageDirectoryRenamedEventData() : base(
            new Uri("https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/eventgrid/data-plane/Microsoft.Storage/stable/2018-01-01/Storage.json#/definitions/StorageDirectoryRenamedEventData"),
            new ContentType(MediaTypeNames.Application.Json))
        {

        }
    }

    public class DirectoryRenamedEvent : TypedCloudEventBase<StorageDirectoryRenamedEventData>
    {
        public const string CloudEventType = "Microsoft.Storage.DirectoryRenamed";
        public DirectoryRenamedEvent(Uri source, string subject, StorageDirectoryRenamedEventData data) : base(CloudEventType, source, data)
        {
            this.Subject = subject;
        }

        public DirectoryRenamedEvent(CloudEvent receivedCloudEvent) : base(CloudEventType, receivedCloudEvent)
        {

        }
    }



}

