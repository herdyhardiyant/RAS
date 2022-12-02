using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class SellableObject : MonoBehaviour
    {
        [SerializeField] private int price;

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