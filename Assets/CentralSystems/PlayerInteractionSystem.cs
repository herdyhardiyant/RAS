using System;
using UnityEngine;

namespace CentralSystems
{
    /// <summary>
    /// Unified communication between player and other GameObject
    /// </summary>
    public static class PlayerInteractionSystem
    {
        /// <summary>
        /// (string interactionText) {}
        /// </summary>
        public static event Action OnPlayerStopInteraction;
        
        /// <summary>
        /// (string interactionText) {}
        /// </summary>
        public static event Action<string> OnPlayerInteract;

        public static void PlayerStartInteract(string interactionText)
        {
           
            OnPlayerInteract?.Invoke(interactionText);
            
        }

        public static void PlayerStopInteraction()
        {
            OnPlayerStopInteraction?.Invoke();
        }
    }
}