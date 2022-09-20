using Environment.Interfaces;
using EventSystems;
using UnityEngine;

namespace UI.Mouse
{
    public class MouseCursorManipulator : MonoBehaviour
    {
        [SerializeField] private Texture2D _hoverInteractableItemCursorTexture;
        [SerializeField] private Texture2D _hoverPickupItemCursorTexture;
        [SerializeField] private Texture2D _defaultHoverTexture;
        
        void Awake()
        {
            SubscribeMouseHoverEvents();
        }
        
        private void SubscribeMouseHoverEvents()
        {
            MouseHoverEventHandler.OnMouseHoverInteractable += CursorHoverInteractableHandler;
            MouseHoverEventHandler.OnMouseHoverNothing += HoverNothingHandler;
            MouseHoverEventHandler.OnMouseHoverPickupItem += CursorHoverPickupItemHandler;
        }
        
        private void CursorHoverInteractableHandler(IInteractable _)
        {
            Cursor.SetCursor(_hoverInteractableItemCursorTexture, Vector2.zero, CursorMode.Auto);
        }

        private void HoverNothingHandler()
        {
            Cursor.SetCursor(_defaultHoverTexture, Vector2.zero, CursorMode.Auto);
        }

        private void CursorHoverPickupItemHandler(IInteractable _)
        {
            Cursor.SetCursor(_hoverPickupItemCursorTexture, Vector2.zero, CursorMode.Auto);
        }
        
    }
}
