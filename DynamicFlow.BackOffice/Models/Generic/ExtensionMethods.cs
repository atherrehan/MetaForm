using System.Text.Json;

namespace DynamicFlow.BackOffice.Models.Generic
{
    public static class ExtensionMethods
    {
        public static string Serialize(this object obj)
        {
            return obj is not null ? JsonSerializer.Serialize(obj) : string.Empty;
        }
        public static T Deserialize<T>(this string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<T>(json, options);

            return result == null ? throw new InvalidOperationException("JSON could not be Deserialized.") : result;
        }
    }
}
