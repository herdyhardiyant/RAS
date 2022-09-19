using System;
using Environment.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CentralSystems
{
    public class MouseEventHandler : MonoBehaviour
    {
        public static event Action OnMouseClickObject;
        private bool _isHovering;
        
        private string _interactionText = "";
        private GameObject _hoveredObject;

        private Camera _mainCamera;
        private Mouse _mouse;
        
        private const string INTERACTABLE_TAG = "Interactable";
        private const string PICKUPABLE_TAG = "Pickupable";

        void Awake()
        {
            _mainCamera = Camera.main;
            _mouse = Mouse.current;
            _isHovering = false;
            
            OnMouseClickObject += () => { print(_interactionText); };
        }

        private void Update()
        {
           

        }

        private void MouseClickHoveredObjectHandler()
        {
            if (!_mouse.leftButton.wasPressedThisFrame)
                return;
            _hoveredObject.TryGetComponent<IInteractable>(out var interactableObject);
            
            if(interactableObject == null)
                return;
            
            _interactionText = interactableObject.GetInteractionText();
            OnMouseClickObject?.Invoke();
        }
        
        
        
        
    }
}