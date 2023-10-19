using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Identity;
using Volo.Abp.Settings;
using Volo.Abp.Threading;
using XPCPlatform.Constants;
using XPCPlatform.Permissions;

namespace XPCPlatform.System
{
    /*
    public class XPCPlatformIdentityService : IdentityUserAppService//, IIdentityUserAppService
    {
        public XPCPlatformIdentityService(XPCPlatformIdentityUserManager userManager, IIdentityUserRepository userRepository, IIdentityRoleRepository roleRepository, IOptions<IdentityOptions> identityOptions)
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
                throw new UserFriendlyException(GlobalValidationMessage.INVALID_COMPANY_EMAIL_DOMAIN_MESSAGE);

            return await base.CreateAsync(input);
        }
        public override async Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input)
        {
            input.Email = input.Email?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.Email)));
            input.UserName = input.UserName?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.UserName)));

            if (!await AuthorizationService.IsGrantedAsync(XPCPlatformPermissions.AdminAccounts.Edit))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Edit User"));

            if (!GlobalValidations.IsValidEmailAddress(input.Email))
                throw new UserFriendlyException(GlobalValidationMessage.INVALID_COMPANY_EMAIL_DOMAIN_MESSAGE);

            return await base.UpdateAsync(id, input);
        }
    }
    */
    /*
    public class XPCPlatformAccountAppService : AccountAppService, IIdentityUserAppService
    {
        private readonly XPCPlatformIdentityService _identityService;
        public XPCPlatformAccountAppService(XPCPlatformIdentityUserManager userManager, IIdentityRoleRepository roleRepository, IAccountEmailer accountEmailer
            , IdentitySecurityLogManager identitySecurityLogManager, IOptions<IdentityOptions> identityOptions, XPCPlatformIdentityService identityService)
            : base(userManager, roleRepository, accountEmailer, identitySecurityLogManager, identityOptions)
        {
            this._identityService = identityService;
        }
        public async Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            return await _identityService.CreateAsync(input);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _identityService.DeleteAsync(id);
        }
        public async Task<IdentityUserDto> FindByEmailAsync(string email)
        {
            return await _identityService.FindByEmailAsync(email);
        }
        public async Task<IdentityUserDto> FindByUsernameAsync(string userName)
        {
            return await _identityService.FindByUsernameAsync(userName);
        }
        public async Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync()
        {
            return await _identityService.GetAssignableRolesAsync();
        }
        public async Task<IdentityUserDto> GetAsync(Guid id)
        {
            return await GetAsync(id);
        }
        public async Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
        {
            return await _identityService.GetListAsync(input);
        }
        public Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
        {
            return _identityService.GetRolesAsync(id);
        }
        public override async Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {
            input.EmailAddress = input.EmailAddress?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.EmailAddress)));
            input.UserName = input.UserName?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.UserName)));
            input.Password = input.Password?.Trim() ?? throw new UserFriendlyException(GlobalValidationMessage.GetRequiredValidationMessage(nameof(input.Password)));

            if (!await this.AuthorizationService.IsGrantedAsync(XPCPlatformPermissions.AdminAccounts.Create))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Create User"));

            if (!GlobalValidations.IsValidEmailAddress(input.EmailAddress))
                throw new UserFriendlyException(GlobalValidationMessage.INVALID_COMPANY_EMAIL_DOMAIN_MESSAGE);

            return await base.RegisterAsync(input);
        }
        public async Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input)
        {
            return await _identityService.UpdateAsync(id, input);
        }
        public async Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input)
        {
            await _identityService.UpdateRolesAsync(id, input);
        }
    }
    */
    public class XPCPlatformIdentityUserManager : IdentityUserManager
    {
        private readonly IAuthorizationService _authorizationService;
        public XPCPlatformIdentityUserManager(IdentityUserStore store, IIdentityRoleRepository roleRepository, IIdentityUserRepository userRepository
            , IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<IdentityUser> passwordHasher, IEnumerable<IUserValidator<IdentityUser>> userValidators
            , IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services
            , ILogger<XPCPlatformIdentityUserManager> logger, ICancellationTokenProvider cancellationTokenProvider, IOrganizationUnitRepository organizationUnitRepository
            , ISettingProvider settingProvider, IAuthorizationService authorizationService)
            : base(store, roleRepository, userRepository, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services
                  , logger, cancellationTokenProvider, organizationUnitRepository, settingProvider)
        {
            this._authorizationService = authorizationService;
        }

