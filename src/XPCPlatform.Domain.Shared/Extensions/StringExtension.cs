
namespace XPCPlatform.Extensions
{
    public static class StringExtension
    {
        public static string CapitalizeFirstLetter(this string? input)
        {
            if (string.IsNullOrEmpty(input))
                return input ?? string.Empty;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
