using HarmonyLib;
using TeamCherry.Localization;

namespace shards_to_money;

[HarmonyPatch(typeof(CurrencyObjectBase))]
internal sealed class MagnetPullsShards
{
    [HarmonyPatch(nameof(CurrencyObjectBase.MagnetToolIsEquipped))]
    [HarmonyPrefix]
    public static void MagnetPullsShardsAndGeo(ref bool __result, ref bool __runOriginal, ref LocalisedString ___popupName, ToolItem ___magnetTool)
    {
        __result = IsShardOrGeo(ref ___popupName) && IsEquipped(___magnetTool);

        // Skip running the original method
        __runOriginal = false;
    }

    private static bool IsShardOrGeo(ref LocalisedString name) => name.Key == "INV_NAME_COIN" || name.Key == "INV_NAME_SHARD";

    private static bool IsEquipped(ToolItem? tool) => tool != null && tool.IsEquipped;
}