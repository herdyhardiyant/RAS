using System;
using Environment.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CentralSystems
{
    public class MouseHoverEventHandler : MonoBehaviour
    {
        // TODO Apply Open-Closed Principle
        public static event Action OnMouseHoverInteractable;
        public static event Action OnMouseHoverPickupItem;
        public static event Action OnMouseExitHover;
        
        private const string INTERACTABLE_TAG = "Interactable";
        private const string PICKUPABLE_TAG = "Pickupable";
        private bool _isHovering;
        private GameObject _hoveredObject;
        private Camera _mainCamera;
        private Mouse _mouse;
        
        void Awake()
        {
            _isHovering = false;
        }
        
        void Start()
        {
            _mainCamera = Camera.main;
            _mouse = Mouse.current;
        }
        
        private void Update()
        {
            if (!_isHovering)
            {
                OnMouseExitHover?.Invoke();
                return;
            }

            if (!_hoveredObject)
            {
                OnMouseExitHover?.Invoke();
                return;
            }

            if (_hoveredObject.CompareTag(INTERACTABLE_TAG))
            {
                OnMouseHoverInteractable?.Invoke();
            }
            else if (_hoveredObject.CompareTag(PICKUPABLE_TAG))
            {
                OnMouseHoverPickupItem?.Invoke();
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