        public override async Task<IdentityResult> CreateAsync(IdentityUser user)
        {

            if (!await this.IsAuthorize(XPCPlatformPermissions.AdminAccounts.Create))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Create User"));
            else if (!GlobalValidations.IsValidEmailAddress(user.Email))
                throw new UserFriendlyException(GlobalValidationMessage.INVALID_COMPANY_EMAIL_DOMAIN_MESSAGE);
            return await base.CreateAsync(user);
        }
        public override async Task<IdentityResult> CreateAsync(IdentityUser user, string password)
        {
            if (!await this.IsAuthorize(XPCPlatformPermissions.AdminAccounts.Create))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Create User"));
            else if (!GlobalValidations.IsValidEmailAddress(user.Email))
                throw new UserFriendlyException(GlobalValidationMessage.INVALID_COMPANY_EMAIL_DOMAIN_MESSAGE);

            return await base.CreateAsync(user, password);
        }
        public override async Task<IdentityResult> CreateAsync(IdentityUser user, string password, bool validatePassword)
        {
            if (!await this.IsAuthorize(XPCPlatformPermissions.AdminAccounts.Create))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Create User"));
            else if (!GlobalValidations.IsValidEmailAddress(user.Email))
                throw new UserFriendlyException(GlobalValidationMessage.INVALID_COMPANY_EMAIL_DOMAIN_MESSAGE);

            return await base.CreateAsync(user, password, validatePassword);
        }
        public override async Task<IdentityResult> UpdateAsync(IdentityUser user)
        {
            if (!await this.IsAuthorize(XPCPlatformPermissions.AdminAccounts.Edit))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Edit User"));
            else if (!GlobalValidations.IsValidEmailAddress(user.Email))
                throw new UserFriendlyException(GlobalValidationMessage.INVALID_COMPANY_EMAIL_DOMAIN_MESSAGE);

            return await base.UpdateAsync(user);
        }
        protected override async Task<IdentityResult> UpdateUserAsync(IdentityUser user)
        {
            if (!await this.IsAuthorize(XPCPlatformPermissions.AdminAccounts.Edit))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Edit User"));
            else if (!GlobalValidations.IsValidEmailAddress(user.Email))
                throw new UserFriendlyException(GlobalValidationMessage.INVALID_COMPANY_EMAIL_DOMAIN_MESSAGE);

            return await base.UpdateUserAsync(user);
        }
        public override async Task UpdateNormalizedEmailAsync(IdentityUser user)
        {
            if (!await this.IsAuthorize(XPCPlatformPermissions.AdminAccounts.ChangeEmail))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Change Email"));
            else if (!GlobalValidations.IsValidEmailAddress(user.Email))
                throw new UserFriendlyException(GlobalValidationMessage.INVALID_COMPANY_EMAIL_DOMAIN_MESSAGE);

            await base.UpdateNormalizedEmailAsync(user);
        }
        public override async Task<IdentityResult> ChangeEmailAsync(IdentityUser user, string newEmail, string token)
        {
            if (!await this.IsAuthorize(XPCPlatformPermissions.AdminAccounts.ChangeEmail))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Change Email"));
            else if (!GlobalValidations.IsValidEmailAddress(user.Email))
                throw new UserFriendlyException(GlobalValidationMessage.INVALID_COMPANY_EMAIL_DOMAIN_MESSAGE);

            return await base.ChangeEmailAsync(user, newEmail, token);
        }
        public override async Task<IdentityResult> SetEmailAsync(IdentityUser user, string? email)
        {
            //if (!await this.IsAuthorize(XPCPlatformPermissions.AdminAccounts.ChangeEmail))
            //    throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Change Email"));
            //else
            if (!GlobalValidations.IsValidEmailAddress(user.Email))
                throw new UserFriendlyException(GlobalValidationMessage.INVALID_COMPANY_EMAIL_DOMAIN_MESSAGE);

            return await base.SetEmailAsync(user, email);
        }
        public override Task<IdentityResult> AddDefaultRolesAsync(IdentityUser user)
        {
            return base.AddDefaultRolesAsync(user);
        }
        public override async Task<IdentityResult> AddToRoleAsync(IdentityUser user, string role)
        {
            if (!await this.IsAuthorize(XPCPlatformPermissions.AdminAccounts.AssignRole))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Assign Role"));

            return await base.AddToRoleAsync(user, role);
        }
        public override async Task<IdentityResult> AddToRolesAsync(IdentityUser user, IEnumerable<string> roles)
        {
            if (!await this.IsAuthorize(XPCPlatformPermissions.AdminAccounts.AssignRole))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Assign Role"));

            return await base.AddToRolesAsync(user, roles);
        }
        public override async Task<IdentityResult> RemoveFromRoleAsync(IdentityUser user, string role)
        {
            if (!await this.IsAuthorize(XPCPlatformPermissions.AdminAccounts.AssignRole))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Assign Role"));

            return await base.RemoveFromRoleAsync(user, role);
        }
        public override async Task<IdentityResult> RemoveFromRolesAsync(IdentityUser user, IEnumerable<string> roles)
        {
            if (!await this.IsAuthorize(XPCPlatformPermissions.AdminAccounts.AssignRole))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Assign Role"));

            return await base.RemoveFromRolesAsync(user, roles);
        }
        public override async Task<IdentityResult> SetRolesAsync(IdentityUser user, IEnumerable<string> roleNames)
        {
            if (!await this.IsAuthorize(XPCPlatformPermissions.AdminAccounts.AssignRole))
                throw new UserFriendlyException(GlobalValidationMessage.GetUnAuthorizeValidationMessage("Assign Role"));

            return await base.SetRolesAsync(user, roleNames);
        }

        #region private Function
        private async Task<bool> IsAuthorize(string policyName)
        {
            return await this._authorizationService.IsGrantedAsync(policyName);
        }
        #endregion private Function
    }
}
