using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlashCardsApp.Serialization
{
    public class CustomSerializer : JsonConverter<Type>
    {
        public override Type Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
