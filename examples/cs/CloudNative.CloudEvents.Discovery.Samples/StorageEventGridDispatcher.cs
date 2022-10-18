using Microsoft.Storage;

namespace CloudNative.CloudEvents.Discovery.Samples
{
    public class StorageEventGridDispatcher
    {
        public event EventHandler<BlobCreatedEvent> BlobCreatedEventHandler;
        public event EventHandler<BlobDeletedEvent> BlobDeletedEventHandler;
        public event EventHandler<BlobRenamedEvent> BlobRenamedEventHandler;
        public event EventHandler<DirectoryCreatedEvent> DirectoryCreatedEventHandler;
        public event EventHandler<DirectoryDeletedEvent> DirectoryDeletedEventHandler;
        public event EventHandler<DirectoryRenamedEvent> DirectoryRenamedEventHandler;
        public event EventHandler<BlobTierChangedEvent> BlobTierChangedEventHandler;
        public event EventHandler<StorageAsyncOperationInitiatedEvent> StorageAsyncOperationInitiatedEventHandler;
        public event EventHandler<StorageLifecyclePolicyCompletedEvent> StorageLifecyclePolicyCompletedEventHandler;

        public void Dispatch(CloudEvent cloudEvent)
        {
            switch (cloudEvent.Type)
            {
                case BlobCreatedEvent.CloudEventType:
                    OnBlobCreatedEvent(cloudEvent);
                    break;
                case BlobDeletedEvent.CloudEventType:
                    OnBlobDeletedEvent(cloudEvent);
                    break;
                case BlobRenamedEvent.CloudEventType:
                    OnBlobRenamedEvent(cloudEvent);
                    break;
                case DirectoryCreatedEvent.CloudEventType:
                    OnDirectoryCreatedEvent(cloudEvent);
                    break;
                case DirectoryDeletedEvent.CloudEventType:
                    OnDirectoryDeletedEvent(cloudEvent);
                    break;
                case DirectoryRenamedEvent.CloudEventType:
                    OnDirectoryRenamedEvent(cloudEvent);
                    break;
                case StorageAsyncOperationInitiatedEvent.CloudEventType:
                    OnStorageAsyncOperationInitiatedEvent(cloudEvent);
                    break;
                case StorageLifecyclePolicyCompletedEvent.CloudEventType:
                    OnStorageLifecyclePolicyCompletedEvent(cloudEvent);
                    break;
            }
        }

        private void OnBlobCreatedEvent(CloudEvent cloudEvent)
        {
            if (BlobCreatedEventHandler != null)
            {
                BlobCreatedEventHandler(this, new BlobCreatedEvent(cloudEvent));
            }
        }

        private void OnBlobDeletedEvent(CloudEvent cloudEvent)
        {
            if (BlobDeletedEventHandler != null)
            {
                BlobDeletedEventHandler(this, new BlobDeletedEvent(cloudEvent));
            }
        }

        private void OnBlobRenamedEvent(CloudEvent cloudEvent)
        {
            if (BlobRenamedEventHandler != null)
            {
                BlobRenamedEventHandler(this, new BlobRenamedEvent(cloudEvent));
            }
        }

        private void OnDirectoryCreatedEvent(CloudEvent cloudEvent)
        {
            if (DirectoryCreatedEventHandler != null)
            {
                DirectoryCreatedEventHandler(this, new DirectoryCreatedEvent(cloudEvent));
            }
        }

        private void OnDirectoryDeletedEvent(CloudEvent cloudEvent)
        {
            if (DirectoryDeletedEventHandler != null)
            {
                DirectoryDeletedEventHandler(this, new DirectoryDeletedEvent(cloudEvent));
            }
        }

        private void OnDirectoryRenamedEvent(CloudEvent cloudEvent)
        {
            if (DirectoryRenamedEventHandler != null)
            {
                DirectoryRenamedEventHandler(this, new DirectoryRenamedEvent(cloudEvent));
            }
        }

        private void OnBlobTierChangedEvent(CloudEvent cloudEvent)
        {
            if (BlobTierChangedEventHandler != null)
            {
                BlobTierChangedEventHandler(this, new BlobTierChangedEvent(cloudEvent));
            }
        }

        private void OnStorageLifecyclePolicyCompletedEvent(CloudEvent cloudEvent)
        {
            if (StorageLifecyclePolicyCompletedEventHandler != null)
            {
                StorageLifecyclePolicyCompletedEventHandler(this, new StorageLifecyclePolicyCompletedEvent(cloudEvent));
            }
        }

        private void OnStorageAsyncOperationInitiatedEvent(CloudEvent cloudEvent)
        {
            if (StorageAsyncOperationInitiatedEventHandler != null)
            {
                StorageAsyncOperationInitiatedEventHandler(this, new StorageAsyncOperationInitiatedEvent(cloudEvent));
            }
        }
    }
}
