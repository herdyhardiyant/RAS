using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class SellableObject : MonoBehaviour
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
                ObjectPool.SharedInstance.ReturnObjectToPool(gameObject);
            }
        }
    }
}