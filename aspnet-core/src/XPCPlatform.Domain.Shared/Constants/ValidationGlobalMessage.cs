using System;
using System.Collections.Generic;
using System.Text;
using XPCPlatform.Extensions;

namespace XPCPlatform.Constants
{
    //TODO: Get From Locllization (According to language)
    public class GlobalValidationMessage
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
