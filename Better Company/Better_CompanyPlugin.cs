using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using Better_Company.Abilities;
using GameNetcodeStuff;
using HarmonyLib;
using LC_API;
using System.Linq;

namespace Better_Company
{
    // TODO Review this file and update to your own requirements.

    [BepInPlugin(MyGUID, PluginName, VersionString)]
    //[BepInDependency(LC_API.MyPluginInfo.PLUGIN_GUID)]
    public class Better_CompanyPlugin : BaseUnityPlugin
    {
        private const string MyGUID = "com.lukma.Better_Company";
        private const string PluginName = "Better_Company";
        private const string VersionString = "1.0.0";
        public static string FloatExampleKey = "Float Example Key";
        public static string IntExampleKey = "Int Example Key";
        public static string KeyboardShortcutExampleKey = "Recall Keyboard Shortcut";

        public static ConfigEntry<float> FloatExample;
        public static ConfigEntry<int> IntExample;
        public static ConfigEntry<KeyboardShortcut> KeyboardShortcutExample;

        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        private void Awake()
        {
            

            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loading...");
            Harmony.PatchAll();
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loaded.");

            AbilityManager.InitializeAbilities();

            Log = Logger;
        }

        private void Update()
        {
            /*if (Better_CompanyPlugin.KeyboardShortcutExample.Value.IsDown())
            {
                Logger.LogInfo("Keypress detected!");
            }*/


        }

        
    }
}
