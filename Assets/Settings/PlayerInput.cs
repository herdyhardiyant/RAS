using UnityEngine;
using UnityEngine.InputSystem;

namespace Settings
{
    public class PlayerInput : MonoBehaviour
    {
        private Keyboard _keyboard;
        
        void Awake()
        {
            _keyboard = Keyboard.current;
        }

        public bool IsLeftPressed => _keyboard.aKey.isPressed;

        public bool IsRightPressed => _keyboard.dKey.isPressed;

        public bool IsUpPressed => _keyboard.wKey.isPressed;

        public bool IsDownPressed => _keyboard.sKey.isPressed;
        
        public bool IsRunPressed => _keyboard.leftShiftKey.isPressed;
        
        public bool IsInventoryPressed => _keyboard.eKey.wasPressedThisFrame;
        
        public bool IsBackPressed => _keyboard.escapeKey.wasPressedThisFrame;
        
        public bool IsInteractPressed => _keyboard.fKey.wasPressedThisFrame;
        
        
        
    }
}
