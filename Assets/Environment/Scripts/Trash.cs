using System;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class Trash : MonoBehaviour
    {
        public GameObject SmeltedPrefab => smeltedPrefab;
        
        [Tooltip("Prefab of the smelted trash")]
        [SerializeField] private GameObject smeltedPrefab;
        
    }
}