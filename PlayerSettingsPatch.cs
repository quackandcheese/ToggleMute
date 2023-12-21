using BepInEx.Bootstrap;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ToggleMute
{
    [HarmonyPatch(typeof(IngamePlayerSettings), "Awake")]
    internal class PlayerSettingsPatch
    {
        static void Postfix(ref IngamePlayerSettings __instance)
        {
            if (!__instance.gameObject.TryGetComponent(out ToggleMuteManager _manager))
            {
                ToggleMuteManager muteManager = __instance.gameObject.AddComponent<ToggleMuteManager>();
                muteManager.playerSettings = __instance;
            }
        }
    }
}
