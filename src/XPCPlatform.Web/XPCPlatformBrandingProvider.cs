using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace XPCPlatform.Web;

[Dependency(ReplaceServices = true)]
public class XPCPlatformBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "XPCPlatform";
}
