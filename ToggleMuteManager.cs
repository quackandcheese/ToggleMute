using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace ToggleMute
{
    public class ToggleMuteManager : MonoBehaviour
    {
        public IngamePlayerSettings playerSettings;
        public GameObject micDisabledImagePrefab;
        public GameObject micDisabledImage;

        public static ToggleMuteManager instance;

        public void Awake()
        { 
            // TODO: Fix bug where you start game muted
            // Maybe bandaid fix, auto unmute in awake method
            instance = this;

            ToggleMuteInputActions.Instance.ToggleMuteKey.performed += OnToggleMuteKeyPressed;
        }


        public void OnDestroy()
        {
            ToggleMuteInputActions.Instance.ToggleMuteKey.performed -= OnToggleMuteKeyPressed;
        }

        private void OnToggleMuteKeyPressed(InputAction.CallbackContext ctx)
        {
            if (!ctx.performed)
                return;
            if (!playerSettings || !StartOfRound.Instance)
                return;
            if (!StartOfRound.Instance.voiceChatModule)
                return;
            if (!Application.isFocused)
                return;

            if (GameNetworkManager.Instance)
            {
                PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;
                if (player && Config.allowMuteInTerminal.Value == false)
                {
                    if (player.inTerminalMenu || player.isTypingChat)
                        return;
                }
            }

            IngamePlayerSettings.Instance.settings.micEnabled = !IngamePlayerSettings.Instance.settings.micEnabled;
            IngamePlayerSettings.Instance.SetMicrophoneEnabled();
            SettingsOption speaker = FindObjectsOfType<SettingsOption>(true).ToList().Find(x => x.name == "SpeakerButton");
            speaker.ToggleEnabledImage(4);
        }

        public void Update()
        {
            if (micDisabledImage != null && playerSettings)
            {
                micDisabledImage.SetActive(!playerSettings.settings.micEnabled);
            }
            
/*            if (!playerSettings || !StartOfRound.Instance)
                return;
            if (!StartOfRound.Instance.voiceChatModule)
                return;

            if (Keyboard.current[Config.toggleMuteKey.Value].wasPressedThisFrame)
            {
                IngamePlayerSettings.Instance.settings.micEnabled = !IngamePlayerSettings.Instance.settings.micEnabled;
                IngamePlayerSettings.Instance.SetMicrophoneEnabled();
                SettingsOption speaker = FindObjectsOfType<SettingsOption>(true).ToList().Find(x => x.name == "SpeakerButton");
                speaker.ToggleEnabledImage(4);
            }
            
            micDisabledImage.SetActive(!playerSettings.settings.micEnabled);*/
        }
    }
}
