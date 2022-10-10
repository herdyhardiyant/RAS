using System;
using Environment.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;
using Controls;

namespace EventSystems
{
    public class MouseClickEventHandler : MonoBehaviour
    {
        public static event Action<IInteractable> OnMouseClickHoveredObject;
        
        private PlayerInputMap _playerInputMap;

        void Awake()
        {
            _playerInputMap = gameObject.AddComponent<PlayerInputMap>();
            MouseHoverEventHandler.OnMouseHoverInteractable += ClickHoveredInteractableObject;
            MouseHoverEventHandler.OnMouseHoverPickupItem += ClickHoveredInteractableObject;
        }

        private void ClickHoveredInteractableObject(IInteractable hoveredObject)
        {
            //TODO Hovered Object run Interact() here
            //TODO Send event notification to gameplay ui with interact text to show interact text in  the UI

            if (_playerInputMap.IsInteractClicked)
            {
                OnMouseClickHoveredObject?.Invoke(hoveredObject);
            }
        }
    }
}