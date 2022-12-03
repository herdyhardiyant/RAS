using UnityEngine;

namespace Characters.Player.Scripts
{            
    // See the parameters at ./Characters/Player/Animations/Player_AC
    public enum AnimationParameters
    {
        isWalking,
        isRunning,
    }
    
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterController))]
    public class AnimationHandler : MonoBehaviour
    {
        private Animator _animator;
        private CharacterController _characterController;

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
            _animator.applyRootMotion = false;
        }
        
        void Update()
        {
            var characterVelocity = _characterController.velocity.magnitude;
            var isWalking = characterVelocity > 0.1;
            var isRunning = characterVelocity > 3;
            _animator.SetBool(AnimationParameters.isWalking.ToString(), isWalking);
            _animator.SetBool(AnimationParameters.isRunning.ToString(), isRunning);

        }
    }
}
