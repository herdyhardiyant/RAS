using System;
using CentralSystems;
using Environment.Interfaces;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Environment.Scripts
{
    
    public class EnvironmentObject : MonoBehaviour, IInteractable
    {
        public string itemName = "Unrecognizable Object";
        
        private void Awake()
        {
            tag = "Interactable";
        }

        public void Interact()
        {
            Debug.Log($"This is a {itemName}");
        }

        public string GetInteractionText()
        {
            return $"This is a {itemName}";
        }
        
    }
}
