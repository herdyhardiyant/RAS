using System;
using Controls;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Characters.Player.Scripts
{
    public class Interaction : MonoBehaviour
    {
        [SerializeField] private Transform holdingPoint;

        public bool IsHolding => _holdObject != null;

        private GameObject _triggeredObject;
        private PlayerInputMap _inputControl;
        private GameObject _holdObject;
        private Rigidbody _holdObjectRigidBody;

        private void Awake()
        {
            _triggeredObject = null;
            _inputControl = gameObject.AddComponent<PlayerInputMap>();
        }

        private void Update()
        {
            if (!_inputControl.IsInteractClicked) return;

            if (_triggeredObject && _triggeredObject.CompareTag("Machine"))
            {
                MachineInteraction();
            }
            else
            {
                HoldableObjectInteraction();
            }
        }

        private void MachineInteraction()
        {
            var machine = _triggeredObject.GetComponent<IMachine>();

            if (machine.IsProcessing)
            {
                return;
            }

            if (machine.IsHoldingOutputItem && !_holdObject)
            {
           
                var materialOutputFromMachine = machine.GetResultAfterProcessing();
                var material = Instantiate(materialOutputFromMachine);
                HoldObjectOnHand(material);
            }
            else if (_holdObject && !machine.IsHoldingOutputItem)
            {
       
                var isMaterialInserted = machine.InputMaterial(_holdObject);
                _holdObject = isMaterialInserted ? null : _holdObject;
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
        }

        private void OnTriggerExit(Collider other)
        {
            _triggeredObject = null;
        }

        private void HoldableObjectInteraction()
        {
            if (!_holdObject)
            {
                PickupTriggeredObject();
            }
            else
            {
                DropHoldObject();
            }
        }

        private void DropHoldObject()
        {
            _holdObject.transform.parent = null;
            _holdObject = null;
            _holdObjectRigidBody.isKinematic = false;
            _holdObjectRigidBody = null;
        }

        private void PickupTriggeredObject()
        {
            if (!_triggeredObject)
                return;

            HoldObjectOnHand(_triggeredObject);

            _triggeredObject = null;
        }

        private void HoldObjectOnHand(GameObject holdedObject)
        {
            _holdObject = holdedObject;
            _holdObjectRigidBody = _holdObject.GetComponent<Rigidbody>();
            _holdObjectRigidBody.isKinematic = true;

            _holdObject.transform.parent = transform;
            _holdObject.transform.position = holdingPoint.position;
            _holdObject.transform.forward = transform.forward;
        }
    }
}