using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        private CharacterController _characterController;
        private Keyboard _keyboard;
        private Vector3 _playerVerticalVelocity;
        
        private float _playerSpeed = 2.0f;
        private float _gravityValue = -9.81f;
        
        // Start is called before the first frame update
        void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _keyboard = Keyboard.current;
        }

        // Update is called once per frame
        void Update()
        {

            UpdatePlayerGravity();
            var moveDirection = GetInputMoveDirection();
            RotatePlayerOnMove(moveDirection);
            MovePlayer(moveDirection);
        }
        private void UpdatePlayerGravity()
        {
            var isGrounded = _characterController.isGrounded;
            
            if (isGrounded && _playerVerticalVelocity.y < 0)
                _playerVerticalVelocity.y = 0;
            
            _playerVerticalVelocity.y += _gravityValue * Time.deltaTime;
            _characterController.Move(_playerVerticalVelocity * Time.deltaTime);
        }
        private void RotatePlayerOnMove(Vector3 moveDirection)
        {
            if (moveDirection != Vector3.zero)
                transform.forward = moveDirection;
        }
        private void MovePlayer(Vector3 moveDirection)
        {
            var move = moveDirection * _playerSpeed;
            _characterController.Move(move * Time.deltaTime);
        }
        private Vector3 GetInputMoveDirection()
        {
            var moveDirection = Vector3.zero;
            if (_keyboard.wKey.isPressed)
                moveDirection.z = 1;
            
            if (_keyboard.sKey.isPressed)
                moveDirection.z = -1;

            if (_keyboard.dKey.isPressed)
                moveDirection.x = 1;
            
            if (_keyboard.aKey.isPressed)
                moveDirection.x = -1;

            return moveDirection.normalized;
        }
        
    }
}
