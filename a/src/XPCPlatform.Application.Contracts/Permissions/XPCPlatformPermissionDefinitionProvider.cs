using XPCPlatform.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace XPCPlatform.Permissions;

public class XPCPlatformPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(XPCPlatformPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(XPCPlatformPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<XPCPlatformResource>(name);
    }
}
