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


        // Add box collider to detect material and machine
        // Press F to pickup material or put material to machine when box collider is triggered

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
            if (_inputControl.IsInteractClicked)
            {
                if (_triggeredObject && _triggeredObject.CompareTag("Machine"))
                {
                    var machine = _triggeredObject.GetComponent<IMachine>();
                    if (_holdObject)
                    {
                        machine.InputMaterial(_holdObject);
                        _holdObject = null;
                    }
                    
                }
                else
                {
                    HoldObjectInteraction();
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
            }
        }

        private void OnTriggerExit(Collider other)
        {
            _triggeredObject = null;
        }

        private void HoldObjectInteraction()
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

            _holdObject = _triggeredObject;
            _holdObjectRigidBody = _holdObject.GetComponent<Rigidbody>();
            _holdObjectRigidBody.isKinematic = true;

            _holdObject.transform.parent = transform;
            _holdObject.transform.position = holdingPoint.position;
            _holdObject.transform.forward = transform.forward;

            _triggeredObject = null;
        }
    }
}