using HarmonyLib;
using static ToolItem;

namespace shards_to_money;

[HarmonyPatch(typeof(ToolItem))]
public sealed class NoShardCostTools
{
    [HarmonyPatch(nameof(ToolItem.ReplenishResource), MethodType.Getter)]
    [HarmonyPostfix]
    public static void IfYouConsumeShardsToReplenishNoYouDont(ref ReplenishResources __result)
    {
        if (__result == ReplenishResources.Shard)
        {
            __result = ReplenishResources.None;
        }
    }
}