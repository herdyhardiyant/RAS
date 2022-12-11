using System;
using Controls;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Characters.Player.Scripts
{
    
    public class Interaction : MonoBehaviour
    {
        //TODO Use required component instead and get the component from awake
        [SerializeField] private MachineInteraction machineInteraction;
        [SerializeField] private HeldObjectInteraction heldObjectInteraction;
        [SerializeField] private PlayerInputMap playerInputMap;
        [SerializeField] private CraftingTableInteraction craftingTableInteraction;
        [SerializeField] private Movement movement;
        [SerializeField] private OverlapTriggerInteraction overlapTriggerInteraction;

        private GameObject _triggeredObject;
        private Rigidbody _holdObjectRigidBody;

        private void Awake()
        {
            _triggeredObject = null;
        }

        private void Update()
        {
            //TODO Refactor this for better readability

            DropHeldObjectWhenFall();

            if (!playerInputMap.IsInteractClicked) return;

            if(movement.IsFalling) return;
            _triggeredObject = overlapTriggerInteraction.TriggeredObject;
            
            
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

                var isCashier = _triggeredObject.TryGetComponent<ICashier>(out var cashier);
                if (isCashier && isHoldingObject)
                {
                    var heldObject = heldObjectInteraction.GetHeldObjectAndDropFromPlayer();
                    var isSellable = heldObject.TryGetComponent<ISellable>(out var sellable);
                    if (isSellable)
                    {
                        cashier.Sell(sellable, heldObject);
                    }
                    else
                    {
                        heldObjectInteraction.InteractObject(heldObject);
                    }

                }

            }

            var isInteractingHeldObject = _triggeredObject && _triggeredObject.CompareTag("Trash") ||
                                          _triggeredObject && _triggeredObject.CompareTag("Material") ||
                                          _triggeredObject && _triggeredObject.CompareTag("SellObject") ||
                                          heldObjectInteraction.IsHoldingObject;
            
            if (isInteractingHeldObject)
            {
                heldObjectInteraction.InteractObject(_triggeredObject);
            }
            
            
            
        }

        private void DropHeldObjectWhenFall()
        {
            if (heldObjectInteraction.IsHoldingObject)
            {
                if (movement.IsFalling)
                {
                    heldObjectInteraction.DropHoldObject();
                }
            }
        }
        
        //
        // private void OnTriggerEnter(Collider other)
        // {
        //     _triggeredObject = other.gameObject;
        // }
        //
        // private void OnTriggerExit(Collider other)
        // {
        //     _triggeredObject = null;
        // }
    }
}