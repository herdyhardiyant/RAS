using System;
using Controls;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Characters.Player.Scripts
{
    public class Interaction : MonoBehaviour
    {
        [SerializeField] private MachineInteraction machineInteraction;
        [SerializeField] private HeldObjectInteraction heldObjectInteraction;
        
        public bool IsCrafting => _isCrafting;
        
        private GameObject _triggeredObject;
        private PlayerInputMap _inputControl;
        private Rigidbody _holdObjectRigidBody;
        private bool _isCrafting;

        private void Awake()
        {
            _triggeredObject = null;
            _inputControl = gameObject.AddComponent<PlayerInputMap>();
        }

        private void Update()
        {
            _isCrafting = _inputControl.IsDebugKeyPressed;

            if (!_inputControl.IsInteractClicked) return;

            if (_triggeredObject && _triggeredObject.CompareTag("Machine"))
            {
                machineInteraction.InteractMachine(_triggeredObject);
            }
            else
            {
                heldObjectInteraction.ObjectInteract(_triggeredObject);
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
        
    }
}