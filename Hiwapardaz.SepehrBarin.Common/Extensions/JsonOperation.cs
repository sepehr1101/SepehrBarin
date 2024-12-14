using System.Text.Json;

namespace Hiwapardaz.SepehrBarin.Common.Extensions
{
    public static class JsonOperation
    {       
        public static T Clone<T>(this T source)
        {
            source.NotNull(nameof(source));
            var serialized = JsonSerializer.Serialize(source);
            return JsonSerializer.Deserialize<T>(serialized);
        }

        public static string Marshal(this object obj)
        {
            obj.NotNull(nameof(obj));
            return JsonSerializer.Serialize(obj);
        }
       
        public static T Unmarshal<T>(this string jsonString)
        {
            jsonString.NotNull(nameof(jsonString));
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
