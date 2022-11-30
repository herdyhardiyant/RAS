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

        //TODO Detach held object when player is falling
        
        
        //TODO Return pickup item to pool when it is dropped out of the map
        
        
        private void Awake()
        {
            _triggeredObject = null;
        }

        private void Update()
        {
            //TODO Refactor this for better readability

            if (!playerInputMap.IsInteractClicked) return;

            var isInteractingHeldObject = _triggeredObject && _triggeredObject.CompareTag("Trash") ||
                                          _triggeredObject && _triggeredObject.CompareTag("Material") ||
                                          _triggeredObject && _triggeredObject.CompareTag("SellObject") ||
                                          heldObjectInteraction.IsHoldingObject;

          

            if (_triggeredObject)
            {
                var isMachine = _triggeredObject.TryGetComponent<IMachine>(out var machine);
                if (isMachine)
                {
                    machineInteraction.InteractMachine(machine);
                    return;
                }
                
                var isCraftingTable = _triggeredObject.TryGetComponent<ICraftingTable>(out var craftingTable);
                if (isCraftingTable)
                {
                    craftingTableInteraction.InteractCraftingTable(craftingTable);
                    return;
                }

                var isHoldingObject = heldObjectInteraction.IsHoldingObject;
                var isTrashContainer = _triggeredObject.TryGetComponent<ITrashContainer>(out var trashContainer);
                if (isTrashContainer && !isHoldingObject)
                {
                    var newTrash = trashContainer.GetInstantiatedTrash();
                    heldObjectInteraction.InteractObject(newTrash);
                    return;
                }
                
            }
            
            
            
            if (isInteractingHeldObject)
            {
                heldObjectInteraction.InteractObject(_triggeredObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _triggeredObject = other.gameObject;
        }

        private void OnTriggerExit(Collider other)
        {
            _triggeredObject = null;
        }
    }
}