using System;
using Settings;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay
{
    /// <summary>
    /// This class is responsible for the UI State of the Gameplay Screen
    /// </summary>
    public class Manager : MonoBehaviour
    {
        [SerializeField] private GameObject _playerLevelUI;
        [SerializeField] private GameObject _playerMenuUI;
        //TODO Toggle PauseMenuUI
        //TODO Stop player movement and actions when PlayerMenuUI is active
        
        private PlayerInput _playerInput;
        
        private IScreenControllable _playerLevelUIController;
        private IScreenControllable _playerMenuUIController;

        private void Awake()
        {
            _playerInput = gameObject.AddComponent<PlayerInput>();
            _playerLevelUIController = _playerLevelUI.GetComponent<IScreenControllable>();
            _playerMenuUIController = _playerMenuUI.GetComponent<IScreenControllable>();
        }

        // Start is called before the first frame update
        void Start()
        {
            _playerMenuUIController.SetVisibility(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (_playerInput.IsInventoryPressed)
            {
               _playerMenuUIController.ToggleVisibility();
               _playerLevelUIController.ToggleVisibility();
            }
        }
    }
}
