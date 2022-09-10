
using System;
using Environment.Scripts;
using UI.Gameplay;
using UnityEngine;
using PlayerInput = Settings.PlayerInput;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class Interact : MonoBehaviour
    {
        [SerializeField] private GameObject _gameplayUI;
        private IPlayerUIInteractable _playerInteractionUIControl;
        
        private bool _isPlayerInInteractRange;
        private PlayerInput _playerInput;
        private bool _isInteractionEnable;
        private string _objectInteractionText;
        private void Start()
        {
            _isInteractionEnable = true;
            _playerInput = gameObject.AddComponent<PlayerInput>();
            
            _playerInteractionUIControl = _gameplayUI.GetComponentInChildren<IPlayerUIInteractable>();
            Manager.OnInventoryButtonClick += ToggleEnable;
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
            _playerInteractionUIControl.ShowInteractionText(_objectInteractionText);
        }

        private void OpenInteraction()
        {
            _isPlayerInInteractRange = true;
        }

        private void CloseInteraction()
        {
            _isPlayerInInteractRange = false;
            _playerInteractionUIControl.HideInteractionText();
        }
        
        private bool CanPlayerInteract()
        {
            return _isPlayerInInteractRange && _isInteractionEnable;
        }

        private void OnDisable()
        {
            Manager.OnInventoryButtonClick -= ToggleEnable;

        }
    }
}
