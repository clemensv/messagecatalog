using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Mime;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace CloudNative.CloudEvents
{
    public class JsonSchemaSerializable : ISchemaSerializable
    {
        static JsonSerializer js = JsonSerializer.CreateDefault();
        private readonly Uri dataSchema;
        private readonly ContentType contentType;

        Uri ISchemaSerializable.DataSchema { get { return dataSchema; } }
        ContentType ISchemaSerializable.ContentType { get { return contentType; } }

        public JsonSchemaSerializable()
        {
            this.dataSchema = null;
            this.contentType = null;
        }

        public JsonSchemaSerializable(Uri dataSchema, ContentType contentType)
        {
            this.dataSchema = dataSchema;
            this.contentType = contentType;
        }

        void ISchemaSerializable.Serialize(object buffer)
        {
            if (buffer is Stream)
            {
                StreamWriter textWriter = new StreamWriter((Stream)buffer);
                JsonWriter jsonWriter = new JsonTextWriter(textWriter);
                js.Serialize(jsonWriter, this);
                textWriter.Flush();
            }
            else if (buffer is JProperty)
            {
                JProperty jsonObject = (JProperty)buffer;
                jsonObject.Value = JObject.FromObject(this);
            }
            else if (buffer is JToken)
            {
                JToken jsonObject = (JToken)buffer;
                jsonObject.AddAfterSelf(JObject.FromObject(this));
            }
        }

        void ISchemaSerializable.Deserialize(string dataContentType, Uri dataSchema, object data)
        {
            if (data is JToken)
            {
                JsonReader reader = new JTokenReader((JToken)data);
                js.Populate(reader, this);
            }
            else if (data is Stream)
            {
                JsonReader reader = new JsonTextReader(new StreamReader((Stream)data));
                js.Populate(reader, this);
            }
        }

    }

}