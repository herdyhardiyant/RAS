using System;

namespace RAS.CentralSystems
{
    /// <summary>
    /// This class is used to sending data between player and UI gameplay
    /// </summary>
    public static class PlayerInteractionUIConnector
    {
        public static event Action<string> OnPlayerSendInteractionText;
        public static event Action OnPlayerStopInteraction;
        
        public static void ShowInteractText(string text)
        {
            OnPlayerSendInteractionText?.Invoke(text);
        }

        public static void PlayerStopInteraction()
        {
            OnPlayerStopInteraction?.Invoke();
        }
        
    }
}
