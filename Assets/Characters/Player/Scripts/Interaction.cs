using System;
using Controls;
using UnityEngine;
using UnityEngine.UI;

namespace Characters.Player.Scripts
{
    public class Interaction : MonoBehaviour
    {
        
        [SerializeField] private Transform holdingPoint;
        
        
        // Add box collider to detect material and machine
        // Press F to pickup material or put material to machine when box collider is triggered
        
        public bool IsHolding => _holdingObject != null;
        
        private GameObject _interactedObject;
        private PlayerInputMap _inputControl;
        private GameObject _holdingObject;
        private Rigidbody _holdingObjectRigidBody;
        
        private void Awake()
        {
            _interactedObject = null;
            // Create component
            _inputControl = gameObject.AddComponent<PlayerInputMap>();
        }

        private void Update()
        {

            if (_inputControl.IsInteractClicked)
            {

                if (_holdingObject == null)
                {
                    
                    if (!_interactedObject)
                        return;
                    
                    print("Pickup");
                    PickupObject();
                    
                }
                else
                {
                    DropObject();
                }

            }
            
            
        }

        private void DropObject()
        {
            _holdingObject.transform.parent = null;
            _holdingObject = null;
            _holdingObjectRigidBody.isKinematic = false;
            _holdingObjectRigidBody = null;
        }

        private void PickupObject()
        {
            _holdingObject = _interactedObject;
            _holdingObjectRigidBody = _holdingObject.GetComponent<Rigidbody>();
            _holdingObjectRigidBody.isKinematic = true;
            
            _holdingObject.transform.parent = transform;
            _holdingObject.transform.position = holdingPoint.position;
            _holdingObject.transform.forward = transform.forward;
            
            _interactedObject = null;
        }
        
        

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Interactable"))
                return;

            print(other.name);

            _interactedObject = other.gameObject;
        }

        private void OnTriggerExit(Collider other)
        {
            _interactedObject = null;
        }
    }
}