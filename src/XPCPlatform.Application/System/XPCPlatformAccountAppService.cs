using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp;
using XPCPlatform.Constants;
using Microsoft.AspNetCore.Authorization;
using XPCPlatform.Permissions;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Account;
using Volo.Abp.Account.Emailing;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Users;

namespace XPCPlatform.System
{
    public class XPCPlatformIdentityService : IdentityUserAppService, IIdentityUserAppService
    {
        public XPCPlatformIdentityService(IdentityUserManager userManager, IIdentityUserRepository userRepository, IIdentityRoleRepository roleRepository, IOptions<IdentityOptions> identityOptions)
        : base(userManager, userRepository, roleRepository, identityOptions)
        {
        }

        public override async Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            input.Email = input.Email?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.Email)));
            input.UserName = input.UserName?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.UserName)));
            input.Password = input.Password?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.Password)));

            if (!await AuthorizationService.IsGrantedAsync(XPCPlatformPermissions.AdminAccounts.Create))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Create User"));

            if (!GlobalValidations.IsValidEmailAddress(input.Email))
                throw new UserFriendlyException($"Invalid Request, Company domain does not match. Please use an '{GlobalConstants.COMPANY_DOMAIN_NAME + GlobalConstants.COMPANY_DOMAIN}' email.");

            return await base.CreateAsync(input);
        }
        public override async Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input)
        {
            input.Email = input.Email?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.Email)));
            input.UserName = input.UserName?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.UserName)));

            if (!await AuthorizationService.IsGrantedAsync(XPCPlatformPermissions.AdminAccounts.Edit))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Edit User"));

            if (!GlobalValidations.IsValidEmailAddress(input.Email))
                throw new UserFriendlyException($"Invalid Request, Company domain does not match. Please use an '{GlobalConstants.COMPANY_DOMAIN_NAME + GlobalConstants.COMPANY_DOMAIN}' email.");

            return await base.UpdateAsync(id, input);
        }

        #region Private Functions

        #endregion Private Functions
    }
    //public class XPCPlatformAccountAppService : AccountAppService
    //{
    //    public XPCPlatformAccountAppService(IdentityUserManager userManager, IIdentityRoleRepository roleRepository, IAccountEmailer accountEmailer
    //        , IdentitySecurityLogManager identitySecurityLogManager, IOptions<IdentityOptions> identityOptions)
    //        : base(userManager, roleRepository, accountEmailer, identitySecurityLogManager, identityOptions)
    //    {
    //    }

    //    public override async Task<IdentityUserDto> RegisterAsync(RegisterDto input)
    //    {
    //        input.EmailAddress = input.EmailAddress?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.EmailAddress)));
    //        input.UserName = input.UserName?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.UserName)));
    //        input.Password = input.Password?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.Password)));

    //        if (!await this.AuthorizationService.IsGrantedAsync(XPCPlatformPermissions.AdminAccounts.Create))
    //            throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Create User"));

    //        if (!GlobalValidations.IsValidEmailAddress(input.EmailAddress))
    //            throw new UserFriendlyException($"Invalid Request, Company domain does not match. Please use an '{(GlobalConstants.COMPANY_DOMAIN_NAME + GlobalConstants.COMPANY_DOMAIN)}' email.");

    //        return await base.RegisterAsync(input);
    //    }
    //}
}
