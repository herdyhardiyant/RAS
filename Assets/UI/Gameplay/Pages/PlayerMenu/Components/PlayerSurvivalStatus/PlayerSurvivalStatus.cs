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

        }
        
      
    }
}
