using System;

namespace EventSystems
{
    /// <summary>
    /// Unified communication handler between player and other GameObject
    /// </summary>
    public static class PlayerInteractionEventHandler
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