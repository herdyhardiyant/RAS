using System;
using RAS.Settings;
using UnityEngine;

namespace RAS.CentralSystems
{
    public class GameplayUIManager : MonoBehaviour
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
