using HarmonyLib;

namespace shards_to_money;

// This sucks, but in order to do what I actually want I probably need an ItemChanger for Silksong
[HarmonyPatch(typeof(ShopItem))]
internal sealed class ShopsBuyShards
{
    private const int ShardCost = 140;

    [HarmonyPatch(nameof(ShopItem.CurrencyType), MethodType.Getter)]
    [HarmonyPostfix]
    public static void UpdateItemCurrencyType(ShopItem __instance, ref CurrencyType __result)
    {
        if (__instance.Item?.GetName() == "Rosary_Set_Small")
        {
            __result = CurrencyType.Shard;
        }
    }

    [HarmonyPatch(nameof(ShopItem.Cost), MethodType.Getter)]
    [HarmonyPostfix]
    public static void UpdateItemCost(ShopItem __instance, ref int __result)
    {
        if (__instance.Item?.GetName() == "Rosary_Set_Small")
        {
            __result = ShardCost;
        }
    }
}