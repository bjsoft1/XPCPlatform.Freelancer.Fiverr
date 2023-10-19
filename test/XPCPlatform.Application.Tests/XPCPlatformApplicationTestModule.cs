using Volo.Abp.Modularity;

namespace XPCPlatform;

[DependsOn(
    typeof(XPCPlatformApplicationModule),
    typeof(XPCPlatformDomainTestModule)
    )]
public class XPCPlatformApplicationTestModule : AbpModule
{

}
