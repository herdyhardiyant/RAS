using UI.Gameplay.PlayerMenu.Components.MenuWindow;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.PlayerMenu.Components.Navigation
{
    [RequireComponent(typeof(UIDocument))]
    public class NavigationManipulator : MonoBehaviour
    {
        private VisualElement _rootInventoryElement;

        private Button _craftingTab;
        private Button _inventoryTab;
        private Button _statusTab;

        private Button _currentActiveTabButton;

        private static class TabNames
        {
            public const string Crafting = "crafting-tab";
            public const string Inventory = "inventory-tab";
            public const string Status = "status-tab";
        }

        private const string CurrentTabStyleClass = "current-tab";

        private void Awake()
        {
            MenuState.OnMenuStateChange += SetActiveTab;
            _rootInventoryElement = GetComponent<UIDocument>().rootVisualElement;
            QueryTabs();
            SubscribeTabsEvent();
        }

        void Start()
        {
            SetNewCurrentActiveTabButton();
        }

        private void OnDisable()
        {
            MenuState.OnMenuStateChange -= SetActiveTab;
        }

        private void QueryTabs()
        {
            _craftingTab = _rootInventoryElement.Q<Button>(TabNames.Crafting);
            _inventoryTab = _rootInventoryElement.Q<Button>(TabNames.Inventory);
            _statusTab = _rootInventoryElement.Q<Button>(TabNames.Status);
        }

        private void SubscribeTabsEvent()
        {
            _craftingTab.clicked += CraftingTabClickHandler;
            _inventoryTab.clicked += InventoryTabClickHandler;
            _statusTab.clicked += StatusTabClickHandler;
        }

        private void CraftingTabClickHandler()
        {
            MenuState.CurrentMenuState = MenuState.MenuStates.Crafting;
        }

        private void StatusTabClickHandler()
        {
            MenuState.CurrentMenuState = MenuState.MenuStates.Status;
        }

        private void InventoryTabClickHandler()
        {
            MenuState.CurrentMenuState = MenuState.MenuStates.Inventory;
        }

        private void SetActiveTab()
        {
            ClearCurrentActiveTabButton();
            SetNewCurrentActiveTabButton();
        }

        private void ClearCurrentActiveTabButton()
        {
            _currentActiveTabButton?.RemoveFromClassList(CurrentTabStyleClass);
        }

        private void SetNewCurrentActiveTabButton()
        {
            var newState = MenuState.CurrentMenuState;

            switch (newState)
            {
                case MenuState.MenuStates.Crafting:
                    _craftingTab.AddToClassList(CurrentTabStyleClass);
                    _currentActiveTabButton = _craftingTab;
                    break;
                case MenuState.MenuStates.Inventory:
                    _inventoryTab.AddToClassList(CurrentTabStyleClass);
                    _currentActiveTabButton = _inventoryTab;
                    break;
                case MenuState.MenuStates.Status:
                    _statusTab.AddToClassList(CurrentTabStyleClass);
                    _currentActiveTabButton = _statusTab;
                    break;
            }
        }
    }
}