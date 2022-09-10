using System;
using Settings;
using UnityEngine;

namespace UI.Gameplay
{
    public class Manager : MonoBehaviour
    {
        public static event Action OnInventoryButtonClick;
        
        private PlayerInput _playerInput;
        void Start()
        {
            _playerInput = gameObject.AddComponent<PlayerInput>();
        }
        
        void Update()
        {
            if (_playerInput.IsInventoryPressed)
            {
                OnInventoryButtonClick?.Invoke();
            }
        }
        
    }
}
