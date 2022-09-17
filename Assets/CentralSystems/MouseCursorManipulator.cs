using UnityEngine;

namespace CentralSystems
{
    public class MouseCursorManipulator : MonoBehaviour
    {
        [SerializeField] private Texture2D _hoverInteractableCursorTexture;
        [SerializeField] private Texture2D _hoverPickupItemCursorTexture;
        [SerializeField] private Texture2D _defaultHoverTexture;
        
        void Awake()
        {
            SubscribeMouseHoverEvents();
        }
        
        private void SubscribeMouseHoverEvents()
        {
            MouseEventHandler.OnMouseHoverInteractable += CursorHoverInteractableHandler;
            MouseEventHandler.OnMouseExitHover += ExitHoverHandler;
            MouseEventHandler.OnMouseHoverPickupItem += CursorHoverPickupItemHandler;
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
        
        // Start is called before the first frame update
       

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
