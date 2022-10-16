using System;
using Controls;
using Environment.Interfaces;
using EventSystems;
using UnityEngine;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        private CharacterController _characterController;
        private Vector3 _playerVerticalVelocity;

        [SerializeField] private float walkSpeed = 2.0f;

        [SerializeField] private float runSpeed = 4.0f;
        private const float _gravityValue = -9.81f;
        private PlayerInputMap _playerInputMap;
        private Vector3 _moveDirection;

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _playerInputMap = gameObject.AddComponent<PlayerInputMap>();
            MouseClickEventHandler.OnMouseClickHoveredObject += RotatePlayerToClickedObject;
        }

        void Update()
        {
            UpdatePlayerGravity();
            if (GameplayUIEventHandler.IsInventoryOpen)
                return;

            _moveDirection = GetInputMoveDirection();

            RotatePlayerToMoveDirection();
            MovePlayer();
        }

        private void RotatePlayerToClickedObject(IInteractable hoveredObject)
        {
            if (hoveredObject == null) return;
            var hoveredObjectPosition = hoveredObject.Position;
            var playerTransform = transform;
            var directionToLook = (hoveredObjectPosition - playerTransform.position).normalized;
            var directionToLook2d = new Vector3(directionToLook.x, 0, directionToLook.z);
            playerTransform.forward = directionToLook2d;
        }

        private void UpdatePlayerGravity()
        {
            var isGrounded = _characterController.isGrounded;

            if (isGrounded && _playerVerticalVelocity.y < 0)
                _playerVerticalVelocity.y = 0;

            _playerVerticalVelocity.y += _gravityValue * Time.deltaTime;
            _characterController.Move(_playerVerticalVelocity * Time.deltaTime);
        }

        private void RotatePlayerToMoveDirection()
        {
            if (_moveDirection != Vector3.zero)
                transform.forward = _moveDirection;
        }

        private void MovePlayer()
        {
            var move = _moveDirection;
            move *= _playerInputMap.IsRunPressed ? runSpeed : walkSpeed;
            _characterController.Move(move * Time.deltaTime);
        }

        private Vector3 GetInputMoveDirection()
        {
            var moveDirection = Vector3.zero;
            if (_playerInputMap.IsUpPressed)
                moveDirection.z = 1;

            if (_playerInputMap.IsDownPressed)
                moveDirection.z = -1;

            if (_playerInputMap.IsRightPressed)
                moveDirection.x = 1;

            if (_playerInputMap.IsLeftPressed)
                moveDirection.x = -1;

            return moveDirection.normalized;
        }

        private void OnDisable()
        {
            MouseClickEventHandler.OnMouseClickHoveredObject -= RotatePlayerToClickedObject;
        }
    }
}