﻿using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using XPCPlatform.System;

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
        //context.Services.Replace(ServiceDescriptor.Transient<IdentityUserAppService, XPCPlatformIdentityService>());
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<XPCPlatformApplicationModule>();
        });
    }
}
