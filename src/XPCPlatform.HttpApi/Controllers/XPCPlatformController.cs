using XPCPlatform.Localization;
using Volo.Abp.AspNetCore.Mvc;

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
