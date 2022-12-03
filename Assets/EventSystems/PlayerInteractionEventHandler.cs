using System;

namespace EventSystems
{
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

        // TODO Use timer to call this after a certain amount of time
        public static void PlayerStopInteraction()
        {
            //TODO Use this function to remove interaction text
            OnPlayerStopInteraction?.Invoke();
        }
    }
}