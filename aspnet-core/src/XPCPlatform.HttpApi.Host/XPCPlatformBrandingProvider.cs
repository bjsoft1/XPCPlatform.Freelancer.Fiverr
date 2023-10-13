using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace XPCPlatform;

[Dependency(ReplaceServices = true)]
public class XPCPlatformBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "XPCPlatform";
}
