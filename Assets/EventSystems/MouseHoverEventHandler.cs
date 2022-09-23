using System;
using Environment.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EventSystems
{
    public class MouseHoverEventHandler : MonoBehaviour
    {
        /// <summary>
        /// (hoveredInteractableObject) {}
        /// </summary>
        public static event Action<IInteractable> OnMouseHoverInteractable;
        public static event Action<IInteractable> OnMouseHoverPickupItem;
        public static event Action OnMouseHoverNothing;

        [SerializeField]
        private Transform _player;
        
        public static event Action OnMousePassMaxRange;

        
        [SerializeField]
        private float _maxHoverRange = 5f;
        
        private Vector2 _hoveredObjectLocation2d = Vector2.zero;
        private float _currentHoverDistance;
        
        private const string INTERACTABLE_TAG = "Interactable";
        private const string PICKUPABLE_TAG = "Pickupable";
        private bool _isHovering;
        private GameObject _hoveredObject;
        private Camera _mainCamera;
        private Mouse _mouse;
        
        void Awake()
        {
            _isHovering = false;
            _mainCamera = Camera.main;
            _mouse = Mouse.current;
        }

        private void Update()
        {
            UpdateHoverDistance();
            
            if (_currentHoverDistance > _maxHoverRange)
            {
                OnMousePassMaxRange?.Invoke();
                return;
            }

            if (!_isHovering)
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
                InteractableObjectHoverHandler();
            }
            else if (_hoveredObject.CompareTag(PICKUPABLE_TAG))
            {
                PickupItemHoverHandler();
            }
            else
            {
                OnMouseHoverNothing?.Invoke();
            }
        }

        private void FixedUpdate()
        {
            MouseRaycast();
        }

        private void UpdateHoverDistance()
        {
            var playerPosition = _player.position;
            var playerPosition2d = new Vector2(playerPosition.x, playerPosition.z);
            _currentHoverDistance = Vector2.Distance(playerPosition2d, _hoveredObjectLocation2d);
        }
        

        private void PickupItemHoverHandler()
        {
            _hoveredObject.TryGetComponent<IInteractable>(out var hoveredObject);
            OnMouseHoverPickupItem?.Invoke(hoveredObject);
        }

        private void InteractableObjectHoverHandler()
        {
            _hoveredObject.TryGetComponent<IInteractable>(out var hoveredObject);
            if(hoveredObject == null) return;
            OnMouseHoverInteractable?.Invoke(hoveredObject);
        }

        private void MouseRaycast()
        {
            var ray = _mainCamera.ScreenPointToRay(_mouse.position.ReadValue());
            
            if (Physics.Raycast(ray, out var hit))
            {
                RaycastHitHandler(hit);
            }
            else
            {
                RaycastNotHitHandler();
            }
        }

        private void RaycastHitHandler(RaycastHit hit)
        {
            _hoveredObjectLocation2d = new Vector2(hit.point.x, hit.point.z);
            _hoveredObject = hit.collider.gameObject;
            _isHovering = true;
        }

        private void RaycastNotHitHandler()
        {
            _isHovering = false;
        }
    }
}
