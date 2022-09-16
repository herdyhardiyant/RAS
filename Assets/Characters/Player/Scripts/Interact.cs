using CentralSystems;
using UnityEngine;
using Environment.Scripts;
using PlayerInput = Settings.PlayerInput;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class Interact : MonoBehaviour
    {
        private bool _isPlayerInInteractRange;
        private PlayerInput _playerInput;
        private bool _isInteractionEnable; 
        private string _objectInteractionText;
        private void Start()
        {
            _isInteractionEnable = true;
            _playerInput = gameObject.AddComponent<PlayerInput>();
            GameplayUIManager.OnOpenInventory += ToggleEnable;
        }
        
        public void SetEnable(bool isEnable)
        {
            _isInteractionEnable = isEnable;
        }
        
        public void ToggleEnable()
        {
            _isInteractionEnable = !_isInteractionEnable;
        }

        void Update()
        {
            if (CanPlayerInteract())
            {
                InteractionInputHandler();
            }
        }
        
        
        // TODO Receive object interaction text from Central System
        // Environment Object should connect to the central system and send the interaction text
        // On Player Trigger Enter
        private void OnTriggerEnter(Collider other)
        {
            var interactedObject = other.GetComponent<IInteractable>();
            if (interactedObject == null)
                return;
            
            OpenInteraction();
            _objectInteractionText = interactedObject.GetInteractionText();
        
        }
        
        private void OnTriggerExit(Collider other)
        {
            CloseInteraction();
        }

        private void InteractionInputHandler()
        {
            if (!_playerInput.IsInteractPressed)
                return;
            PlayerInteractionUIConnector.ShowInteractText(_objectInteractionText);
        }

        private void OpenInteraction()
        {
            _isPlayerInInteractRange = true;
        }

        private void CloseInteraction()
        {
            _isPlayerInInteractRange = false;
            PlayerInteractionUIConnector.PlayerStopInteraction();
        }
        
        private bool CanPlayerInteract()
        {
            return _isPlayerInInteractRange && _isInteractionEnable;
        }

        private void OnDisable()
        {
            GameplayUIManager.OnOpenInventory -= ToggleEnable;
        }
    }
}
