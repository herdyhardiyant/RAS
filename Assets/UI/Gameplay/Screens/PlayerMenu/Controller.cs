using System;
using Settings;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.Screens.PlayerMenu
{
    [RequireComponent(typeof(UIDocument))]
    public class Controller : MonoBehaviour, IVisualControllable
    {
        private VisualElement _visualElement;

        // Start is called before the first frame update
        void Start()
        {
            _visualElement = GetComponent<UIDocument>().rootVisualElement;
            SetVisibility(false);
            Manager.OnOpenInventory += ToggleVisibility;
        }

        public void SetVisibility(bool isVisible)
        {
            _visualElement.visible = isVisible;
        }

        public void ToggleVisibility()
        {
            _visualElement.visible = !_visualElement.visible;
        }

        private void OnDisable()
        {
            Manager.OnOpenInventory -= ToggleVisibility;
        }
    }
}
