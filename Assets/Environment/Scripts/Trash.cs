using System;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class Trash : MonoBehaviour, IPickupable
    
    {
        public GameObject SmeltedPrefab => smeltedPrefab;
        
        [Tooltip("Prefab of the smelted trash")]
        [SerializeField] private GameObject smeltedPrefab;
        [SerializeField] private string trashName;
        public string Name => trashName;
    }
}