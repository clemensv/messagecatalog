using Microsoft.Storage;
using System.ComponentModel.DataAnnotations;

namespace CloudNative.CloudEvents.Discovery.Samples
{
    public abstract class TypedCloudEventBase<T> : IValidatableObject where T : ISchemaSerializable, new()
    {
        protected TypedCloudEventBase(string type, CloudEvent receivedCloudEvent)
        {
            this.Type = type;
            ApplyCloudEvent(receivedCloudEvent);
        }

        protected TypedCloudEventBase(string type, Uri source, T data, string id = null)
        {
            this.Type = type;
            this.Source = source;
            this.Data = data;
            this.Id = id ?? Guid.NewGuid().ToString();
            this.Time = DateTime.UtcNow;            
        }

        public virtual object? this[CloudEventAttribute attribute] { get { return CloudEvent[attribute]; } set { CloudEvent[attribute] = value; } }
        public virtual object? this[string attributeName] { get { return CloudEvent[attributeName]; } set { CloudEvent[attributeName] = value; } }

        public virtual IEnumerable<CloudEventAttribute> ExtensionAttributes { get { return CloudEvent.ExtensionAttributes; } }
        public virtual string? Id { get { return CloudEvent.Id; } protected set { CloudEvent.Id = value; } }
        public virtual Uri? Source { get { return CloudEvent.Source; } protected set { CloudEvent.Source = value; } }
        public virtual string? Subject { get { return CloudEvent.Subject; } protected set { CloudEvent.Subject = value; } }
        public virtual DateTimeOffset? Time { get { return CloudEvent.Time; } protected set { CloudEvent.Time = value; } }

        public virtual string? Type { get { return CloudEvent.Type; } protected set { CloudEvent.Type = value; } }

        public virtual T Data { get; protected set; }
        protected CloudEvent CloudEvent { get; } = new CloudEvent();
                
        protected void ApplyCloudEvent(CloudEvent receivedCloudEvent)
        {
            if ( receivedCloudEvent.Type != Type)
            {
                throw new InvalidOperationException($"Incompatible CloudEvent type {receivedCloudEvent.Type}. Required: {Type}");
            }
            CloudEvent.Subject = receivedCloudEvent.Subject;
            CloudEvent.Source = receivedCloudEvent.Source;
            CloudEvent.Data = receivedCloudEvent.Data;
            CloudEvent.DataContentType = receivedCloudEvent.DataContentType;
            CloudEvent.DataSchema = receivedCloudEvent.DataSchema;
            CloudEvent.Id = receivedCloudEvent.Id;
            CloudEvent.Type = receivedCloudEvent.Type;
            CloudEvent.Time = receivedCloudEvent.Time;
            foreach (var attr in receivedCloudEvent.ExtensionAttributes)
            {
                CloudEvent.ExtensionAttributes.Append(attr);
            }
            Data = new T();
            Data.Deserialize(CloudEvent.DataContentType, CloudEvent.DataSchema, receivedCloudEvent.Data);
        }

        public CloudEvent ToCloudEvent()
        {
            MemoryStream memoryStream = new MemoryStream();
            Data.Serialize(memoryStream);
            CloudEvent.Data = memoryStream.ToArray();
            CloudEvent.DataContentType = Data.ContentType.ToString();
            CloudEvent.DataSchema = Data.DataSchema;
            return CloudEvent;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}