using UnityEngine;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterController))]
    public class AnimationHandler : MonoBehaviour
    {
        private Animator _animator;
        private CharacterController _characterController;
        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
            _animator.applyRootMotion = false;
        }

        // Update is called once per frame
        void Update()
        {
            var characterVelocity = _characterController.velocity.magnitude;
            
            var isWalking = characterVelocity > 0.1;
            var isRunning = characterVelocity > 3;
            
            // See the parameters at ./Characters/Player/Animations/Player_AC
            _animator.SetBool("isWalking", isWalking);
            _animator.SetBool("isRunning", isRunning);

        }
    }
}
