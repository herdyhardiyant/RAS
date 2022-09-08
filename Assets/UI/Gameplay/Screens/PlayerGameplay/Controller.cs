using System;
using Characters.Player.Scripts;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.Screens.PlayerGameplay
{
    [RequireComponent(typeof(UIDocument))]
    public class Controller : MonoBehaviour, IVisualControllable, IPlayerUIInteractable
    {
        private VisualElement _visualElement;
        private Label _interactText;

        // Start is called before the first frame update
        void Start()
        {
            _visualElement = GetComponent<UIDocument>().rootVisualElement;
            _interactText = _visualElement.Q<Label>("interact-text");
            HideInteractionText();
            Manager.OnOpenInventory += ToggleVisibility;
        }

        public void ShowInteractionText(string interactText)
        {
            _interactText.visible = true;
            _interactText.text = interactText;
        }
        
        public void HideInteractionText()
        {
            _interactText.visible = false;
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
