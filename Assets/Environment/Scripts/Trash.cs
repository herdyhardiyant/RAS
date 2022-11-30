using System;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class Trash : MonoBehaviour, IPickupable
    
    {
        public GameObject GetSmeltedPrefab => getSmeltedPrefab;
        
        [Tooltip("Prefab of the smelted trash")]
        [SerializeField] private GameObject getSmeltedPrefab;
        [SerializeField] private string trashName;
        public string Name => trashName;
        
        
        
    }
}