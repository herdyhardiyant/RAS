using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class CraftingMaterial : MonoBehaviour, IPickupable
    {

        public GameObject CraftingResultPrefab => craftingResultPrefab;
        
        [Tooltip("Crafting result after the material is used")]
        [SerializeField] private GameObject craftingResultPrefab;
        [SerializeField] private string materialName;
        public string Name => materialName;
        
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
