using System;
using Controls;
using Interfaces;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class MachineInteraction : MonoBehaviour
    {
        [SerializeField] private HeldObjectInteraction heldObjectInteraction;

        public void InteractMachine(GameObject interactedMachine)
        {
            interactedMachine.TryGetComponent<IMachine>(out var machine);

            if (machine.IsProcessing)
            {
                return;
            }

            if (machine.IsHoldingOutputItem && !heldObjectInteraction.IsHoldingObject)
            {
                TakeOutObjectFromMachineAndHoldIt(machine);
            }
            else if (heldObjectInteraction.IsHoldingObject && !machine.IsHoldingOutputItem)
            {
                InsertHeldObjectToMachine(machine);
            }
        }

        private void TakeOutObjectFromMachineAndHoldIt(IMachine machine)
        {
            var materialOutputFromMachine = machine.GetResultAfterProcessing();
            var material = Instantiate(materialOutputFromMachine);
            heldObjectInteraction.InteractObject(material);
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