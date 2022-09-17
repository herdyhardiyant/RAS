using System;
using Environment.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;


namespace CentralSystems
{
    public class MouseHandler : MonoBehaviour
    {
        // TODO split this class to MouseCursorManipulator and MouseEventHandler
        [SerializeField] private Texture2D _hoverInteractableCursorTexture;
        [SerializeField] private Texture2D _hoverPickupItemCursorTexture;
        [SerializeField] private Texture2D _defaultHoverTexture;
        private Camera _mainCamera;
        private Mouse _mouse;

        private static event Action OnMouseHoverInteractable;
        private static event Action OnMouseHoverPickupItem;
        private static event Action OnMouseExitHover;

        public static void MouseHoverInteractable()
        {
            OnMouseHoverInteractable?.Invoke();
        }

        public static void MouseHoverPickupItem()
        {
            OnMouseHoverPickupItem?.Invoke();
        }

        public static void MouseExitHover()
        {
            OnMouseExitHover?.Invoke();
        }

        private void Awake()
        {
            _mainCamera = Camera.main;
            _mouse = Mouse.current;
            SubscribeMouseHoverEvents();
        }

        private void SubscribeMouseHoverEvents()
        {
            OnMouseHoverInteractable += CursorHoverInteractableHandler;
            OnMouseExitHover += ExitHoverHandler;
            OnMouseHoverPickupItem += CursorHoverPickupItemHandler;
        }

        private void CursorHoverInteractableHandler()
        {
            Cursor.SetCursor(_hoverInteractableCursorTexture, Vector2.zero, CursorMode.Auto);
        }

        private void ExitHoverHandler()
        {
            Cursor.SetCursor(_defaultHoverTexture, Vector2.zero, CursorMode.Auto);
        }

        private void CursorHoverPickupItemHandler()
        {
            Cursor.SetCursor(_hoverPickupItemCursorTexture, Vector2.zero, CursorMode.Auto);
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
    }
}