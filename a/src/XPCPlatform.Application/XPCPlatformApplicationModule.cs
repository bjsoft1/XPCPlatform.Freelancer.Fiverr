using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Emailing;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace XPCPlatform;

[DependsOn(
    typeof(XPCPlatformDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(XPCPlatformApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class XPCPlatformApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.Replace(ServiceDescriptor.Transient<AccountAppService, XPCPlatformAccountAppService>());

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<XPCPlatformApplicationModule>();
        });
    }
}

public class XPCPlatformAccountAppService : AccountAppService
{
    public XPCPlatformAccountAppService(IdentityUserManager userManager, IIdentityRoleRepository roleRepository, IAccountEmailer accountEmailer
        , IdentitySecurityLogManager identitySecurityLogManager, IOptions<IdentityOptions> identityOptions)
        : base(userManager, roleRepository, accountEmailer, identitySecurityLogManager, identityOptions)
    {

    }

    public override Task<IdentityUserDto> RegisterAsync(RegisterDto input)
    {
        throw new UserFriendlyException("Hello I'm here");
        return base.RegisterAsync(input);

    }
}
