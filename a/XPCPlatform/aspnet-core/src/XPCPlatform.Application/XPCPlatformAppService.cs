using System;
using System.Collections.Generic;
using System.Text;
using XPCPlatform.Localization;
using Volo.Abp.Application.Services;

namespace XPCPlatform;

/* Inherit your application services from this class.
 */
public abstract class XPCPlatformAppService : ApplicationService
{
    protected XPCPlatformAppService()
    {
        LocalizationResource = typeof(XPCPlatformResource);
    }
}
