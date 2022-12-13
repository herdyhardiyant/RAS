using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Pesanan
{
    public class OrderItemManipulator : MonoBehaviour
    {
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