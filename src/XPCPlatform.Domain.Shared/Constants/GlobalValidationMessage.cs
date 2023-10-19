using System;
using System.Text.RegularExpressions;
using XPCPlatform.Extensions;

namespace XPCPlatform.Constants
{
    public static class GlobalValidations
    {
        public static bool IsValidEmailAddress(string emailAddress)
        {
            if (emailAddress == null)
                return false;

            string pattern = @"^[a-zA-Z0-9._%+-]+@" + GlobalConstants.COMPANY_DOMAIN_NAME + @"\" + GlobalConstants.COMPANY_DOMAIN + "$";
            return Regex.IsMatch(emailAddress, pattern);
        }
    }
    public static class GlobalValidationMessage
    {
        public static string GetRequiredValidationMessage(string keyName)
        {
            return $"Invalid Request, '{keyName.CapitalizeFirstLetter()}' is required.";
        }
        public static string GetUnAuthorizeValidationMessage(string? sectionName = null)
        {
            if (sectionName.IsNullOrWhiteSpace())
                return "You don't have permission to access this.";
            else
                return $"You don't have permission to access this '{sectionName.CapitalizeFirstLetter()}' section.";
        }
    }
    public class GlobalConstants
    {
        public const string COMPANY_DOMAIN = ".com";
        public const string COMPANY_DOMAIN_NAME = "bjsoft";
    }
}
