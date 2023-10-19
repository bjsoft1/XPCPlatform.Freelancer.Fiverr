using System.Threading.Tasks;

namespace XPCPlatform.Data;

public interface IXPCPlatformDbSchemaMigrator
{
    Task MigrateAsync();
}
