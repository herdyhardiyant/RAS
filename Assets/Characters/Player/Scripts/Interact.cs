using UnityEngine;
using Environment.Interfaces;
using EventSystems;

namespace Characters.Player.Scripts
{

    public class Interact : MonoBehaviour
    {
        
        private void Awake()
        {
            MouseClickEventHandler.OnMouseClickHoveredObject += MouseClickHoveredObjectHandler;
        }
        
        private void MouseClickHoveredObjectHandler(IInteractable hoveredObject)
        {
            hoveredObject.Interact();
            PlayerInteractionEventHandler.PlayerStartInteract(hoveredObject.GetInteractionText());
        }
        
    }
}
