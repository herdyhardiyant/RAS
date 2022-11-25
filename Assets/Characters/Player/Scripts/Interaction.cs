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

        public bool IsCrafting => _isCrafting;

        private GameObject _triggeredObject;
        private Rigidbody _holdObjectRigidBody;
        private bool _isCrafting;

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
                _triggeredObject.TryGetComponent<ICraftingTable>(out var craftingTable);

                if (heldObjectInteraction.IsHoldingObject)
                {
                    craftingTable.PutObjectOnCraftingBench(heldObjectInteraction.GetHeldObjectAndDropFromPlayer());
                }
            }
            else if (_triggeredObject && _triggeredObject.CompareTag("PickupItem") ||
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
            else if (other.CompareTag("PickupItem"))
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
    }
}