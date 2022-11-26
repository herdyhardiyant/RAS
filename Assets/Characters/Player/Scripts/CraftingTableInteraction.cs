using System;
using Interfaces;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class CraftingTableInteraction : MonoBehaviour
    {
        public bool IsCrafting => _isCrafting;

        [SerializeField] private HeldObjectInteraction heldObjectInteraction;

        private bool _isCrafting;

        private void Awake()
        {
            _isCrafting = false;
        }

        public void InteractCraftingTable(ICraftingTable craftingTable)
        {
            if (!heldObjectInteraction.IsHoldingObject) return;

            var material = heldObjectInteraction.GetHeldObjectAndDropFromPlayer();

            var isSuccessStartCrafting = craftingTable.StartCrafting(material);

            if (!isSuccessStartCrafting)
            {
                heldObjectInteraction.InteractObject(material);
            }

            _isCrafting = craftingTable.IsCrafting;
        }
    }
}