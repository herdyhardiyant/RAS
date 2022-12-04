using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class CraftingMaterial : MonoBehaviour
    {

        public GameObject CraftingResultPrefab => craftingResultPrefab;
        
        [Tooltip("Crafting result after the material is used")]
        [SerializeField] private GameObject craftingResultPrefab;
        [SerializeField] private Sprite materialIcon;

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
