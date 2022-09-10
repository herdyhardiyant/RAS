using UnityEngine;
using UnityEngine.UIElements;

namespace RAS.UI.Gameplay.Pages.PlayerMenu.Components.Navigation
{
    [RequireComponent(typeof(UIDocument))]
    public class Navigation : MonoBehaviour
    {
       
        private VisualElement _navigationVisualElement;

        private Button _craftingTab;
        private Button _inventoryTab;
        private Button _statusTab;

        private static class TabNames
        {
            public const string crafting ="crafting-tab";
            public const string inventory ="inventory-tab";
            public const string status ="status-tab";
        }

        private const string _currentTabStyleClass = "current-tab";

        // Start is called before the first frame update
        void Start()
        {
            _navigationVisualElement = GetComponent<UIDocument>().rootVisualElement;
        
            QueryTabs();
            SetupTabsEvent();
            Controller.OnMenuStateChange += MenuStateChangeHandler;
        }
        
        private void QueryTabs()
        {
            _craftingTab = _navigationVisualElement.Q<Button>(TabNames.crafting);
            _inventoryTab = _navigationVisualElement.Q<Button>(TabNames.inventory);
            _statusTab = _navigationVisualElement.Q<Button>(TabNames.status);
        }

        private void SetupTabsEvent()
        {
            _craftingTab.clicked += CraftingTabClickHandler;
            _inventoryTab.clicked += InventoryTabClickHandler;
            _statusTab.clicked += StatusTabClickHandler;
        }

        private void CraftingTabClickHandler()
        {
           Controller.ChangeMenu(Controller.MenuState.Crafting);
        }

        private void StatusTabClickHandler()
        {
            Controller.ChangeMenu(Controller.MenuState.Status);
        }

        private void InventoryTabClickHandler()
        {
            Controller.ChangeMenu(Controller.MenuState.Inventory);
        }
        private void MenuStateChangeHandler()
        {
            ClearCurrentTab();
            SetCurrentTabButtonActive();
        }
        
        private void ClearCurrentTab()
        {
            _craftingTab.RemoveFromClassList(_currentTabStyleClass);
            _inventoryTab.RemoveFromClassList(_currentTabStyleClass);
            _statusTab.RemoveFromClassList(_currentTabStyleClass);
        }

        private void SetCurrentTabButtonActive()
        {
            var newState = Controller.GetCurrentMenuState();
            switch (newState)
            {
                case Controller.MenuState.Crafting:
                    _craftingTab.AddToClassList(_currentTabStyleClass);
                    break;
                case Controller.MenuState.Inventory:
                    _inventoryTab.AddToClassList(_currentTabStyleClass);
                    break;
                case Controller.MenuState.Status:
                    _statusTab.AddToClassList(_currentTabStyleClass);
                    break;
            }
        }
      
    }
}