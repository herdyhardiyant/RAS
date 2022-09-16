using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.Pages.PlayerMenu.Components.Crafting
{
    [RequireComponent(typeof(UIDocument))]
    public class Crafting : MonoBehaviour
    {
        private VisualElement _craftingVisualElement;

        void Start()
        {
            _craftingVisualElement = GetComponent<UIDocument>().rootVisualElement;
        }


    }
}
