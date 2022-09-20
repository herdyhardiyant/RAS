using EventSystems;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.Pages.PlayerMenu
{
    [RequireComponent(typeof(UIDocument))]
    public class Controller : MonoBehaviour
    {
        private VisualElement _rootVisualElement;

        void Start()
        {
            _rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
            CloseMenu();
            GameplayUIManager.OnOpenInventory += OpenInventoryClickHandler;
            SetRootBackgroundColor();
        }

        private void OpenInventoryClickHandler()
        {
            if (_rootVisualElement.visible)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }

        private void CloseMenu()
        {
            _rootVisualElement.visible = false;
        }

        private void OpenMenu()
        {
            _rootVisualElement.visible = true;
        }

        private void SetRootBackgroundColor()
        {
            _rootVisualElement.style.backgroundColor = new StyleColor(new Color(0, 0, 0, 0.7f));
        }

        private void OnDisable()
        {
            GameplayUIManager.OnOpenInventory -= OpenInventoryClickHandler;
        }
    }
}