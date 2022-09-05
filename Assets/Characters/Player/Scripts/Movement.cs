using UnityEngine;
using PlayerInput = Settings.PlayerInput;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour, IPlayerFeatureControllable
    {
        private CharacterController _characterController;
        private Vector3 _playerVerticalVelocity;
        
        [SerializeField]
        private float walkSpeed = 2.0f;

        [SerializeField] private float runSpeed = 4.0f;
        
        private const float _gravityValue = -9.81f;
        private PlayerInput _playerInput;

        private bool _isMovementEnabled;
        
        public void SetEnable(bool isEnable)
        {
            _isMovementEnabled = isEnable;
        }

        public void ToggleEnable()
        {
            _isMovementEnabled = !_isMovementEnabled;
        }

        // Start is called before the first frame update
        void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _playerInput = gameObject.AddComponent<PlayerInput>();
            _isMovementEnabled = true;
        }

        // Update is called once per frame
        void Update()
        {

            UpdatePlayerGravity();
            var moveDirection = GetInputMoveDirection();
            
            if(!_isMovementEnabled)
                return;
            
            RotatePlayerToMoveDirection(moveDirection);
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
        
        private void RotatePlayerToMoveDirection(Vector3 moveDirection)
        {
            if (moveDirection != Vector3.zero)
                transform.forward = moveDirection;
        }
        
        private void MovePlayer(Vector3 moveDirection)
        {

            var move = moveDirection;
            move *= _playerInput.IsRunPressed ? runSpeed : walkSpeed;
            _characterController.Move(move * Time.deltaTime);
        }
        
        private Vector3 GetInputMoveDirection()
        {
            var moveDirection = Vector3.zero;
            if (_playerInput.IsUpPressed)
                moveDirection.z = 1;
            
            if (_playerInput.IsDownPressed)
                moveDirection.z = -1;

            if (_playerInput.IsRightPressed)
                moveDirection.x = 1;
            
            if (_playerInput.IsLeftPressed)
                moveDirection.x = -1;

            return moveDirection.normalized;
        }
        
    }
}
