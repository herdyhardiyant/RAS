using UnityEngine;

namespace Environment.Scripts
{
    public class CraftingMaterial : MonoBehaviour
    {

        public GameObject CraftingResult => craftingResult;
        
        [Tooltip("Crafting result after the material is used")]
        [SerializeField] private GameObject craftingResult;
        
    }
}
