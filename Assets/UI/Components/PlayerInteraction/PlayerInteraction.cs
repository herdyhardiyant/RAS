using UnityEngine;
using UnityEngine.UIElements;

namespace UI.PlayerInteraction
{
    public class PlayerInteractionUI : MonoBehaviour
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
