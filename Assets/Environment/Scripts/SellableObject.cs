using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class SellableObject : MonoBehaviour, IPickupable
    {
        [SerializeField] private string objectName;
        [SerializeField] private int price;
        public string Name => objectName;
        
        private void Update()
        {
            ReturnToPoolWhenFallOutOfMap();
        }

        private void ReturnToPoolWhenFallOutOfMap()
        {
            if (transform.position.y < -10)
            {
                PickupObjectPool.SharedInstance.ReturnObjectToPool(gameObject);
            }
        }
    }
}