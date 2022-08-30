using System;
using Environment.Scripts;
using UnityEngine;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class Interact : MonoBehaviour
    {

        private BoxCollider _interactTrigger;
        // Start is called before the first frame update
        void Start()
        {
            _interactTrigger = GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var interactedObject = other.GetComponent<IEnvironmentInteractable>();
            if (interactedObject == null)
                return;

            //TODO Show how to interact in the ui
            //TODO Keyboard input to interact
            //TODO show the result of the interaction in the ui

            interactedObject.Interact();
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
