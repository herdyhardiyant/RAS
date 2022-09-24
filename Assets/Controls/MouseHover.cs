using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    public class MouseHover : MonoBehaviour
    {
        private Camera _mainCamera;
        private Mouse _mouse;
        private GameObject _hoveredObject;
        private bool _isHovering;
        private Vector3 _hoverHitPoint;
        
        public Vector3 HoverHitPoint => _hoverHitPoint;
        
        public GameObject HoveredObject => _hoveredObject;
        public bool IsHovering => _isHovering;
        
        private void Awake()
        {
            _mainCamera = Camera.main;
            _mouse = Mouse.current;
            _isHovering = false;
        }

        private void FixedUpdate()
        {
            var ray = _mainCamera.ScreenPointToRay(_mouse.position.ReadValue());
            if (Physics.Raycast(ray, out var hit))
            {
                _hoverHitPoint = hit.point;
                _hoveredObject = hit.collider.gameObject;
                _isHovering = true;
            }
            else
            {
                _isHovering = false;
            }
        }
        
        
    }
}
