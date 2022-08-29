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
        }

        // Update is called once per frame
        void Update()
        {
            if (!_characterController)
                return;
            
            if (!_animator)
                return;

            var characterVelocity = _characterController.velocity.magnitude;
            var isWalking = characterVelocity > 0.1;
            //TODO fix string based property lookup
            _animator.SetBool("isWalking", isWalking);
        }
    }
}
