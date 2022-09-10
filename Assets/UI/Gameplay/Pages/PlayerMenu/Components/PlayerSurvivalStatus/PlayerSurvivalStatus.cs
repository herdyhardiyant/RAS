using UnityEngine;
using UnityEngine.UIElements;

namespace RAS.UI.Gameplay.Pages.PlayerMenu.Components.PlayerSurvivalStatus
{
    public class PlayerSurvivalStatus : MonoBehaviour
    {
        private VisualElement _statusRoot;
        // Start is called before the first frame update
        void Start()
        {
            _statusRoot = GetComponent<UIDocument>().rootVisualElement;
            _statusRoot.visible = false;
            Controller.OnMenuStateChange += MenuStateChangeHandler;

        }
        
        private void MenuStateChangeHandler()
        {
            var currentMenuState = Controller.GetCurrentMenuState();
            _statusRoot.visible = currentMenuState == Controller.MenuState.Status;
        }
    }
}
