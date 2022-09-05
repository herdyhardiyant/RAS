using System;
using Environment.Scripts;
using UnityEngine;
using UnityEngine.UIElements;
using PlayerInput = Settings.PlayerInput;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class Interact : MonoBehaviour
    {


        private VisualElement _interactionVisual;
        // private Label _interactLabel;
        private const string _interactLabelDefaultText = "Press E to Interact";
        private string _objectInteractionText;
        private bool _isPlayerInInteractRange;
        private PlayerInput _playerInput;

        public bool isInteractionEnable { get; set; }

        private void Start()
        {
            // isInteractionEnable = true;
            // _playerInput = gameObject.AddComponent<PlayerInput>();

        }

        void Update()
        {

            // if (CanPlayerInteract())
            // {
            //     InteractionInputHandler();
            // }
        
        }
        
        private void OnTriggerEnter(Collider other)
        {
            // var interactedObject = other.GetComponent<IEnvironmentInteractable>();
            // if (interactedObject == null)
            //     return;
            //
            // OpenInteraction();
            // _objectInteractionText = interactedObject.GetInteractionText();
        
        }
        
        private void OnTriggerExit(Collider other)
        {
            // CloseInteraction();
            // _isPlayerInInteractRange = false;
        }

        private void InteractionInputHandler()
        {
            if (_playerInput.IsInteractPressed)
            {
                // ShowInteractionText();
                
                //TODO get gameplayUI GameObject
                //TODO get Player UI Interaction Handler 
                //TODO Send interact Text to Player UI Interaction Handler 
                
            }
            
        }

        // private void ShowInteractionText()
        // {
        //     _interactLabel.text = _objectInteractionText;
        //
        // }
        
        private void OpenInteraction()
        {
            _isPlayerInInteractRange = true;
            // _interactionVisual.visible = true;
        }
        
        private void SetupInteractionVisual()
        {
            _interactionVisual = GetComponentInChildren<UIDocument>().rootVisualElement;
            // _interactLabel = _interactionVisual.Q<Label>("interaction-label");
            _interactionVisual.visible = false;
        }
        
        private void CloseInteraction()
        {
            // _interactionVisual.visible = false;
            // _interactLabel.text = _interactLabelDefaultText;

        }
        
        private bool CanPlayerInteract()
        {
            return _isPlayerInInteractRange && isInteractionEnable;
        }
        
    }
}
