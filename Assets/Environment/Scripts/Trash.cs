using System;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class Trash : MonoBehaviour
    { 
        public GameObject GetSmeltedPrefab => getSmeltedPrefab;
        public Sprite GetSprite => trashSprite;

        [Tooltip("Prefab of the smelted trash")] [SerializeField]
        private GameObject getSmeltedPrefab;
        
        [SerializeField] private Sprite trashSprite;
        
        
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