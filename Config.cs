using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ToggleMute
{
    public class Config
    {
        public static void Load()
        {
            Config.allowMuteInTerminal = Plugin.config.Bind<bool>("General", "Allow Mute In Terminal", false, "Will you be able to use the toggle mute hotkey while in the terminal or while typing in chat?");
        }

        public static ConfigEntry<bool> allowMuteInTerminal;
    }
}