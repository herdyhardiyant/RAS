using UI.Gameplay.PlayerMenu.Components.Crafting;
using UI.Gameplay.PlayerMenu.Components.Inventory;
using UI.Gameplay.PlayerMenu.Components.PlayerSurvivalStatus;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.PlayerMenu.Components.MenuWindow
{
    public class MenuRouter : MonoBehaviour
    {
        private VisualElement _inventoryElement;
        private VisualElement _craftingElement;
        private VisualElement _survivalStatusElement;
        private VisualElement _rootMenuElement;

        [SerializeField] private InventoryController inventoryController;
        [SerializeField] private CraftingManipulator _craftingManipulator;
        [SerializeField] private SurvivalStatusManipulator _survivalStatusManipulator;
        
        
        private void Awake()
        {
            _rootMenuElement = GetComponent<UIDocument>().rootVisualElement;
            MenuState.OnMenuStateChange += MenuStateChangeHandler;

            _inventoryElement = inventoryController.InventoryVisualElement;
            _craftingElement = _craftingManipulator.CraftingVisualElement;
            _survivalStatusElement = _survivalStatusManipulator.SurvivalStatusVisualElement;

        }

        void Start()
        {
            MenuState.CurrentMenuState = MenuState.MenuStates.Inventory;
            ShowMenuFromMenuState();
        }
        
        private void OnDisable()
        {
            MenuState.OnMenuStateChange -= MenuStateChangeHandler;
        }

        private void MenuStateChangeHandler()
        {
            ClearMenuWindow();
            ShowMenuFromMenuState();
        }

        private void ShowMenuFromMenuState()
        {
            switch (MenuState.CurrentMenuState)
            {
                case MenuState.MenuStates.Crafting:
                    _rootMenuElement.Add(_craftingElement);
                    break;
                case MenuState.MenuStates.Inventory:
                    _rootMenuElement.Add(_inventoryElement);
                    break;
                case MenuState.MenuStates.Status:
                    _rootMenuElement.Add(_survivalStatusElement);
                    break;
            }
        }

        private void ClearMenuWindow()
        {
            if (_rootMenuElement.childCount == 0)
                return;

            _rootMenuElement.ElementAt(0).RemoveFromHierarchy();
        }
    }
}