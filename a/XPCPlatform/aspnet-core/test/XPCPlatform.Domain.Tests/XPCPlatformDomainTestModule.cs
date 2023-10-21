using XPCPlatform.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace XPCPlatform;

[DependsOn(
    typeof(XPCPlatformEntityFrameworkCoreTestModule)
    )]
public class XPCPlatformDomainTestModule : AbpModule
{

}
