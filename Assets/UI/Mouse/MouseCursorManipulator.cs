using Environment.Interfaces;
using EventSystems;
using UnityEngine;

namespace UI.Mouse
{
    public class MouseCursorManipulator : MonoBehaviour
    {
        [SerializeField] private Texture2D _hoverInteractableItemCursorTexture;
        [SerializeField] private Texture2D _hoverPickupItemCursorTexture;
        [SerializeField] private Texture2D _defaultCursorTexture;
        [SerializeField] private Texture2D _cursorOutOfMaxRange;

        void Awake()
        {
            SubscribeMouseHoverEvents();
        }

        private void SubscribeMouseHoverEvents()
        {
            MouseHoverEventHandler.OnMouseHoverInteractable += CursorHoverInteractableHandler;
            MouseHoverEventHandler.OnMouseHoverNothing += HoverNothingHandler;
            MouseHoverEventHandler.OnMouseHoverPickupItem += CursorHoverPickupItemHandler;
            MouseHoverEventHandler.OnMousePassMaxRange += MousePassMaxRangeHandler;
        }

        private void MousePassMaxRangeHandler() =>
            Cursor.SetCursor(_cursorOutOfMaxRange, Vector2.zero, CursorMode.Auto);

        private void CursorHoverInteractableHandler(IInteractable _)
        {
            Cursor.SetCursor(_hoverInteractableItemCursorTexture, Vector2.zero, CursorMode.Auto);
        }

        private void HoverNothingHandler()
        {
            Cursor.SetCursor(_defaultCursorTexture, Vector2.zero, CursorMode.Auto);
        }

        private void CursorHoverPickupItemHandler(IInteractable _)
        {
            Cursor.SetCursor(_hoverPickupItemCursorTexture, Vector2.zero, CursorMode.Auto);
        }
    }
}