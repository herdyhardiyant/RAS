using System;
using Controls;
using UnityEngine;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float walkSpeed = 2.0f;
        [SerializeField] private PlayerInputMap playerInputMap;
        [SerializeField] private float runSpeed = 4.0f;
        [SerializeField] private CraftingTableInteraction craftingTableInteraction;

        public bool IsFalling => _isFalling;
        
        
        private CharacterController _characterController;
        private Vector3 _playerVerticalVelocity;
        private const float GravityValue = -9.81f;
        private Vector3 _moveDirection;
        private bool _isFalling;

        // TODO Character teleport back to the ground when fall out of the map

        void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _isFalling = true;
        }

        void Update()
        {
            if (craftingTableInteraction.IsCrafting)
            {
                _characterController.Move(Vector3.zero);
                return;
            }

            UpdatePlayerGravity();
            
            _isFalling =  _characterController.velocity.y < 0 && !_characterController.isGrounded;
            
            _moveDirection = GetInputMoveDirection();

            RotatePlayerToMoveDirection();
            
            MovePlayer();
        }

        private void UpdatePlayerGravity()
        {
            var isGrounded = _characterController.isGrounded;

            if (isGrounded && _playerVerticalVelocity.y < 0)
            {
                _playerVerticalVelocity.y = 0;
                _characterController.Move(_playerVerticalVelocity * Time.deltaTime);
            }
            else
            {
                _playerVerticalVelocity.y += GravityValue * Time.deltaTime;
                _characterController.Move(_playerVerticalVelocity * Time.deltaTime);
            }
            
        }

        private void RotatePlayerToMoveDirection()
        {
            if (_moveDirection != Vector3.zero)
                transform.forward = _moveDirection;
        }

        private void MovePlayer()
        {
            var move = _moveDirection;
            move *= playerInputMap.IsRunPressed ? runSpeed : walkSpeed;
            _characterController.Move(move * Time.deltaTime);
        }

        private Vector3 GetInputMoveDirection()
        {
            var moveDirection = Vector3.zero;
            if (playerInputMap.IsUpPressed)
                moveDirection.z = 1;

            if (playerInputMap.IsDownPressed)
                moveDirection.z = -1;

            if (playerInputMap.IsRightPressed)
                moveDirection.x = 1;

            if (playerInputMap.IsLeftPressed)
                moveDirection.x = -1;

            return moveDirection.normalized;
        }
    }
}