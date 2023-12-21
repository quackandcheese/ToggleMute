using LethalCompanyInputUtils.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

namespace ToggleMute
{
    public class ToggleMuteInputActions : LcInputActions
    {
        public static ToggleMuteInputActions Instance = new();

        [InputAction("<Keyboard>/m", Name = "Toggle Mute", ActionType = InputActionType.Button)]
        public InputAction ToggleMuteKey { get; set; }
    }
}
