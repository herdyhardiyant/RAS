using System;
using Controls;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Characters.Player.Scripts
{
    public class Interaction : MonoBehaviour
    {
        [SerializeField] private MachineInteraction machineInteraction;
        [SerializeField] private HeldObjectInteraction heldObjectInteraction;
        [SerializeField] private PlayerInputMap playerInputMap;
        [SerializeField] private CraftingTableInteraction craftingTableInteraction;

        private GameObject _triggeredObject;
        private Rigidbody _holdObjectRigidBody;

        private void Awake()
        {
            _triggeredObject = null;
        }

        private void Update()
        {
            if (!playerInputMap.IsInteractClicked) return;

            if (_triggeredObject && _triggeredObject.CompareTag("Machine"))
            {
                machineInteraction.InteractMachine(_triggeredObject);
            }
            else if (_triggeredObject && _triggeredObject.CompareTag("Crafting"))
            {
                // CraftingTableInteraction();
               var isCraftingTable = _triggeredObject.TryGetComponent<ICraftingTable>(out var craftingTable);
               
               if (isCraftingTable)
                {
                    craftingTableInteraction.InteractCraftingTable(craftingTable);
                }    
            }
            else if (_triggeredObject && _triggeredObject.CompareTag("Trash") ||
                     _triggeredObject && _triggeredObject.CompareTag("Material") ||
                     heldObjectInteraction.IsHoldingObject)
            {
                heldObjectInteraction.InteractObject(_triggeredObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Machine"))
            {
                _triggeredObject = other.gameObject;
            }
            else if (other.CompareTag("Trash") || other.CompareTag("Material"))
            {
                _triggeredObject = other.gameObject;
            }
            else if (other.CompareTag("Crafting"))
            {
                _triggeredObject = other.gameObject;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            _triggeredObject = null;
        }

        private void CraftingTableInteraction()
        {
            _triggeredObject.TryGetComponent<ICraftingTable>(out var craftingTable);

            if (!heldObjectInteraction.IsHoldingObject) return;

            var material = heldObjectInteraction.GetHeldObjectAndDropFromPlayer();

            var isSuccessStartCrafting = craftingTable.StartCrafting(material);

            if (!isSuccessStartCrafting)
            {
                heldObjectInteraction.InteractObject(material);
            }
        }
    }
}