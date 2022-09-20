using Environment.Interfaces;
using UnityEngine;


namespace Environment.Scripts
{
    public class Object : MonoBehaviour, IInteractable
    {
        public string itemName = "Unrecognizable Object";
        private const string TAG_NAME = "Interactable";
        private void Awake()
        {
            if(gameObject.CompareTag("Untagged"))
                tag = TAG_NAME;
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
