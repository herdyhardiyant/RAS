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

        private Mouse _mouse;
        private PlayerInputMap _playerInputMap;
        void Awake()
        {
            _mouse = Mouse.current;
            _playerInputMap = gameObject.AddComponent<PlayerInputMap>();
            MouseHoverEventHandler.OnMouseHoverInteractable += ClickHoveredInteractableObject;
            MouseHoverEventHandler.OnMouseHoverPickupItem += ClickHoveredInteractableObject;
        }

        private void ClickHoveredInteractableObject(IInteractable hoveredObject)
        {
            if(_playerInputMap.IsInteractClicked)
            {
                OnMouseClickHoveredObject?.Invoke(hoveredObject);
            }
        }


    }
}
