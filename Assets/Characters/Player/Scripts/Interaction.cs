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
        [SerializeField] private Crafting crafting;
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

            if (!_triggeredObject) return;

            if (_triggeredObject.CompareTag("Machine"))
            {
                machineInteraction.InteractMachine(_triggeredObject);
            }
            else if(_triggeredObject.CompareTag("PickupItem"))
            {
                heldObjectInteraction.ObjectInteract(_triggeredObject);
            } else if (_triggeredObject.CompareTag("Crafting"))
            {
                if (_triggeredObject.TryGetComponent<ICraftingTable>(out var craftingTable))
                {
                    craftingTable.PutObjectOnCraftingBench(heldObjectInteraction.HoldObject);
                    
                }
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
            } else if (other.CompareTag("Crafting"))
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