using System;
using CentralSystems;
using UnityEngine;
using PlayerInput = Settings.PlayerInput;
using Environment.Interfaces;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class Interact : MonoBehaviour
    {
        private bool _isPlayerInInteractRange;
        private PlayerInput _playerInput;
        private bool _isInteractionEnable; 
        private string _objectInteractionText;

        private void Awake()
        {
            _isInteractionEnable = true;
            _playerInput = gameObject.AddComponent<PlayerInput>();
            GameplayUIManager.OnOpenInventory += ToggleEnable;
        }

        private void Start()
        {
            
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
        // TODO Remove Environment Dependency, instead use Central System
        // TODO Change Player Interaction Trigger with Mouse Click
        // TODO Mouse click on Interactable Object and Check the distance between player and object
        // TODO When mouse hover interactable object, change cursor to Eye Icon
        // TODO Create Storable Object
        // TODO Storable object on mouse hover, change cursor to Hand Icon

        private void OnTriggerEnter(Collider collidedObject)
        {
            IInteractable interactedObject = collidedObject.GetComponent<IInteractable>();
            
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
         
            PlayerInteractionSystem.PlayerStartInteract(_objectInteractionText);
        }

        private void OpenInteraction()
        {
            _isPlayerInInteractRange = true;
        }

        private void CloseInteraction()
        {
            _isPlayerInInteractRange = false;
            PlayerInteractionSystem.PlayerStopInteraction();
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
