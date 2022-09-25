
using UnityEngine;

namespace Environment.Interfaces
{
    
    public interface IInteractable
    {
        
        /// <summary>
        /// Player action after pressing the interact action
        /// </summary>
        void Interact();
        
        /// <summary>
        /// Get Player speech text about the object
        /// </summary>
        string GetInteractionText();
        
        Vector3 GetInteractionWorldPosition();

    }
}
