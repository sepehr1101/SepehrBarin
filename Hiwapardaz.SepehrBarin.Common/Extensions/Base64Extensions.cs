using Microsoft.AspNetCore.Http;

namespace Hiwapardaz.SepehrBarin.Common.Extensions
{
    public static class Base64Extensions
    {
        public static string ToBase64(this IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    return s;
                }
            }
            return string.Empty;
        }
    }
}
