using Environment.Interfaces;
using UnityEngine;


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
