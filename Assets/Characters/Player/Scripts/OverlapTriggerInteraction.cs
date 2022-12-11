using System;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class OverlapTriggerInteraction : MonoBehaviour
    {
        public GameObject TriggeredObject => _triggeredObject;
        private GameObject _triggeredObject;
        
        private void FixedUpdate()
        {
            var objectTransform = transform;
            
            Collider[] collidedObjects = Physics.OverlapBox(
                objectTransform.position,
                objectTransform.localScale / 2,
                Quaternion.identity,
                LayerMask.GetMask("Interactable")
            );
            _triggeredObject = collidedObjects[0].gameObject;
            foreach (var collidedObject in collidedObjects)
            {
                print(collidedObject.name);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, transform.localScale);
        }
    }
}
