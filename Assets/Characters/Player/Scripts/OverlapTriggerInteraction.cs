using System;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class OverlapTriggerInteraction : MonoBehaviour
    {
        
        [SerializeField] private HeldObjectInteraction heldObjectInteraction;
        
        public GameObject TriggeredObject => _triggeredObject;
        private GameObject _triggeredObject;

        private void FixedUpdate()
        {
            var objectTransform = transform;

            var overlapCenter = objectTransform.position;
            var overlapHalfExtents = objectTransform.localScale;
            
            Collider[] receiverObjects = Physics.OverlapBox(
                overlapCenter,
                overlapHalfExtents / 2,
                Quaternion.identity,
                LayerMask.GetMask("Input Receiver")
            );
            
            Collider[] pickupObjects = Physics.OverlapBox(
                overlapCenter,
                overlapHalfExtents / 2,
                Quaternion.identity,
                LayerMask.GetMask("Pickup Item")
            );

            if (heldObjectInteraction.IsHoldingObject)
            {
                pickupObjects = null;   
            }
            
            if(pickupObjects?.Length > 0)
            {
                _triggeredObject = pickupObjects[0].gameObject;
            }
            else if(receiverObjects.Length > 0)
            {
                _triggeredObject = receiverObjects[0].gameObject;

            }
            else
            {
                _triggeredObject = null;
            }

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, transform.localScale);
        }
    }
}