using GameNetcodeStuff;
using System.Linq;
using UnityEngine;

namespace Better_Company.Abilities
{
    public static class AbilityManager
    {
        // Initialize all abilities
        public static void InitializeAbilities()
        {
            foreach (var ability in Handler.Abilities)
            {
                Debug.Log($"Initializing ability: {ability.Name}");
            }

            //LC_API.ServerAPI.Networking.Broadcast("Initialized abilities", "Better_Company");
        }

        // Activate a specific ability by name
        public static void ActivateAbility(PlayerControllerB player, string abilityName)
        {
            var ability = GetAbilityByName(abilityName);
            if (ability != null)
            {
                ability.ActivateAbility(player);
            }
            else
            {
                Debug.LogWarning($"Ability not found: {abilityName}");
            }
        }

        public static void ResetStats(PlayerControllerB player)
        {
            foreach (var ability in Handler.Abilities)
            {
                ability.ResetStats(player);
            }
        }

        public static Handler.BaseAbility GetRandomAbility()
        {
            return Handler.Abilities[Random.Range(0, Handler.Abilities.Length)];
        }

        // Get an ability by name
        private static Handler.BaseAbility GetAbilityByName(string abilityName)
        {
            return Handler.Abilities.FirstOrDefault(a => a.Name == abilityName);
        }
    }
}
