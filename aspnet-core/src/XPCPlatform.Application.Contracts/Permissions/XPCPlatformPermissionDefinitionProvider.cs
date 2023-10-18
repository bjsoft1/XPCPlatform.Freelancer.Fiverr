using XPCPlatform.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using JetBrains.Annotations;

namespace XPCPlatform.Permissions;

public class XPCPlatformPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var XPCPlatformGroup = context.AddGroup(XPCPlatformPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(XPCPlatformPermissions.MyPermission1, L("Permission:MyPermission1"));

        #region Admin permission
        var adminPermission = XPCPlatformGroup.AddPermission(XPCPlatformPermissions.AdminAccounts.Default, L($"Permission:{XPCPlatformPermissions.AdminAccounts.Default}"));
        //adminPermission.AddChild(XPCPlatformPermissions.AdminAccounts.Create);
        //adminPermission.AddChild(XPCPlatformPermissions.AdminAccounts.Create);
        //adminPermission.AddChild(XPCPlatformPermissions.AdminAccounts.Edit);
        //adminPermission.AddChild(XPCPlatformPermissions.AdminAccounts.Delete);
        //adminPermission.AddChild(XPCPlatformPermissions.AdminAccounts.View);
        #endregion Admin permission

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<XPCPlatformResource>(name);
    }
}
