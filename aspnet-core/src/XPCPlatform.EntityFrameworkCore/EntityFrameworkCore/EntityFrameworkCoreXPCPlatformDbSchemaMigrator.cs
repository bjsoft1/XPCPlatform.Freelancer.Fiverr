using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using XPCPlatform.Data;
using Volo.Abp.DependencyInjection;

namespace XPCPlatform.EntityFrameworkCore;

public class EntityFrameworkCoreXPCPlatformDbSchemaMigrator
    : IXPCPlatformDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreXPCPlatformDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the XPCPlatformDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<XPCPlatformDbContext>()
            .Database
            .MigrateAsync();
    }
}
