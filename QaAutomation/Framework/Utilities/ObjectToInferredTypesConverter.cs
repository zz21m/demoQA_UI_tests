using System.Text.Json;
using System.Text.Json.Serialization;

namespace Framework.Utilities;

public class ObjectToInferredTypesConverter : JsonConverter<object>
{
    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.String => reader.GetString()!,
            JsonTokenType.True => true,
            JsonTokenType.False => false,
            JsonTokenType.Number when reader.TryGetInt32(out var value) => value,
            JsonTokenType.Number => reader.GetDouble(),
            _ => throw new JsonException(
                $"Unsupported JSON value: {reader.TokenType}")
        };
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value,
            value.GetType(),
            options);
    }
}