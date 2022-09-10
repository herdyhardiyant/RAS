using UnityEngine;
using UnityEngine.UIElements;

namespace RAS.UI.Gameplay.Pages.PlayerMenu.Components.Inventory
{
    public class Inventory : MonoBehaviour
    {
        private VisualElement _inventoryRoot;
        
        // Start is called before the first frame update
        void Start()
        {
            _inventoryRoot = GetComponent<UIDocument>().rootVisualElement;
            _inventoryRoot.visible = false;
            Controller.OnMenuStateChange += MenuStateChangeHandler;

        }
        
        private void MenuStateChangeHandler()
        {
            var currentMenuState = Controller.GetCurrentMenuState();
            _inventoryRoot.visible = currentMenuState == Controller.MenuState.Inventory;
        }
    }
}
