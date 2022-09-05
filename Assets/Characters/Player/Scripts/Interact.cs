
using Environment.Scripts;
using UI.Gameplay;
using UnityEngine;
using PlayerInput = Settings.PlayerInput;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class Interact : MonoBehaviour, IPlayerFeatureControllable
    {
        [SerializeField] private GameObject _gameplayUI;
        private IPlayerUIInteractable _playerUIInteractable;
        
        private bool _isPlayerInInteractRange;
        private PlayerInput _playerInput;
        private bool _isInteractionEnable;
        private string _objectInteractionText;

        public void SetEnable(bool isEnable)
        {
            _isInteractionEnable = isEnable;
        }
        public void ToggleEnable()
        {
            _isInteractionEnable = !_isInteractionEnable;
        }
        
        private void Start()
        {
            _isInteractionEnable = true;
            _playerInput = gameObject.AddComponent<PlayerInput>();
            _playerUIInteractable = _gameplayUI.GetComponentInChildren<IPlayerUIInteractable>();
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
            _playerUIInteractable.ShowInteractionText(_objectInteractionText);
        }

        private void OpenInteraction()
        {
            _isPlayerInInteractRange = true;
        }

        private void CloseInteraction()
        {
            _isPlayerInInteractRange = false;
            _playerUIInteractable.HideInteractionText();
        }
        
        private bool CanPlayerInteract()
        {
            return _isPlayerInInteractRange && _isInteractionEnable;
        }
        
    }
}
