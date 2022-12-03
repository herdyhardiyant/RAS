using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class SellableObject : MonoBehaviour, ISellable
    {
        [SerializeField] private int price;

        [Header("Recipe")]
        [SerializeField] private Sprite objectSprite;
        [SerializeField] private GameObject trash;
        [SerializeField] private GameObject material;
        
        public int Price => price;
        
        // TODO Get Recipe Function
        
        private void Update()
        {
            ReturnToPoolWhenFallOutOfMap();
        }

        private void ReturnToPoolWhenFallOutOfMap()
        {
            if (transform.position.y < -10)
            {
                ObjectPool.Instance.ReturnObjectToPool(gameObject);
            }
        }

    }
}