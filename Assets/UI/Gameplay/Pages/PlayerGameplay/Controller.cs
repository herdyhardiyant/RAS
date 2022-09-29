using EventSystems;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.Pages.PlayerGameplay
{
    [RequireComponent(typeof(UIDocument))]
    public class Controller : MonoBehaviour
    {
        private VisualElement _visualElement;
        private Label _interactText;

        // Start is called before the first frame update
        void Start()
        {
            _visualElement = GetComponent<UIDocument>().rootVisualElement;
            _interactText = _visualElement.Q<Label>("interact-text");
            HideInteractionText();
            ConnectDependenciesEvent();
        }
        
        private void ConnectDependenciesEvent()
        {
            GameplayUIEventHandler.OnOpenInventory += CloseUI;
            GameplayUIEventHandler.OnCloseInventory += OpenUI;
            PlayerInteractionEventHandler.OnPlayerInteract += ShowInteractionText;
            PlayerInteractionEventHandler.OnPlayerStopInteraction += HideInteractionText;
        }
        
        private void ShowInteractionText(string interactText)
        {
            _interactText.visible = true;
            _interactText.text = interactText;
        }
        
        private void HideInteractionText()
        {
            _interactText.visible = false;
        }

        private void CloseUI()
        {
            _visualElement.visible = false;
        }

        private void OpenUI()
        {
            _visualElement.visible = true;
        }

        private void OnDisable()
        {
            DisconnectDependenciesEvent();
        }
        
        private void DisconnectDependenciesEvent()
        {
            GameplayUIEventHandler.OnOpenInventory -= CloseUI;
            GameplayUIEventHandler.OnCloseInventory -= OpenUI;
            PlayerInteractionEventHandler.OnPlayerInteract -= ShowInteractionText;
            PlayerInteractionEventHandler.OnPlayerStopInteraction -= HideInteractionText;
        }
    }
}
