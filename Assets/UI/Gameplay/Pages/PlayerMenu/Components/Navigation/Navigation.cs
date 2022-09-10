using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.Pages.PlayerMenu.Components.Navigation
{
    [RequireComponent(typeof(UIDocument))]
    public class Navigation : MonoBehaviour
    {
        private VisualElement _navigationVisualElement;

        private Button _craftingTab;
        private Button _inventoryTab;
        private Button _statusTab;

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
            _craftingTab = _navigationVisualElement.Q<Button>("crafting-tab");
            _inventoryTab = _navigationVisualElement.Q<Button>("inventory-tab");
            _statusTab = _navigationVisualElement.Q<Button>("status-tab");
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
            _craftingTab.RemoveFromClassList("current-tab");
            _inventoryTab.RemoveFromClassList("current-tab");
            _statusTab.RemoveFromClassList("current-tab");
        }

        private void SetCurrentTabButtonActive()
        {
            var newState = Controller.GetCurrentMenuState();
            switch (newState)
            {
                case Controller.MenuState.Crafting:
                    _craftingTab.AddToClassList("current-tab");
                    break;
                case Controller.MenuState.Inventory:
                    _inventoryTab.AddToClassList("current-tab");
                    break;
                case Controller.MenuState.Status:
                    _statusTab.AddToClassList("current-tab");
                    break;
            }
        }
      
    }
}