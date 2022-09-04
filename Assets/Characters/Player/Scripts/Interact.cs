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
        private Label _interactLabel;
        private const string _interactLabelDefaultText = "Press E to Interact";
        private string _objectInteractionText;
        private bool _isPlayerInInteractRange;
        private PlayerInput _playerInput;

        // Start is called before the first frame update
        void Start()
        {
            SetupInteractionVisual();
            _playerInput = gameObject.AddComponent<PlayerInput>();
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
            if (_playerInput.IsInteractPressed)
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
