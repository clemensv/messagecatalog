using Azure;
using CloudNative.CloudEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Storage
{
    public class StorageEventPublisher<T> where T : ICloudEventPublisher
    {
        private readonly T sender;
        private readonly ContentMode contentMode;
        private readonly CloudEventFormatter formatter;

        public StorageEventPublisher(T publisher, ContentMode contentMode, CloudEventFormatter formatter)
        {
            this.sender = publisher;
            this.contentMode = contentMode;
            this.formatter = formatter;
        }

        public Task SendBlobCreatedEventAsync(BlobCreatedEvent blobCreatedEvent)
        {
            return this.sender.SendAsync(blobCreatedEvent.ToCloudEvent(contentMode, formatter), contentMode, formatter);
        }

        public Task SendBlobDeletedEventAsync(BlobDeletedEvent blobDeletedEvent)
        {
            return this.sender.SendAsync(blobDeletedEvent.ToCloudEvent(contentMode, formatter), contentMode, formatter);
        }

        public Task SendBlobRenamedEventAsync(BlobRenamedEvent blobRenamedEvent)
        {
            return this.sender.SendAsync(blobRenamedEvent.ToCloudEvent(contentMode, formatter), contentMode, formatter);
        }

        public Task SendBlobTierChangedEventAsync(BlobTierChangedEvent blobTierChangedEvent)
        {
            return this.sender.SendAsync(blobTierChangedEvent.ToCloudEvent(contentMode, formatter), contentMode, formatter);
        }

        public Task SendDirectoryCreatedEventAsync(DirectoryCreatedEvent DirectoryCreatedEvent)
        {
            return this.sender.SendAsync(DirectoryCreatedEvent.ToCloudEvent(contentMode, formatter), contentMode, formatter);
        }

        public Task SendDirectoryDeletedEventAsync(DirectoryDeletedEvent DirectoryDeletedEvent)
        {
            return this.sender.SendAsync(DirectoryDeletedEvent.ToCloudEvent(contentMode, formatter), contentMode, formatter);
        }

        public Task SendDirectoryRenamedEventAsync(DirectoryRenamedEvent DirectoryRenamedEvent)
        {
            return this.sender.SendAsync(DirectoryRenamedEvent.ToCloudEvent(contentMode, formatter), contentMode, formatter);
        }

        public Task SendStorageAsyncOperationInitiatedEventAsync(StorageAsyncOperationInitiatedEvent StorageAsyncOperationInitiatedEvent)
        {
            return this.sender.SendAsync(StorageAsyncOperationInitiatedEvent.ToCloudEvent(contentMode, formatter), contentMode, formatter);
        }

        public Task SendStorageLifecyclePolicyCompletedEventAsync(StorageLifecyclePolicyCompletedEvent StorageLifecyclePolicyCompletedEvent)
        {
            return this.sender.SendAsync(StorageLifecyclePolicyCompletedEvent.ToCloudEvent(contentMode, formatter), contentMode, formatter);
        }
    }
}
