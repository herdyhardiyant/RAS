using System;
using Controls;
using UnityEngine;

namespace EventSystems
{
    public class GameplayUIEventHandler : MonoBehaviour
    {
        public static event Action OnOpenInventory;
        public static event Action OnCloseInventory;
        public static bool IsInventoryOpen => _isInventoryOpen;
        private static bool _isInventoryOpen;
        
        private PlayerInputMap _playerInputMap;

        private void Awake()
        {
            _isInventoryOpen = false;
            _playerInputMap = gameObject.AddComponent<PlayerInputMap>();
        }

        void Update()
        {
            if (_playerInputMap.IsInventoryPressed && !_isInventoryOpen)
            {
                OnOpenInventory?.Invoke();
                _isInventoryOpen = true;
            }
            else if (_playerInputMap.IsInventoryPressed && _isInventoryOpen)
            {
                OnCloseInventory?.Invoke();
                _isInventoryOpen = false;
            }
        }

    }
}
