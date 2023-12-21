using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using MonoMod.Cil;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace ToggleMute
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    [BepInProcess("Lethal Company.exe")]
    public class Plugin : BaseUnityPlugin
    {
        public const string ModGUID = "quackandcheese.togglemute";
        public const string ModName = "ToggleMute";
        public const string ModVersion = "1.3.0";

        public static AssetBundle Bundle;

        public static ConfigFile config;

        public static BepInEx.Logging.ManualLogSource logger;


        private void Awake()
        {
            Bundle = QuickLoadAssetBundle("togglemute.assets");
            logger = Logger;
            config = Config;
            ToggleMute.Config.Load();

            Harmony harmony = new Harmony(ModGUID);
            harmony.PatchAll();
            
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }


        #region HELPERS
        public static T FindAsset<T>(string name) where T : UnityEngine.Object
        {
            return Resources.FindObjectsOfTypeAll<T>().ToList().Find(x => x.name == name);
        }

        public static AssetBundle QuickLoadAssetBundle(string assetBundleName)
        {
            string AssetBundlePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), assetBundleName);

            return AssetBundle.LoadFromFile(AssetBundlePath);
        }
        #endregion
    }
}
