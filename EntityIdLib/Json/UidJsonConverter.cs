using System;
using EntityIdLib.Uids;
using Newtonsoft.Json;

namespace EntityIdLib.Json
{
    public class UidJsonConverter : JsonConverter<IUid>
    {
        public override void WriteJson(JsonWriter writer, IUid value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.Value);
        }

        public override IUid ReadJson(JsonReader reader, Type objectType, IUid existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var uidValue = reader.Value?.ToString();
            IUid uid = string.IsNullOrEmpty(uidValue) && hasExistingValue
                    ? existingValue
                    : (IUid)Activator.CreateInstance(objectType, new Uid(uidValue));
            return uid;
        }
    }
}