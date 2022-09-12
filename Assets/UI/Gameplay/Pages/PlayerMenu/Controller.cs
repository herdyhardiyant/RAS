using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace RAS.UI.Gameplay.Pages.PlayerMenu
{
    [RequireComponent(typeof(UIDocument))]
    public class Controller : MonoBehaviour
    {
        private VisualElement _rootVisualElement;
        
        public enum MenuState
        {
            Crafting,
            Status,
            Inventory,
            Close
        }

        public static event Action OnMenuStateChange;
        private static MenuState _menuState;

        public static void ChangeMenu(MenuState newState)
        {
            _menuState = newState;
            OnMenuStateChange?.Invoke();
        }

        public static MenuState GetCurrentMenuState()
        {
            return _menuState;
        }
        
        void Start()
        {
            _rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
            CloseMenu();
            Manager.OnInventoryButtonClick += InventoryClickHandler;
        }

        private void InventoryClickHandler()
        {
            
            if (_rootVisualElement.visible)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
                ChangeMenu(MenuState.Inventory);
            }
            
        }

        private void CloseMenu()
        {
            _rootVisualElement.visible = false;
            ChangeMenu(MenuState.Close);
        }

        private void OpenMenu()
        {
            _rootVisualElement.visible = true;
        }

        private void OnDisable()
        {
            Manager.OnInventoryButtonClick -= InventoryClickHandler;
        }
    }
}
