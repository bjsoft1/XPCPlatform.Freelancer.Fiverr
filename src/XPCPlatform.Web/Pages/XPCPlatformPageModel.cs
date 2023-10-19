using XPCPlatform.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace XPCPlatform.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class XPCPlatformPageModel : AbpPageModel
{
    protected XPCPlatformPageModel()
    {
        LocalizationResourceType = typeof(XPCPlatformResource);
    }
}
