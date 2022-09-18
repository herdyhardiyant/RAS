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
        public static event Action OnMouseClickObject;


        private bool _isHovering;
        
        private string _interactionText = "";
        private GameObject _hoveredObject;

        private Camera _mainCamera;
        private Mouse _mouse;

        void Awake()
        {
            _mainCamera = Camera.main;
            _mouse = Mouse.current;
            _isHovering = false;

            OnMouseHoverInteractable += () => {  };
            OnMouseExitHover += () => {  };
            OnMouseClickObject += () => { print(_interactionText); };
        }

        private void Update()
        {
            if (!_isHovering)
            {
                OnMouseExitHover?.Invoke();
                return;
            }
            
            if (!_hoveredObject)
                return;

            if (!_hoveredObject.CompareTag("Interactable"))
            {
                OnMouseExitHover?.Invoke();
                return;
            }

            OnMouseHoverInteractable?.Invoke();
            
            if (_mouse.leftButton.wasPressedThisFrame)
            {
                _hoveredObject.TryGetComponent<IInteractable>(out var interactableObject);
                _interactionText = interactableObject.GetInteractionText();
                OnMouseClickObject?.Invoke();
            }
            
        }

        private void FixedUpdate()
        {
            var ray = _mainCamera.ScreenPointToRay(_mouse.position.ReadValue());
            if (Physics.Raycast(ray, out var hit))
            {
                _hoveredObject = hit.collider.gameObject;
                _isHovering = true;
            }
            else
            {
                _isHovering = false;
            }
        }
        
        
        
    }
}