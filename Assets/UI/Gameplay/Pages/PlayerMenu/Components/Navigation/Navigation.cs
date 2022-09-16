using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.Pages.PlayerMenu.Components.Navigation
{
    [RequireComponent(typeof(UIDocument))]
    public class Navigation : MonoBehaviour
    {
        private VisualElement _rootMenuElement;

        private Button _craftingTab;
        private Button _inventoryTab;
        private Button _statusTab;

        private Button _currentActiveTabButton;

        private static class TabNames
        {
            public const string CRAFTING = "crafting-tab";
            public const string INVENTORY = "inventory-tab";
            public const string STATUS = "status-tab";
        }

        private const string CURRENT_TAB_STYLE_CLASS = "current-tab";

        private void Awake()
        {
            _rootMenuElement = GetComponent<UIDocument>().rootVisualElement;
        }

        void Start()
        {
            QueryTabs();
            SetupTabsEvent();
            SetNewCurrentActiveTabButton();
            MenuStateStorage.OnMenuStateChange += MenuStateChangeHandler;
        }

        private void OnDisable()
        {
            MenuStateStorage.OnMenuStateChange -= MenuStateChangeHandler;
        }

        private void QueryTabs()
        {
            _craftingTab = _rootMenuElement.Q<Button>(TabNames.CRAFTING);
            _inventoryTab = _rootMenuElement.Q<Button>(TabNames.INVENTORY);
            _statusTab = _rootMenuElement.Q<Button>(TabNames.STATUS);
        }

        private void SetupTabsEvent()
        {
            _craftingTab.clicked += CraftingTabClickHandler;
            _inventoryTab.clicked += InventoryTabClickHandler;
            _statusTab.clicked += StatusTabClickHandler;
        }

        private void CraftingTabClickHandler()
        {
            MenuStateStorage.CurrentMenuState = MenuStateStorage.MenuStates.Crafting;
        }

        private void StatusTabClickHandler()
        {
            MenuStateStorage.CurrentMenuState = MenuStateStorage.MenuStates.Status;
        }

        private void InventoryTabClickHandler()
        {
            MenuStateStorage.CurrentMenuState = MenuStateStorage.MenuStates.Inventory;
        }

        private void MenuStateChangeHandler()
        {
            ClearCurrentActiveTabButton();
            SetNewCurrentActiveTabButton();
        }

        private void ClearCurrentActiveTabButton()
        {
            _currentActiveTabButton.RemoveFromClassList(CURRENT_TAB_STYLE_CLASS);
        }

        private void SetNewCurrentActiveTabButton()
        {
            var newState = MenuStateStorage.CurrentMenuState;

            switch (newState)
            {
                case MenuStateStorage.MenuStates.Crafting:
                    _craftingTab.AddToClassList(CURRENT_TAB_STYLE_CLASS);
                    _currentActiveTabButton = _craftingTab;
                    break;
                case MenuStateStorage.MenuStates.Inventory:
                    _inventoryTab.AddToClassList(CURRENT_TAB_STYLE_CLASS);
                    _currentActiveTabButton = _inventoryTab;
                    break;
                case MenuStateStorage.MenuStates.Status:
                    _statusTab.AddToClassList(CURRENT_TAB_STYLE_CLASS);
                    _currentActiveTabButton = _statusTab;
                    break;
            }
        }
    }
}