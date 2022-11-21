using UnityEngine;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterController))]
    public class AnimationHandler : MonoBehaviour
    {
        [SerializeField] private Interaction playerInteraction;

        private Animator _animator;
        private CharacterController _characterController;

        private const string IsWalkingStateName = "isWalking";
        private const string IsRunningStateName = "isRunning";

        private const string HoldingLayerName = "Holding";

        private static readonly int IsWalking = Animator.StringToHash(IsWalkingStateName);
        private static readonly int IsRunning = Animator.StringToHash(IsRunningStateName);


        void Awake()
        {
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
            _animator.applyRootMotion = false;
        }

        void Update()
        {
            UpdateAnimatorStateFromVelocity();

            UpdateHoldingAnimationLayerWeight();
        }

        private void UpdateAnimatorStateFromVelocity()
        {
            var characterVelocity = _characterController.velocity.magnitude;
            var isWalking = characterVelocity > 0.1;
            var isRunning = characterVelocity > 3;
            _animator.SetBool(IsWalking, isWalking);
            _animator.SetBool(IsRunning, isRunning);
        }

        private void UpdateHoldingAnimationLayerWeight()
        {
            var holdingAnimationLayerIndex = _animator.GetLayerIndex(HoldingLayerName);
            _animator.SetLayerWeight(holdingAnimationLayerIndex, playerInteraction.IsHolding.GetHashCode());
        }
    }
}