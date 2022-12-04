// using UnityEngine;
// using UnityEngine.InputSystem;

// namespace Controls
// {
//     public class PlayerInputMap : MonoBehaviour
//     {
//         public Keyboard _keyboard;
//         public Mouse _mouse;
        
//         //TODO: Change to singleton
//         //TODO: Update every script that uses this to use the singleton instead
        
//         void  Awake()
//         {
//             _keyboard = Keyboard.current;
//             _mouse = Mouse.current;
            
//             IsDebugKeyPress = _keyboard.spaceKey.isPressed;
//             IsLeftPress = _keyboard.aKey.isPressed;
//             IsRightPress = _keyboard.dKey.isPressed;
//             IsUpPress = _keyboard.wKey.isPressed;
//             IsDownPress = _keyboard.sKey.isPressed;
//             IsRunPress = _keyboard.leftShiftKey.isPressed;
//             IsInventoryPress = _keyboard.eKey.wasPressedThisFrame;
//             IsBackPress = _keyboard.escapeKey.wasPressedThisFrame;
//             IsInteractClick = _keyboard.fKey.wasPressedThisFrame;
//         }

//         public bool IsDebugKeyPressed => IsDebugKeyPress;
//         public bool IsLeftPressed => IsLeftPress;
//         public bool IsRightPressed => IsRightPress;
//         public bool IsUpPressed => IsUpPress;
//         public bool IsDownPressed => IsDownPress;
//         public bool IsRunPressed => IsRunPress;
//         public bool IsInventoryPressed => IsInventoryPress;
//         public bool IsBackPressed => IsBackPress;
//         public bool IsInteractClicked => IsInteractClick; 
//         protected bool IsDebugKeyPress;
//         protected bool IsLeftPress;
//         protected bool IsRightPress;
//         protected bool IsUpPress;
//         protected bool IsDownPress;
//         protected bool IsRunPress;
//         protected bool IsInventoryPress;
//         protected bool IsBackPress;
//         protected bool IsInteractClick;
//     }
// }
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

        public bool IsDebugKeyPressed => _keyboard.spaceKey.isPressed;

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