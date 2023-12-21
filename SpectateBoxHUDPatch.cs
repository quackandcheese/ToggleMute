using Dissonance;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ToggleMute
{
    [HarmonyPatch(typeof(HUDManager), "UpdateSpectateBoxSpeakerIcons")]
    class SpectateBoxHUDPatch
    {
        static void Postfix(ref HUDManager __instance)
        {
            KeyValuePair<Animator, PlayerControllerB> spectateBox = __instance.spectatingPlayerBoxes.FirstOrDefault(x => x.Value == GameNetworkManager.Instance.localPlayerController);

            if (StartOfRound.Instance.voiceChatModule.IsMuted)
                spectateBox.Key.SetBool("speaking", false);
        }
    }
}
