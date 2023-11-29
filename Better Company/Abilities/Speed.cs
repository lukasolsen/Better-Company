using GameNetcodeStuff;
using UnityEngine;

namespace Better_Company.Abilities
{
    public class Speed : Handler.BaseAbility
    {
        public Speed() : base("Speed Ability", "Increase movement speed", Color.blue)
        {
        }

        public override void ActivateAbility(PlayerControllerB player)
        {
            // Implement the specific logic for this ability
            // For example, you might want to increase the player's speed
            Better_CompanyPlugin.Log.LogInfo($"Player movementSpeed: {player.movementSpeed} - Player sprintTime: {player.sprintTime} - PlayerJumpForce: {player.jumpForce} - PlayerClimbSpeed: {player.climbSpeed}");
            player.movementSpeed = 5.5f;
            player.sprintTime = 13f;
            player.jumpForce = 13.7f;
            player.climbSpeed = 4f;
            Better_CompanyPlugin.Log.LogInfo($"Player movementSpeed: {player.movementSpeed} - Player sprintTime: {player.sprintTime} - PlayerJumpForce: {player.jumpForce} - PlayerClimbSpeed: {player.climbSpeed}");
        }

        public override void ResetStats(PlayerControllerB player)
        {
            player.movementSpeed = 4.6f;
            player.sprintTime = 11f;
            player.jumpForce = 13f;
            player.climbSpeed = 3f;
        }
    }
}
