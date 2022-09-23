using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.Pages.PlayerMenu
{
    public class MenuRouter : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset _inventory;
        [SerializeField] private VisualTreeAsset _crafting;
        [SerializeField] private VisualTreeAsset _survivalStatus;
        [SerializeField] private VisualTreeAsset _navigation;

        private VisualElement _inventoryElement;
        private VisualElement _craftingElement;
        private VisualElement _survivalStatusElement;
        private VisualElement _rootMenuElement;

        private void Awake()
        {
            _rootMenuElement = GetComponent<UIDocument>().rootVisualElement;
            MenuState.OnMenuStateChange += MenuStateChangeHandler;
            AddNavigationElementToRootElement();
        }

        void Start()
        {
            MenuState.CurrentMenuState = MenuState.MenuStates.Inventory;
            CloneTreesFromImportedVisualTreeAssets();
            ShowMenuFromCurrentMenuState();
        }

        private void AddNavigationElementToRootElement()
        {
            _rootMenuElement = GetComponent<UIDocument>().rootVisualElement;
            _rootMenuElement.Add(_navigation.CloneTree());
        }

        private void OnDisable()
        {
            MenuState.OnMenuStateChange -= MenuStateChangeHandler;
        }

        private void CloneTreesFromImportedVisualTreeAssets()
        {
            _inventoryElement = _inventory.CloneTree();
            _craftingElement = _crafting.CloneTree();
            _survivalStatusElement = _survivalStatus.CloneTree();
        }

        private void MenuStateChangeHandler()
        {
            ClearMenu();
            ShowMenuFromCurrentMenuState();
        }

        private void ShowMenuFromCurrentMenuState()
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

        private void ClearMenu()
        {
            if (_rootMenuElement.childCount == 1)
                return;

            _rootMenuElement.ElementAt(1).RemoveFromHierarchy();
        }
    }
}