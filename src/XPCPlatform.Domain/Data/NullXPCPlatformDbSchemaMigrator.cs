using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace XPCPlatform.Data;

/* This is used if database provider does't define
 * IXPCPlatformDbSchemaMigrator implementation.
 */
public class NullXPCPlatformDbSchemaMigrator : IXPCPlatformDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
