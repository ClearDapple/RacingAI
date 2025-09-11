using LootLocker.Requests;

namespace LootLocker {
public static class LootLockerSettingsOverrider
{
    public static void OverrideSettings()
    {
        LootLockerSDKManager.Init("dev_639d6f22fb764a86927eb13aaabd8b73", "0.0.0.1", "r9dj5m2t");
        LootLocker.LootLockerConfig.current.currentDebugLevel = LootLocker.LootLockerConfig.DebugLevel.All;
    }
}
}
