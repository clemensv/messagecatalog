using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Storage;
using Microsoft.Azure.Amqp;
using Azure.Messaging.ServiceBus;
using Microsoft.VisualBasic;
using CloudNative.CloudEvents.NewtonsoftJson;
using Azure.Identity;

namespace CloudNative.CloudEvents.Discovery.Samples
{


    internal class Program
    {
        public async static Task Main(string[] args)
        {
            CloudEventFormatter formatter = new JsonEventFormatter();

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

            ServiceBusClient client = new ServiceBusClient("clemensvams.servicebus.windows.net", new DefaultAzureCredential());


            var fooReceiver = client.CreateProcessor("foo", new ServiceBusProcessorOptions { AutoCompleteMessages = false});
            var dispatcher = new StorageEventDispatcher();
            dispatcher.BlobCreatedEventHandler += Dispatcher_BlobCreatedEventHandler;
            fooReceiver.ProcessMessageAsync += async (arg) =>
            {
                try
                {
                    dispatcher.Dispatch(arg.Message.ToCloudEvent());
                    await arg.CompleteMessageAsync(arg.Message);
                }
                catch(ArgumentException ex)
                {
                    await arg.DeadLetterMessageAsync(arg.Message, ex.Message);
                }
            };
            fooReceiver.ProcessErrorAsync += FooReceiver_ProcessErrorAsync;
            await fooReceiver.StartProcessingAsync();


            var fooSender = client.CreateSender("foo");
            var structuredEventPublisher = new StorageEventPublisher<ServiceBusPublisher>(new ServiceBusPublisher(fooSender), ContentMode.Structured, formatter);
            await structuredEventPublisher.SendBlobCreatedEventAsync(ev);
            var binaryEventPublisher = new StorageEventPublisher<ServiceBusPublisher>(new ServiceBusPublisher(fooSender), ContentMode.Binary, formatter);
            await binaryEventPublisher.SendBlobCreatedEventAsync(ev);
                       

            Console.ReadLine();
        }

        private static async Task FooReceiver_ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            
        }

        private static void Dispatcher_BlobCreatedEventHandler(object sender, BlobCreatedEvent e)
        {
            Console.WriteLine(e.Data.Api);
        }
    }
}
