using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Controls
{
public class Player2InputMap : PlayerInputMap
    {
        // new public bool IsLeftPressed => _keyboard.leftArrowKey.isPressed;
        // new public bool IsRightPressed => _keyboard.rightArrowKey.isPressed;
        // new public bool IsUpPressed => _keyboard.upArrowKey.isPressed;
        // new public bool IsDownPressed => _keyboard.downArrowKey.isPressed;
        // new public bool IsRunPressed => _keyboard.rightShiftKey.isPressed;
        // new public bool IsInteractClicked => _keyboard.slashKey.wasPressedThisFrame;
       void Start()
        {
            print("gantiinputplayer2");
            IsDebugKeyPress = _keyboard.spaceKey.isPressed;
            IsLeftPress = _keyboard.leftArrowKey.isPressed;
            IsRightPress = _keyboard.rightArrowKey.isPressed;
            IsUpPress = _keyboard.upArrowKey.isPressed;
            IsDownPress = _keyboard.downArrowKey.isPressed;
            IsRunPress = _keyboard.rightCtrlKey.isPressed;
            IsInventoryPress = _keyboard.eKey.wasPressedThisFrame;
            IsBackPress = _keyboard.escapeKey.wasPressedThisFrame;
            IsInteractClick = _keyboard.rightShiftKey.wasPressedThisFrame;
        }
    }
}
