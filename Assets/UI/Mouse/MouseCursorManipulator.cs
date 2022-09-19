using CentralSystems;
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
            MouseHoverEventHandler.OnMouseExitHover += ExitHoverHandler;
            MouseHoverEventHandler.OnMouseHoverPickupItem += CursorHoverPickupItemHandler;
        }
        
        private void CursorHoverInteractableHandler()
        {
            Cursor.SetCursor(_hoverInteractableItemCursorTexture, Vector2.zero, CursorMode.Auto);
        }

        private void ExitHoverHandler()
        {
            Cursor.SetCursor(_defaultHoverTexture, Vector2.zero, CursorMode.Auto);
        }

        private void CursorHoverPickupItemHandler()
        {
            Cursor.SetCursor(_hoverPickupItemCursorTexture, Vector2.zero, CursorMode.Auto);
        }
        
    }
}
