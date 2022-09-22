using UnityEngine;
using Environment.Interfaces;
using EventSystems;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class Interact : MonoBehaviour
    {
        private bool _isPlayerInInteractRange;
        private bool _isInteractionEnable; 
        private string _objectInteractionText;

        private void Awake()
        {
            _isInteractionEnable = true;
            GameplayUIManager.OnOpenInventory += ToggleEnable;
            MouseClickEventHandler.OnMouseClickHoveredObject += MouseClickHoveredObjectHandler;

        }
        
        private void MouseClickHoveredObjectHandler(IInteractable hoveredObject)
        {
            hoveredObject.Interact();
            PlayerInteractionSystem.PlayerStartInteract(hoveredObject.GetInteractionText());
        }
        
        private void ToggleEnable()
        {
            _isInteractionEnable = !_isInteractionEnable;
        }
        
        private void OnDisable()
        {
            GameplayUIManager.OnOpenInventory -= ToggleEnable;
        }
    }
}
