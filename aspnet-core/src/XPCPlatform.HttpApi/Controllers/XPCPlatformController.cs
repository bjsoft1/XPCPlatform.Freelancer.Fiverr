using Volo.Abp.AspNetCore.Mvc;
using XPCPlatform.Localization;

namespace XPCPlatform.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class XPCPlatformController : AbpControllerBase
{
    protected XPCPlatformController()
    {
        LocalizationResource = typeof(XPCPlatformResource);
    }
}
