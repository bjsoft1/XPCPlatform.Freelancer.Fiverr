using XPCPlatform.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace XPCPlatform.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(XPCPlatformEntityFrameworkCoreModule),
    typeof(XPCPlatformApplicationContractsModule)
    )]
public class XPCPlatformDbMigratorModule : AbpModule
{
}
