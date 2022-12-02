using System;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class BarrelHitHandler : MonoBehaviour
    {
        [SerializeField] private float knockBackForce = 10f;
        
        private Movement _movement;
        private Vector3 _barrelHitPosition;
        private Action _onBarrelHit;
        
        private void Awake()
        {
            _movement = GetComponent<Movement>();
            
            if(_movement == null)
                Debug.LogError("Movement component not found");
            
            _barrelHitPosition = Vector3.zero;
            
            _onBarrelHit = () =>
            {
                var knockDirection = (transform.position - _barrelHitPosition).normalized;
                knockDirection += Vector3.up;
                _movement.KnockBack(knockDirection, knockBackForce);
            };
            
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Barrel"))
            {
                _barrelHitPosition = other.transform.position;
                _onBarrelHit?.Invoke();
            }
        }

    
    }
}
