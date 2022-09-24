using System;
using Controls;
using UnityEngine;

namespace EventSystems
{
    public class GameplayUIEventHandler : MonoBehaviour
    {
        public static event Action OnOpenInventory;
        
        
        private PlayerInputMap _playerInputMap;
        void Start()
        {
            _playerInputMap = gameObject.AddComponent<PlayerInputMap>();
            gameObject.SetActive(true);
        }
        
        void Update()
        {
           
            if (_playerInputMap.IsInventoryPressed)
            {
                OnOpenInventory?.Invoke();
            }
        }
        
    }
}
