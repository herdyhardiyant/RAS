using System;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class BarrelRoll : MonoBehaviour
    {
        [SerializeField] private string barrelName;
        [SerializeField] private float maxAngularVelocity = 20f;
        [SerializeField] private float barrelSpeed = 100f;
        public string Name => barrelName;

        private Rigidbody _rigidbody;

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
                ObjectPool.SharedInstance.ReturnObjectToPool(gameObject);
            }
        }

        private void FixedUpdate()
        {
            _rigidbody.AddTorque(-Vector3.forward * barrelSpeed);
        }
    }
}