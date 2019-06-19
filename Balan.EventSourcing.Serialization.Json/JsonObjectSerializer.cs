using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Balan.EventSourcing.Serialization.Json
{
    public class JsonObjectSerializer<T> : IJsonObjectSerializer<T>
    {
        private static readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling            = TypeNameHandling.Objects,
            ContractResolver            = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling           = NullValueHandling.Ignore,
            Formatting                  = Formatting.None,
            Converters                  = new[] { new StringEnumConverter() },
            MetadataPropertyHandling    = MetadataPropertyHandling.ReadAhead,
        };

        public T Deserialize(string serialized)
        {
            return JsonConvert.DeserializeObject<T>(serialized, _jsonSerializerSettings);
        }

        public string Serialize(T obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSerializerSettings);
        }
    }
}
