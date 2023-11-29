using Better_Company.Abilities;
using HarmonyLib;
using System.Linq;

namespace Better_Company.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartOfRoundPatches
    {

        [HarmonyPatch(nameof(StartOfRound.EndGameServerRpc))]
        [HarmonyPrefix]
        public static void EndGameServerRpc()
        {
            // For each player in the game, activate the "Speed" ability
            var players = StartOfRound.Instance.allPlayerScripts;

            foreach (var player in players)
            {

                Better_CompanyPlugin.Log.LogInfo($"LETHAL_COMPANY::: Player: {player.playerSteamId}");
                // Return if the player is not player controlled, or more.
                if (!player.isPlayerControlled && !player.isPlayerDead)
                {
                    return;
                }
                AbilityManager.ResetStats(player);
            }
            return;

        }   
    }
}
