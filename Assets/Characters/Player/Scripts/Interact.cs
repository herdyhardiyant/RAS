using System;
using Environment.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class Interact : MonoBehaviour
    {
        private VisualElement _interactionVisual;
        private BoxCollider _interactTrigger;
        private Label _interactLabel;
        private Keyboard _keyboard;
        private const string _interactLabelDefaultText = "Press F to Interact";
        
        private string _objectInteractionText;
        private bool _isPlayerInInteractRange;
        // Start is called before the first frame update
        void Start()
        {
            SetupInteractionVisual();
            _keyboard = Keyboard.current;
        }  
        
        void Update()
        {

            if (_isPlayerInInteractRange)
            {
                InteractInput();
            }
        
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var interactedObject = other.GetComponent<IEnvironmentInteractable>();
            if (interactedObject == null)
                return;
            
            OpenInteractionVisual();
            _objectInteractionText = interactedObject.GetInteractionText();

        }
        
        private void OnTriggerExit(Collider other)
        {
            CloseInteractVisual();
            _isPlayerInInteractRange = false;
        }

        private void InteractInput()
        {
            if (_keyboard == null)
                return;
            
            if (_keyboard.fKey.wasPressedThisFrame)
            {
                ShowInteractionText();
            }
        }

        private void ShowInteractionText()
        {
            _interactLabel.text = _objectInteractionText;

        }
        
        private void OpenInteractionVisual()
        {
            _isPlayerInInteractRange = true;
            _interactionVisual.visible = true;
        }
        
        private void SetupInteractionVisual()
        {
            _interactionVisual = GetComponentInChildren<UIDocument>().rootVisualElement;
            _interactLabel = _interactionVisual.Q<Label>("interaction-label");
            _interactionVisual.visible = false;
        }
        
        private void CloseInteractVisual()
        {
            _interactLabel.text = _interactLabelDefaultText;
            _interactionVisual.visible = false;
        }
        
      
        
    }
}
