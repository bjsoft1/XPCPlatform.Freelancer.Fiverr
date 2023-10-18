namespace XPCPlatform.Permissions;

public static class XPCPlatformPermissions
{
    public const string GroupName = "XPCPlatform";
    public const string CreateAccount = ".Create";
    public const string EditAccount = ".Edit";
    public const string DeleteAccount = ".Delete";
    public const string ViewAccount = ".View";
    public static class AdminAccounts
    {
        public const string Default = GroupName + nameof(AdminAccounts);
        public const string Create = Default + CreateAccount;
        public const string Edit = Default + EditAccount;
        public const string Delete = Default + DeleteAccount;
        public const string View = Default + ViewAccount;
    }
}
