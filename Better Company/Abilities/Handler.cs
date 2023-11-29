using GameNetcodeStuff;
using UnityEngine;

namespace Better_Company.Abilities
{
    public static class Handler
    {
        public abstract class BaseAbility
        {
            public string Name { get; }
            public string Description { get; }
            public Color NameColor { get; }

            protected BaseAbility(string name, string description, Color nameColor)
            {
                Name = name;
                Description = description;
                NameColor = nameColor;
            }

            // Implement the logic for the ability here
            public abstract void ActivateAbility(PlayerControllerB player);
            public abstract void ResetStats(PlayerControllerB player);
        }

        // List of abilities
        public static BaseAbility[] Abilities = new BaseAbility[]
        {
            new Speed(),
            new MightyHauler()
            // Add more abilities here as needed
        };
    }
}
