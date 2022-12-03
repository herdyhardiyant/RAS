using System;
using Controls;
using Interfaces;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class MachineInteraction : MonoBehaviour
    {
        [SerializeField] private HeldObjectInteraction heldObjectInteraction;

        public void InteractMachine(IMachine interactedMachine)
        {
            if (interactedMachine.IsProcessing)
            {
                return;
            }

            if (interactedMachine.IsHoldingOutputItem && !heldObjectInteraction.IsHoldingObject)
            {
                TakeOutObjectFromMachineAndHoldIt(interactedMachine);
            }
            else if (heldObjectInteraction.IsHoldingObject && !interactedMachine.IsHoldingOutputItem)
            {
                InsertHeldObjectToMachine(interactedMachine);
            }
        }

        private void TakeOutObjectFromMachineAndHoldIt(IMachine machine)
        {
            var materialOutputFromMachine = machine.GetInstantiateResultAfterSmelting();
            // var material = Instantiate(materialOutputFromMachine);
            heldObjectInteraction.InteractObject(materialOutputFromMachine);
        }

        private void InsertHeldObjectToMachine(IMachine machine)
        {
            var heldObject = heldObjectInteraction.GetHeldObjectAndDropFromPlayer();
            var isMaterialInserted = machine.InputMaterial(heldObject);
            if (isMaterialInserted)
            {
                heldObjectInteraction.DropHoldObject();
            }
            else
            {
                heldObjectInteraction.InteractObject(heldObject);
            }
        }
    }
}