using Environment.Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    /// <summary>
    /// Class component for item that can be stored in inventory
    /// </summary>
    public class Item : MonoBehaviour, IInteractable
    {
        private const string TAG_NAME = "Pickupable";

        void Awake()
        {
            tag = TAG_NAME;
        }
        
        // TODO Pickup Item to Inventory
        // Dispatch item to InventoryDataStorage
        // Notified all InventoryDataStorage listeners
        // Destroy item from scene
        
        
        public void Interact()
        {
            print("Pickup Item");
        }

        public string GetInteractionText()
        {
            return "Item is added to inventory";
        }

        public Vector3 Position => transform.position;
    }
}