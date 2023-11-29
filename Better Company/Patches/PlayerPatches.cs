using GameNetcodeStuff;
using HarmonyLib;

namespace Better_Company.Patches
{
    // TODO Review this file and update to your own requirements, or remove it altogether if not required

    /// <summary>
    /// Sample Harmony Patch class. Suggestion is to use one file per patched class
    /// though you can include multiple patch classes in one file.
    /// Below is included as an example, and should be replaced by classes and methods
    /// for your mod.
    /// </summary>
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerPatches
    {
        /// <summary>
        /// Patches the Player Awake method with prefix code.
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPatch(nameof(PlayerControllerB.DamagePlayer))]
        [HarmonyPrefix]
        public static bool DamagePlayer_Prefix(PlayerControllerB __instance)
        {
            Better_CompanyPlugin.Log.LogInfo("In Player Awake method Prefix.");
            __instance.health = 100;
            return true;
        }

        /// <summary>
        /// Patches the Player Awake method with postfix code.
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPatch(nameof(PlayerControllerB.DamagePlayer))]
        [HarmonyPostfix]
        public static void DamagePlayer_Postfix(PlayerControllerB __instance)
        {
            Better_CompanyPlugin.Log.LogInfo("In Player Awake method Postfix.");
            __instance.health = 100;
            LC_API.ServerAPI.Networking.Broadcast("Players current health ---->", "Better_Company");
            Better_CompanyPlugin.Log.LogInfo("Players current health ----> " +  __instance.health);
        }
    }
}