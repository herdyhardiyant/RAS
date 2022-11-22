using System;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class Trash : MonoBehaviour
    {
        public string RecycleType => _recycleType;
        public string TrashName => trashName;
        
        [Tooltip("This Trash Recycle Machine")]
        [SerializeField] private GameObject recycleMachinePrefab;

        [SerializeField] private string trashName;
        
        private string _recycleType;

        private void Awake()
        {
            var machine = recycleMachinePrefab.GetComponent<IMachine>();
            _recycleType = machine.RecycleType;
        }
    }
}