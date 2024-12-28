using System.Text.Json;
using System.Text.Json.Serialization;

namespace IP.Geolocation.APIReturns;

internal class StringOrIntConverter : JsonConverter<string?>
{
	public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		// Converte valores numéricos ou texto para string
		if (reader.TokenType == JsonTokenType.Number)
		{
			return reader.GetInt32().ToString();
		}
		if (reader.TokenType == JsonTokenType.String)
		{
			return reader.GetString();
		}
		return null;
	}

	public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
	{
		// Escreve como string no JSON
		writer.WriteStringValue(value);
	}
}
