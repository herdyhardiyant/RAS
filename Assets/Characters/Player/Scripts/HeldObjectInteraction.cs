using System;
using Controls;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class HeldObjectInteraction : MonoBehaviour
    {
        [SerializeField] private Transform holdingPoint;
        [SerializeField] private AudioClip pickSound;
        [SerializeField] private AudioClip dropSound;
       
        
        
        public bool IsHoldingObject => _holdObject != null;

        private AudioSource _audioSource;
        
        public GameObject GetHeldObjectAndDropFromPlayer()
        {
           
            if (_holdObject)
            {
                var holdObject = _holdObject;
                DropHoldObject();
                return holdObject.gameObject;
            }

            return null;
            
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
            _audioSource.PlayOneShot(dropSound);
        }

        
        /// <summary>
        /// Start interact with object that can be held. if holding an object, drop it.
        /// If not, try to pick up the object
        /// </summary>
        /// <param name="interactedObject"></param>
        public void InteractObject(GameObject interactedObject)
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
            _audioSource.PlayOneShot(pickSound);
            HoldObjectOnHand(objectToPickup);
        }

        private void Awake()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
}