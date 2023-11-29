using GameNetcodeStuff;
using UnityEngine;

namespace Better_Company.Abilities
{
    public class MightyHauler : Handler.BaseAbility
    {
        public MightyHauler() : base("Mighty Hauler", "Increased carrying capacity, allowing the player to gather and transport more scrap in a single trip.", Color.blue)
        {
        }

        public override void ActivateAbility(PlayerControllerB player)
        {
            // Implement the specific logic for this ability
            // For example, you might want to increase the player's speed
            Better_CompanyPlugin.Log.LogInfo($"Player grabDistance: {player.grabDistance} - Player throwPower: {player.throwPower} - Player health: {player.health}");
            player.grabDistance = 7f;
            player.throwPower = 20f;
            player.health = 150;
            Better_CompanyPlugin.Log.LogInfo($"Player grabDistance: {player.grabDistance} - Player throwPower: {player.throwPower} - Player health: {player.health}");
        }

        public override void ResetStats(PlayerControllerB player)
        {
            player.grabDistance = 5f;
            player.throwPower = 17f;
            player.health = 100;
        }
    }
}
