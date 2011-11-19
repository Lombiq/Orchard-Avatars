
namespace Piedone.Avatars.Extensions
{
    public static class StringExtensions
    {
        public static string StripExtension(this string extension)
        {
            return extension.Trim().TrimStart('.').ToLowerInvariant();
        }
    }
}