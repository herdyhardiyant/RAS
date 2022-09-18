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
        
        private const string INTERACTABLE_TAG = "Interactable";

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
            if (IsMouseHoveringInteractableObject())
            {
                OnMouseHoverInteractable?.Invoke();
                MouseClickHoveredObjectHandler();
            }
            else
            {
                OnMouseExitHover?.Invoke();
            }

        }

        private void FixedUpdate()
        {
            MouseRaycast();
        }

        private bool IsMouseHoveringInteractableObject()
        {
            if (!_isHovering)
                return false;

            if (!_hoveredObject)
                return false;

            if (!_hoveredObject.CompareTag(INTERACTABLE_TAG))
                return false;

            return true;
        }

        private void MouseClickHoveredObjectHandler()
        {
            if (_mouse.leftButton.wasPressedThisFrame)
            {
                _hoveredObject.TryGetComponent<IInteractable>(out var interactableObject);
                _interactionText = interactableObject.GetInteractionText();
                OnMouseClickObject?.Invoke();
            }
        }
        
        private void MouseRaycast()
        {
            var ray = _mainCamera.ScreenPointToRay(_mouse.position.ReadValue());
            if (Physics.Raycast(ray, out var hit))
            {
                RaycastHitHandler(hit);
            }
            else
            {
                RaycastNotHitHandler();
            }
        }

        private void RaycastHitHandler(RaycastHit hit)
        {
            _hoveredObject = hit.collider.gameObject;
            _isHovering = true;
        }

        private void RaycastNotHitHandler()
        {
            _isHovering = false;

        }
        
        
        
        
        
    }
}