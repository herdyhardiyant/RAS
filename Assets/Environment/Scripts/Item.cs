using System;
using CentralSystems;
using Environment.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Environment.Scripts
{
    
    public class Item : MonoBehaviour, IInteractable
    {
        public string itemName = "Unrecognizable Object";

        private void Start()
        {
           
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
