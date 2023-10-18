using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Identity;
using XPCPlatform.Constants;
using XPCPlatform.Permissions;

namespace XPCPlatform.SystemService
{
    public class XPCPlatformIdentityService : IdentityUserAppService
    {
        public XPCPlatformIdentityService(IdentityUserManager userManager, IIdentityUserRepository userRepository, IIdentityRoleRepository roleRepository, IOptions<IdentityOptions> identityOptions)
        : base(userManager, userRepository, roleRepository, identityOptions) { }
        [AllowAnonymous]
        public override async Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            input.Email = input.Email?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.Email)));
            input.UserName = input.UserName?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.UserName)));
            input.Password = input.Password?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.Password)));

            if(!await this.AuthorizationService.IsGrantedAsync(XPCPlatformPermissions.AdminAccounts.Create))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Create User"));

            if (!IsValidEmailAddress(input.Email))
                throw new UserFriendlyException($"Invalid Request, Company domain does not match. Please use an '{(GlobalConstants.COMPANY_DOMAIN_NAME + GlobalConstants.COMPANY_DOMAIN)}' email.");

            return await base.CreateAsync(input);
        }



        #region Private Functions
        private bool IsValidEmailAddress(string emailAddress)
        {
            if (emailAddress == null)
                return false;

            string pattern = @"^[a-zA-Z0-9._%+-]+@" + GlobalConstants.COMPANY_DOMAIN_NAME + @"\" + GlobalConstants.COMPANY_DOMAIN + "$";
            return Regex.IsMatch(emailAddress, pattern);
        }
        #endregion Private Functions
    }
}
