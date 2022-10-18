using System.Net.Mime;

namespace Microsoft.Storage
{
    // This interface is implemented by code-generated, strongly-typed classes for
    // schemas of specific serialization media types
    public interface ISchemaSerializable
    {
        public Uri DataSchema { get; }
        public ContentType ContentType { get; }

        void Serialize(object buffer);
        void Deserialize(string dataContentType, Uri dataSchema, object data);
    }

}