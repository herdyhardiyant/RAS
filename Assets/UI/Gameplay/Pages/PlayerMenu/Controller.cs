using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace RAS.UI.Gameplay.Pages.PlayerMenu
{
    [RequireComponent(typeof(UIDocument))]
    public class Controller : MonoBehaviour
    {
        private VisualElement _rootVisualElement;

        public static event Action OnMenuStateChange;
        private static MenuRouting.MenuStates _menuStates;

        public static void ChangeMenu(MenuRouting.MenuStates newStates)
        {
            _menuStates = newStates;
            OnMenuStateChange?.Invoke();
        }

        public static MenuRouting.MenuStates CurrentMenuState
        {
            get => _menuStates;
            set
            {
                _menuStates = value;
                OnMenuStateChange?.Invoke();
            }
        }

        public static MenuRouting.MenuStates GetCurrentMenuState()
        {
            return _menuStates;
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
                CurrentMenuState = MenuRouting.MenuStates.Inventory;
            }
        }

        private void CloseMenu()
        {
            _rootVisualElement.visible = false;
            CurrentMenuState = MenuRouting.MenuStates.Close;
        }

        private void OpenMenu()
        {
            _rootVisualElement.visible = true;
        }

        private void OnDisable()
        {
            Manager.OnInventoryButtonClick -= InventoryClickHandler;
        }

        public class MenuStates
        {
        }
    }
}