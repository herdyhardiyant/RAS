using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    public class PlayerInputMap : MonoBehaviour
    {
        private Keyboard _keyboard;
        private Mouse _mouse;
        
        //TODO: Change to singleton
        //TODO: Update every script that uses this to use the singleton instead
        
        void Awake()
        {
            _keyboard = Keyboard.current;
            _mouse = Mouse.current;
        }

        public bool IsLeftPressed => _keyboard.aKey.isPressed;

        public bool IsRightPressed => _keyboard.dKey.isPressed;

        public bool IsUpPressed => _keyboard.wKey.isPressed;

        public bool IsDownPressed => _keyboard.sKey.isPressed;
        
        public bool IsRunPressed => _keyboard.leftShiftKey.isPressed;
        
        public bool IsInventoryPressed => _keyboard.eKey.wasPressedThisFrame;
        
        public bool IsBackPressed => _keyboard.escapeKey.wasPressedThisFrame;

        public bool IsInteractClicked => _keyboard.fKey.wasPressedThisFrame;
        
    }
}
