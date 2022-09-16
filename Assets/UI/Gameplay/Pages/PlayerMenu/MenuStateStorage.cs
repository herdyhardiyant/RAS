using System;

namespace UI.Gameplay.Pages.PlayerMenu
{
    public static class MenuStateStorage
    {
        private static MenuStates _currentState;
        public static event Action OnMenuStateChange;

        public enum MenuStates
        {
            Crafting,
            Status,
            Inventory
        }

        public static MenuStates CurrentMenuState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                OnMenuStateChange?.Invoke();
            }
        }
    }
}