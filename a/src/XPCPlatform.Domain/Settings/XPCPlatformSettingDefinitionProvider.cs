using Volo.Abp.Settings;

namespace XPCPlatform.Settings;

public class XPCPlatformSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(XPCPlatformSettings.MySetting1));
    }
}
