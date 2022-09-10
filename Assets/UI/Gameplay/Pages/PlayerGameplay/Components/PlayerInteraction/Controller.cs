using UnityEngine;
using UnityEngine.UIElements;

namespace RAS.UI.Gameplay.Pages.PlayerGameplay.Components.PlayerInteraction
{
    public class Controller : MonoBehaviour
    {
        private Label _interactLabel;
        // Start is called before the first frame update
        void Start()
        {
            var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
            print(rootVisualElement);
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
