using System;
using Environment.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CentralSystems
{
    public class MouseEventHandler : MonoBehaviour
    {
        public static event Action OnMouseHoverInteractable;
        //TODO Create pickupable item
        public static event Action OnMouseHoverPickupItem;
        public static event Action OnMouseExitHover;
        
        private Camera _mainCamera;
        private Mouse _mouse;
        void Awake()
        {
            _mainCamera = Camera.main;
            _mouse = Mouse.current;
            
        }
        private void FixedUpdate()
        {
            var ray = _mainCamera.ScreenPointToRay(_mouse.position.ReadValue());
            if (Physics.Raycast(ray, out var hit))
            {
                var hitObject = hit.collider.gameObject;
                if (hitObject.TryGetComponent<IInteractable>(out var _))
                {
                    OnMouseHoverInteractable?.Invoke();
                }
                else
                {
                    OnMouseExitHover?.Invoke();
                }
            }
            
        }
        
        // Start is called before the first frame update
        

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
