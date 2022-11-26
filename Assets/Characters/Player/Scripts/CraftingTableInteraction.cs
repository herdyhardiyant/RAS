using System;
using Interfaces;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class CraftingTableInteraction : MonoBehaviour
    {
        public bool IsCrafting => _craftingTable != null && _craftingTable.IsCrafting;

        [SerializeField] private HeldObjectInteraction heldObjectInteraction;

        private ICraftingTable _craftingTable;

        public void InteractCraftingTable(ICraftingTable craftingTable)
        {
            if (!heldObjectInteraction.IsHoldingObject) return;
            if (craftingTable.IsCrafting) return;
            _craftingTable = craftingTable;

            var material = heldObjectInteraction.GetHeldObjectAndDropFromPlayer();

            var isSuccessStartCrafting = craftingTable.StartCrafting(material);

            if (!isSuccessStartCrafting)
            {
                heldObjectInteraction.InteractObject(material);
            }
        }
    }
}