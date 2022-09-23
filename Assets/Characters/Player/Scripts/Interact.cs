using UnityEngine;
using Environment.Interfaces;
using EventSystems;

namespace Characters.Player.Scripts
{

    public class Interact : MonoBehaviour
    {
        private bool _isPlayerInInteractRange;
        private bool _isInteractionEnable; 
        private string _objectInteractionText;

        private void Awake()
        {
            _isInteractionEnable = true;
            GameplayUIEventHandler.OnOpenInventory += ToggleEnable;
            MouseClickEventHandler.OnMouseClickHoveredObject += MouseClickHoveredObjectHandler;

        }
        
        private void MouseClickHoveredObjectHandler(IInteractable hoveredObject)
        {
            hoveredObject.Interact();
            PlayerInteractionEventHandler.PlayerStartInteract(hoveredObject.GetInteractionText());
        }
        
        private void ToggleEnable()
        {
            _isInteractionEnable = !_isInteractionEnable;
        }
        
        private void OnDisable()
        {
            GameplayUIEventHandler.OnOpenInventory -= ToggleEnable;
        }
    }
}
