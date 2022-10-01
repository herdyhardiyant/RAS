using System;
using Controls;
using Environment.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EventSystems
{
    public class MouseHoverEventHandler : MonoBehaviour
    {
        /// <summary>
        /// (IInteractable hoveredInteractableObject) {}
        /// </summary>
        public static event Action<IInteractable> OnMouseHoverInteractable;

        /// <summary>
        /// (IInteractable hoveredInteractableObject) {}
        /// </summary>
        public static event Action<IInteractable> OnMouseHoverPickupItem;

        public static event Action OnMouseHoverNothing;

        [SerializeField] private Transform _player;

        public static event Action OnMousePassMaxRange;


        [SerializeField] private float _maxHoverRange = 5f;

        private float _currentHoverDistance;
        private const string INTERACTABLE_TAG = "Interactable";
        private const string PICKUPABLE_TAG = "Pickupable";

        private GameObject _hoveredObject;
        private MouseHover _mouseHover;
        private bool _isEnable;


        private void Awake()
        {
            _isEnable = true;
            _mouseHover = gameObject.AddComponent<MouseHover>();
        }

        private void Update()
        {
            if (GameplayUIEventHandler.IsInventoryOpen)
            {
                OnMouseHoverNothing?.Invoke();
                return;
            }

            if (!_isEnable)
                return;

            var isHovering = _mouseHover.IsHovering;
            _hoveredObject = _mouseHover.HoveredObject;

            if (GetInteractionIsInRange())
            {
                OnMousePassMaxRange?.Invoke();
                return;
            }

            if (!isHovering)
            {
                OnMouseHoverNothing?.Invoke();
                return;
            }

            if (!_hoveredObject)
            {
                OnMouseHoverNothing?.Invoke();
                return;
            }

            if (_hoveredObject.CompareTag(INTERACTABLE_TAG))
            {
                HoverInteractableOnlyObject();
            }
            else if (_hoveredObject.CompareTag(PICKUPABLE_TAG))
            {
                HoverPickupItem();
            }
            else
            {
                OnMouseHoverNothing?.Invoke();
            }
        }

        private bool GetInteractionIsInRange()
        {
            var currentHoverDistance = GetHoverDistanceFromPlayer();
            return currentHoverDistance > _maxHoverRange;
        }

        private void HoverPickupItem()
        {
            _hoveredObject.TryGetComponent<IInteractable>(out var hoveredObject);

            OnMouseHoverPickupItem?.Invoke(hoveredObject);
        }

        private void HoverInteractableOnlyObject()
        {
            _hoveredObject.TryGetComponent<IInteractable>(out var hoveredObject);
            OnMouseHoverInteractable?.Invoke(hoveredObject);
        }

        private float GetHoverDistanceFromPlayer()
        {
            var hitPoint = _mouseHover.HoverHitPoint;
            var hoveredObjectLocation2d = new Vector3(hitPoint.x, 0, hitPoint.z);

            var playerPosition = _player.position;
            var playerPosition2d = new Vector3(playerPosition.x, 0, playerPosition.z);

            return Vector3.Distance(playerPosition2d, hoveredObjectLocation2d);
        }
    }
}