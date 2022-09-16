using RAS.CentralSystems;
using RAS.Environment.Scripts;
using UnityEngine;
using PlayerInput = RAS.Settings.PlayerInput;

namespace RAS.Characters.Player.Scripts
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
        
        private void OnTriggerEnter(Collider other)
        {
            var interactedObject = other.GetComponent<IEnvironmentInteractable>();
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
