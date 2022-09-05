using System;
using Characters.Player.Scripts;
using Settings;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay
{
    /// <summary>
    /// Kelas ini bertanggung jawab untuk mengatur hubungan antara UI
    /// yang digunakan untuk gameplay dan hubungan ui dengan player
    /// </summary>
    public class Manager : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _playerLevelUI;
        [SerializeField] private GameObject _playerMenuUI;
        
        //TODO Toggle PauseMenuUI
        //TODO Stop player movement and actions when PlayerMenuUI is active
        
        private PlayerInput _playerInput;
        private IPlayerControllable[] _playerFeatures;
        
        private IScreenControllable _playerLevelUIController;
        private IScreenControllable _playerMenuUIController;

        void Start()
        {
            _playerInput = gameObject.AddComponent<PlayerInput>();
            _playerFeatures = _player.GetComponents<IPlayerControllable>();
            
            _playerLevelUIController = _playerLevelUI.GetComponent<IScreenControllable>();
            _playerMenuUIController = _playerMenuUI.GetComponent<IScreenControllable>();
            _playerMenuUIController.SetVisibility(false);
            
        }
        
        void Update()
        {
            if (_playerInput.IsInventoryPressed)
            {
               _playerMenuUIController.ToggleVisibility();
               _playerLevelUIController.ToggleVisibility();
               ToggleEnablePlayer();
            }
        }

        private void ToggleEnablePlayer()
        {
            foreach (var playerFeature in _playerFeatures)
            {
                playerFeature.ToggleEnable();
            }
        }
    }
}
