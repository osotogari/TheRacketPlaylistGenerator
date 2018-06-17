using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TheRacketPlaylistGenerator.Helpers
{
    public class SingleValueArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object retValue = new Object();

            if (reader.TokenType == JsonToken.StartObject)
            {
                T instance = (T)serializer.Deserialize(reader, typeof(T));
                retValue = new List<T>() { instance };
            }
            else if (reader.TokenType == JsonToken.StartArray)
            {
                retValue = serializer.Deserialize(reader, objectType);
            }

            return retValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}