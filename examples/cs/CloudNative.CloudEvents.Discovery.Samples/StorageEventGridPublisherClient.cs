using Azure;
using Azure.Messaging.EventGrid;
using Microsoft.Azure.Messaging.EventGrid.CloudNativeCloudEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Storage
{ 
    internal class StorageEventGridPublisherClient : EventGridPublisherClient
    {
        public StorageEventGridPublisherClient(Uri uri, AzureKeyCredential cred):base(uri, cred)
        {

        }

        Task SendBlobCreatedEventAsync(BlobCreatedEvent blobCreatedEvent)
        {
            return this.SendCloudNativeCloudEventAsync(blobCreatedEvent.ToCloudEvent());
        }

        Task SendBlobDeletedEventAsync(BlobDeletedEvent blobDeletedEvent)
        {
            return this.SendCloudNativeCloudEventAsync(blobDeletedEvent.ToCloudEvent());
        }

        Task SendBlobRenamedEventAsync(BlobRenamedEvent blobRenamedEvent)
        {
            return this.SendCloudNativeCloudEventAsync(blobRenamedEvent.ToCloudEvent());
        }

        Task SendBlobTierChangedEventAsync(BlobTierChangedEvent blobTierChangedEvent)
        {
            return this.SendCloudNativeCloudEventAsync(blobTierChangedEvent.ToCloudEvent());
        }

        Task SendDirectoryCreatedEventAsync(DirectoryCreatedEvent DirectoryCreatedEvent)
        {
            return this.SendCloudNativeCloudEventAsync(DirectoryCreatedEvent.ToCloudEvent());
        }

        Task SendDirectoryDeletedEventAsync(DirectoryDeletedEvent DirectoryDeletedEvent)
        {
            return this.SendCloudNativeCloudEventAsync(DirectoryDeletedEvent.ToCloudEvent());
        }

        Task SendDirectoryRenamedEventAsync(DirectoryRenamedEvent DirectoryRenamedEvent)
        {
            return this.SendCloudNativeCloudEventAsync(DirectoryRenamedEvent.ToCloudEvent());
        }

        Task SendStorageAsyncOperationInitiatedEventAsync(StorageAsyncOperationInitiatedEvent StorageAsyncOperationInitiatedEvent)
        {
            return this.SendCloudNativeCloudEventAsync(StorageAsyncOperationInitiatedEvent.ToCloudEvent());
        }

        Task SendStorageLifecyclePolicyCompletedEventAsync(StorageLifecyclePolicyCompletedEvent StorageLifecyclePolicyCompletedEvent)
        {
            return this.SendCloudNativeCloudEventAsync(StorageLifecyclePolicyCompletedEvent.ToCloudEvent());
        }
    }
}
