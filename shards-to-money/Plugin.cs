using BepInEx;
using HarmonyLib;

namespace shards_to_money;

[BepInAutoPlugin(id: "org.mar_veloz.silksong.shards_to_money")]
public partial class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        Harmony.CreateAndPatchAll(typeof(NoShardCostTools));
        Harmony.CreateAndPatchAll(typeof(ShopsBuyShards));

        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }
}