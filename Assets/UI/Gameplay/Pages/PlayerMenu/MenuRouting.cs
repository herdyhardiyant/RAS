using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace RAS.UI.Gameplay.Pages.PlayerMenu
{
    public class MenuRouting : MonoBehaviour
    {
        
        [SerializeField] private VisualTreeAsset _inventory;
        [SerializeField] private VisualTreeAsset _crafting;
        [SerializeField] private VisualTreeAsset _survivalStatus;
        private VisualElement _rootVisualElement;

        public enum MenuStates
        {
            Close,
            Crafting,
            Status,
            Inventory
        }
        
        private static MenuStates _currentState;
        public static event Action OnMenuStateChange;

        public static MenuStates CurrentMenuState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                OnMenuStateChange?.Invoke();
            }
        }
        
        // Start is called before the first frame update
        void Start()
        {
            _currentState = MenuStates.Close;
            OnMenuStateChange += MenuStateChangeHandler;
            _rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        }

        private void MenuStateChangeHandler()
        {
            switch (_currentState)
            {
                case MenuRouting.MenuStates.Crafting:
                    _crafting.CloneTree(_rootVisualElement);
                    break;
                case MenuRouting.MenuStates.Inventory:
                    _inventory.CloneTree(_rootVisualElement);
                    break;
                case MenuRouting.MenuStates.Status:
                    _survivalStatus.CloneTree(_rootVisualElement);
                    break;
                
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
