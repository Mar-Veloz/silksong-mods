using BepInEx;
using HarmonyLib;

namespace better_silk_hearts;

[BepInAutoPlugin(id: "org.mar_veloz.silksong.better_silk_hearts")]
public partial class Plugin : BaseUnityPlugin
{
    private const int SilkRegenMaxMultiplier = 3;

    private void Awake()
    {
        Harmony.CreateAndPatchAll(typeof(Plugin));

        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }

    [HarmonyPatch(typeof(PlayerData), nameof(PlayerData.CurrentSilkRegenMax), MethodType.Getter)]
    [HarmonyPrefix]
    private static void CurrentSilkRegenMaxReplacement(ref int __result, ref bool __runOriginal, PlayerData __instance)
    {
        __result = __instance.silkRegenMax * SilkRegenMaxMultiplier;

        // Skip running the original method
        __runOriginal = false;
    }
}