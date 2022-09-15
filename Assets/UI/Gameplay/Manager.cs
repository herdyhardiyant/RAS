using System;
using RAS.Settings;
using UnityEngine;

namespace RAS.UI.Gameplay
{
    public class Manager : MonoBehaviour
    {
        public static event Action OnInventoryButtonClick;
        
        
        private PlayerInput _playerInput;
        void Start()
        {
            _playerInput = gameObject.AddComponent<PlayerInput>();
            gameObject.SetActive(true);
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
