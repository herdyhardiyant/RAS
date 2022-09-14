using UnityEngine;
using UnityEngine.UIElements;

namespace RAS.UI.Gameplay.Pages.PlayerMenu.Components.Crafting
{
    [RequireComponent(typeof(UIDocument))]
    public class Crafting : MonoBehaviour
    {
        private VisualElement _craftingVisualElement;

        void Start()
        {
            _craftingVisualElement = GetComponent<UIDocument>().rootVisualElement;
            _craftingVisualElement.visible = false;
            
            Controller.OnMenuStateChange += MenuStateChangeHandler;
        }

        private void MenuStateChangeHandler()
        {
            var currentMenuState = Controller.GetCurrentMenuState();
            _craftingVisualElement.visible = currentMenuState == MenuRouting.MenuStates.Crafting;
        }
        
    }
}
