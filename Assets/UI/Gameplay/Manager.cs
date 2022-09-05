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
        [SerializeField] private GameObject _playerGameplayUI;
        [SerializeField] private GameObject _playerMenuUI;

        private PlayerInput _playerInput;
        private IPlayerFeatureControllable[] _playerFeatures;
        
        private IVisualControllable _playerLevelUIController;
        private IVisualControllable _playerMenuUIController;

        void Start()
        {
            _playerInput = gameObject.AddComponent<PlayerInput>();
            _playerFeatures = _player.GetComponents<IPlayerFeatureControllable>();
            
            _playerLevelUIController = _playerGameplayUI.GetComponent<IVisualControllable>();
            _playerMenuUIController = _playerMenuUI.GetComponent<IVisualControllable>();
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
