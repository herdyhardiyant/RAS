using System;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class SellableObject : MonoBehaviour, ISellable
    {
        [SerializeField] private int price;

        [Header("Recipe")]
        [SerializeField] private Sprite objectSprite;
        [SerializeField] private string sellableName;
        [SerializeField] private Sprite trashSprite;
        [SerializeField] private Sprite materialSprite;
        public string SellableName => sellableName;
        public int Price => price;
        public Sprite Icon => objectSprite;
        public Sprite TrashIcon => trashSprite;
        public Sprite MaterialIcon => materialSprite;

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