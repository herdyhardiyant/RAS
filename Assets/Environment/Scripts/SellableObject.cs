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
        [SerializeField] private GameObject trash;
        [SerializeField] private GameObject material;

        public string Name => gameObject.name;
        public int Price => price;
        public Sprite Icon => objectSprite;
        public Sprite TrashIcon => _trashSprite;
        public Sprite MaterialIcon => _materialSprite;

        private Sprite _trashSprite;
        private Sprite _materialSprite;

        private void Awake()
        {
            _trashSprite = trash.GetComponent<Trash>().GetSprite;
            _materialSprite = material.GetComponent<CraftingMaterial>().Icon;
        }

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