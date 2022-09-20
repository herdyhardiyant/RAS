using System;
using Environment.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EventSystems
{
    public class MouseClickEventHandler : MonoBehaviour
    {

        public static event Action<IInteractable> OnMouseClickHoveredObject; 

        private Mouse _mouse;
        void Awake()
        {
            _mouse = Mouse.current;
            MouseHoverEventHandler.OnMouseHoverInteractable += ClickHoveredInteractableObject;
            MouseHoverEventHandler.OnMouseHoverPickupItem += ClickHoveredPickupItem;
        }

        private void ClickHoveredInteractableObject(IInteractable hoveredObject)
        {
            if(_mouse.leftButton.wasPressedThisFrame)
            {
                OnMouseClickHoveredObject?.Invoke(hoveredObject);
            }
        }
        
        private void ClickHoveredPickupItem(IInteractable hoveredPickupObject)
        {
            if(_mouse.leftButton.wasPressedThisFrame)
            {
                OnMouseClickHoveredObject?.Invoke(hoveredPickupObject);
            }
        }


    }
}
