using System;
using Controls;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class HeldObjectInteraction : MonoBehaviour
    {
        [SerializeField] private Transform holdingPoint;

        public bool IsHoldingObject => _holdObject != null;

        //TODO Drop object when holdObject getter is called or create TransferObject method
        public GameObject HoldObject
        {
            get
            {
                if (_holdObject)
                {
                    var holdObject = _holdObject;
                    DropHoldObject();
                    return holdObject.gameObject;
                }

                return null;
            }
        }

        private GameObject _holdObject;
        private Rigidbody _holdObjectRigidBody;

        public void HoldObjectOnHand(GameObject holdedObject)
        {
            _holdObject = holdedObject;
            _holdObject.TryGetComponent<Rigidbody>(out var rigidBody);
            _holdObjectRigidBody = rigidBody;
            _holdObjectRigidBody.isKinematic = true;

            _holdObject.transform.parent = transform;
            _holdObject.transform.position = holdingPoint.position;
            _holdObject.transform.forward = transform.forward;
        }

        public void DropHoldObject()
        {
            if (!_holdObject) return;
            _holdObject.transform.parent = null;
            _holdObject = null;
            _holdObjectRigidBody.isKinematic = false;
            _holdObjectRigidBody = null;
        }

        public void ObjectInteract(GameObject interactedObject)
        {
            if (!_holdObject)
            {
                PickupObject(interactedObject);
            }
            else
            {
                DropHoldObject();
            }
        }

        private void PickupObject(GameObject objectToPickup)
        {
            if (!objectToPickup)
                return;

            HoldObjectOnHand(objectToPickup);
        }
    }
}