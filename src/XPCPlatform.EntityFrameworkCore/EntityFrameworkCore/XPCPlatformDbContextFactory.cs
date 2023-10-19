using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace XPCPlatform.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class XPCPlatformDbContextFactory : IDesignTimeDbContextFactory<XPCPlatformDbContext>
{
    public XPCPlatformDbContext CreateDbContext(string[] args)
    {
        XPCPlatformEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<XPCPlatformDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new XPCPlatformDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../XPCPlatform.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
