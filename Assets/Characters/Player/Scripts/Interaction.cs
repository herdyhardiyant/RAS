using System;
using Controls;
using UnityEngine;
using UnityEngine.UI;

namespace Characters.Player.Scripts
{
    public class Interaction : MonoBehaviour
    {
        // Add box collider to detect material and machine
        // Press F to pickup material or put material to machine when box collider is triggered
        
        private GameObject _interactedObject;
        private PlayerInputMap _inputControl;
        private GameObject _holdingObject;
        
        
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
            print("Put");
            _holdingObject.transform.parent = null;
            _holdingObject = null;
        }

        private void PickupObject()
        {
            _holdingObject = _interactedObject;
            _holdingObject.transform.parent = transform;
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