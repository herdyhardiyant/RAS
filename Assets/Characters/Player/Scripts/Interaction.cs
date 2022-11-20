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
        
        public bool IsHolding => _holdObject != null;
        
        private GameObject _interactedObject;
        private PlayerInputMap _inputControl;
        private GameObject _holdObject;
        private Rigidbody _holdObjectRigidBody;
        
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

                if (_holdObject == null)
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
            _holdObject.transform.parent = null;
            _holdObject = null;
            _holdObjectRigidBody.isKinematic = false;
            _holdObjectRigidBody = null;
        }

        private void PickupObject()
        {
            _holdObject = _interactedObject;
            _holdObjectRigidBody = _holdObject.GetComponent<Rigidbody>();
            _holdObjectRigidBody.isKinematic = true;
            
            _holdObject.transform.parent = transform;
            _holdObject.transform.position = holdingPoint.position;
            _holdObject.transform.forward = transform.forward;
            
            _interactedObject = null;
        }
        
        

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("PickupItem"))
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