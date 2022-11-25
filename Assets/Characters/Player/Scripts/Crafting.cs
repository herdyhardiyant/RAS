using System;
using Interfaces;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class Crafting : MonoBehaviour
    {
        
        [SerializeField] private HeldObjectInteraction heldObjectInteraction;

        //TODO When player hold an item, place the item on the bench, when the bench is empty
        //TODO When the bench has an item, and the player is holding an item, do nothing
        //TODO Press F to craft when the bench has an item and the player is not holding an item
        //TODO When the bench is empty, and the player press F, do nothing
        //TODO When player is crafting, show hammering animation

        public void PutObjectToTheCraftingTable(ICraftingTable craftingTable)
        {
            if(!heldObjectInteraction.IsHoldingObject) return;
            var heldObject = heldObjectInteraction.HoldObject;
            craftingTable.PutObjectOnCraftingBench(heldObject);

        }
        
      
        
    }
}
