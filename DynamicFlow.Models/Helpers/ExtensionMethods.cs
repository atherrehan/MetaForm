using System.Text.Json;
using System.Text.RegularExpressions;
using DynamicFlow.Models.Generic;

namespace DynamicFlow.Models.Helpers
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
            var result = JsonSerializer.Deserialize<T>(json,options);

            return result == null ? throw new InvalidOperationException("JSON could not be Deserialized.") : result;
        }
        public static ApiResponse<T> GenericResponseApi<T>(this object obj, string Code = "400", string Message = "Bad Request") where T : class
        {
            return new ApiResponse<T>()
            {
                responseCode = Code,
                responseMessage = Message,
                body = (T)obj
            };
        }
    }
}
