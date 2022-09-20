using System;
using Environment.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EventSystems
{
    public class MouseHoverEventHandler : MonoBehaviour
    {
        /// <summary>
        /// (hoveredInteractableObject) {}
        /// </summary>
        public static event Action<IInteractable> OnMouseHoverInteractable;
        public static event Action OnMouseHoverPickupItem;
        public static event Action OnMouseHoverNothing;
        
        private const string INTERACTABLE_TAG = "Interactable";
        private const string PICKUPABLE_TAG = "Pickupable";
        private bool _isHovering;
        private GameObject _hoveredObject;
        private Camera _mainCamera;
        private Mouse _mouse;
        
        void Awake()
        {
            _isHovering = false;
            _mainCamera = Camera.main;
            _mouse = Mouse.current;
        }

        private void Update()
        {
            if (!_isHovering)
            {
                OnMouseHoverNothing?.Invoke();
                return;
            }

            if (!_hoveredObject)
            {
                OnMouseHoverNothing?.Invoke();
                return;
            }

            if (_hoveredObject.CompareTag(INTERACTABLE_TAG))
            {
                InteractableObjectHoverHandler();
            }
            else if (_hoveredObject.CompareTag(PICKUPABLE_TAG))
            {
                OnMouseHoverPickupItem?.Invoke();
            }
            else
            {
                OnMouseHoverNothing?.Invoke();
            }
        }

        private void FixedUpdate()
        {
            MouseRaycast();
        }

        private void InteractableObjectHoverHandler()
        {
            _hoveredObject.TryGetComponent<IInteractable>(out var hoveredInteractableObject);
            if(hoveredInteractableObject == null) return;
            OnMouseHoverInteractable?.Invoke(hoveredInteractableObject);
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
