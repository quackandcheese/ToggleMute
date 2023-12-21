using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ToggleMute
{
    [HarmonyPatch(typeof(HUDManager), "Awake")]
    class HUDPatch
    {
        static void Postfix()
        {
            ToggleMuteManager muteManager = ToggleMuteManager.instance;
            muteManager.micDisabledImagePrefab = Plugin.Bundle.LoadAsset<GameObject>("Assets/ToggleMute/MicDisabled.prefab");
            Transform toggleMuteUI = new GameObject("ToggleMuteUI").transform;
            toggleMuteUI.SetParent(HUDManager.Instance.HUDContainer.transform.parent, false);

            muteManager.micDisabledImage = GameObject.Instantiate(muteManager.micDisabledImagePrefab, Vector3.zero, Quaternion.identity);
            muteManager.micDisabledImage.transform.SetParent(toggleMuteUI, false);
            muteManager.micDisabledImage.transform.localPosition = new Vector3(-420f, -230f, 6.5f);

            muteManager.micDisabledImage.SetActive(false);
        }
    }
}
