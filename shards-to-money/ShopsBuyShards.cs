using HarmonyLib;

namespace shards_to_money;

[HarmonyPatch(typeof(ShopItem))]
public sealed class ShopsBuyShards
{
    private const int ShardCost = 140;

    [HarmonyPatch(nameof(ShopItem.CurrencyType), MethodType.Getter)]
    [HarmonyPostfix]
    public static void UpdateItemCurrencyType(ref ShopItem __instance, ref CurrencyType __result)
    {
        if (__instance.Item.GetName() == "Rosary_Set_Small")
        {
            __result = CurrencyType.Shard;
        }
    }

    [HarmonyPatch(nameof(ShopItem.Cost), MethodType.Getter)]
    [HarmonyPostfix]
    public static void UpdateItemCost(ref ShopItem __instance, ref int __result)
    {
        if (__instance.Item.GetName() == "Rosary_Set_Small")
        {
            __result = ShardCost;
        }
    }
}