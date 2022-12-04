using System;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class BarrelRoll : MonoBehaviour
    {
        [SerializeField] private float maxAngularVelocity = 20f;
        [SerializeField] private float barrelSpeed = 100f;
        [SerializeField] private float barrelLifeTime = 10;

        private Rigidbody _rigidbody;
        float timer = 0;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.maxAngularVelocity = maxAngularVelocity;
        }

        private void Start()
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }

        private void Update()
        {
            if (transform.position.y < -10)
            {
                ObjectPool.Instance.ReturnObjectToPool(gameObject);
            }
             if (timer < barrelLifeTime)
            {
                timer+= Time.deltaTime;
                return;
            }
            else
            {
                ObjectPool.Instance.ReturnObjectToPool(gameObject);
            }
        }

        private void FixedUpdate()
        {
            
            Vector3 barrelAxis = transform.TransformDirection(Vector3.up);
            
            _rigidbody.AddTorque(-barrelAxis * barrelSpeed);
        }
    }
}