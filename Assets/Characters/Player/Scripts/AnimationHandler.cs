using UnityEngine;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterController))]
    public class AnimationHandler : MonoBehaviour
    {
        [SerializeField] private GameObject hammerOnPlayerHand;
        [SerializeField] private HeldObjectInteraction heldObjectInteraction;
        [SerializeField] private CraftingTableInteraction craftingTableInteraction;
        [SerializeField] private Movement movement;

        private Animator _animator;
        private CharacterController _characterController;

        private const string IsWalkingStateName = "isWalking";
        private const string IsRunningStateName = "isRunning";
        private const string IsFallingStateName = "isFalling";

        private const string HoldingLayerName = "Holding";
        private const string CraftingLayerName = "Crafting";

        private static readonly int IsWalking = Animator.StringToHash(IsWalkingStateName);
        private static readonly int IsRunning = Animator.StringToHash(IsRunningStateName);
        private static readonly int IsFalling = Animator.StringToHash(IsFallingStateName);

        private int _craftingAnimationLayerIndex;
        void Awake()
        {
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
            _animator.applyRootMotion = false;
            _craftingAnimationLayerIndex = _animator.GetLayerIndex(CraftingLayerName);
        }

        void Update()
        {
            CraftingAnimationHandler();
            
            _animator.SetBool(IsFalling, movement.IsFalling || movement.IsKnockedBack);
            
            UpdateAnimatorStateFromVelocity();

            UpdateHoldingAnimationLayerWeight();
        }

        private void CraftingAnimationHandler()
        {
            _animator.SetLayerWeight(_craftingAnimationLayerIndex, craftingTableInteraction.IsCrafting.GetHashCode());
            hammerOnPlayerHand.SetActive(craftingTableInteraction.IsCrafting);
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
            _animator.SetLayerWeight(holdingAnimationLayerIndex, heldObjectInteraction.IsHoldingObject.GetHashCode());
        }
    }
}