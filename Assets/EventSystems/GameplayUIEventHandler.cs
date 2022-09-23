using System;
using Settings;
using UnityEngine;

namespace EventSystems
{
    public class GameplayUIEventHandler : MonoBehaviour
    {
        public static event Action OnOpenInventory;
        
        
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
                OnOpenInventory?.Invoke();
            }
        }
        
    }
}
