using UnityEngine;
using UnityEngine.UI;

namespace UI.Pesanan
{
    public class OrderItemManipulator : MonoBehaviour
    {
        // Get Sellable object sprite
        // Get Trash sprite
        // Get Crafting Material Sprite

        [SerializeField] private Image targetSellableObject;
        [SerializeField] private Image targetTrash;
        [SerializeField] private Image targetCraftingMaterial;


        public void SetupOrderItem(Sprite sellableObjectSprite, Sprite trashSprite, Sprite craftingMaterialSprite)
        {
            targetSellableObject.sprite = sellableObjectSprite;
            targetTrash.sprite = trashSprite;
            targetCraftingMaterial.sprite = craftingMaterialSprite;
        }
    }
}