using Better_Company.Abilities;
using HarmonyLib;
using System.Linq;

namespace Better_Company.Patches
{
    [HarmonyPatch(typeof(RoundManager))]
    internal class RoundPatches
    {

        [HarmonyPatch(nameof(RoundManager.LoadNewLevel))]
        [HarmonyPrefix]
        public static void LoadNewLevel(ref SelectableLevel newLevel)
        {
            Better_CompanyPlugin.Log.LogInfo("Better_Company Logs");

            HUDManager.Instance.AddTextToChatOnServer("\n");

            // For each player in the game, activate the "Speed" ability
            var players = StartOfRound.Instance.allPlayerScripts;
            Better_CompanyPlugin.Log.LogInfo(players.Count().ToString());

            foreach (var player in players)
            {

                Better_CompanyPlugin.Log.LogInfo($"LETHAL_COMPANY::: Player: {player.playerSteamId}");
                // Return if the player is not player controlled, or more.
                if (!player.isPlayerControlled && !player.isPlayerDead)
                {
                    return;
                }
                var randomAbility = AbilityManager.GetRandomAbility();
                AbilityManager.ActivateAbility(player, randomAbility.Name);
                HUDManager.Instance.AddTextToChatOnServer(player.playerUsername + " has been given the " + randomAbility.Name);
                player.BroadcastMessage("You have been given the " + randomAbility.Name + " ability!");
                player.BroadcastMessage(randomAbility.Description);
            }
                return;

        }

    
    }
}
