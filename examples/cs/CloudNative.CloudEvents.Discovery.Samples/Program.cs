using Azure.Messaging.EventGrid;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Messaging.EventGrid.CloudNativeCloudEvents;
using Microsoft.Storage;

namespace CloudNative.CloudEvents.Discovery.Samples
{
    internal class Program
    {
        public async static Task Main(string[] args)
        {
            EventGridPublisherClient client = new EventGridPublisherClient(
        new Uri(""),
        new AzureKeyCredential(""));

            var ev = new Microsoft.Storage.BlobCreatedEvent(
                    new Uri("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/mygroup/providers/Microsoft.Storage/storageAccounts/myaccount", UriKind.Relative),
                    "/testcontainer/new-file.txt",
                    new StorageBlobCreatedEventData()
                    {
                        Api = "PutBlockList",
                        ClientRequestId = "6d79dbfb-0e37-4fc4-981f-442c9ca65760",
                        RequestId = "831e1650-001e-001b-66ab-eeb76e000000",
                        ETag = "\"0x8D4BCC2E4835CD0\"",
                        ContentType = "text/plain",
                        ContentLength = 524288,
                        BlobType = "BlockBlob",
                        Url = "https://my-storage-account.blob.core.windows.net/testcontainer/new-file.txt",
                        Sequencer = "00000000000004420000000000028963",
                    });
            await client.SendCloudNativeCloudEventAsync(ev.ToCloudEvent());
        }
    }
}
