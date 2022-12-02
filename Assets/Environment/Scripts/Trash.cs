using System;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class Trash : MonoBehaviour

    {
        public GameObject GetSmeltedPrefab => getSmeltedPrefab;

        [Tooltip("Prefab of the smelted trash")] [SerializeField]
        private GameObject getSmeltedPrefab;

        [SerializeField] private string trashName;
        public string Name => trashName;

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