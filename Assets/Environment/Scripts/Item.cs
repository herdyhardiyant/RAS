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

        public void Interact()
        {
            // TODO: Add to inventory storage
            // After added to inventory destroy this object
            // Update Inventory UI for stored object
            print("Pickup Item");
        }

        public string GetInteractionText()
        {
            return "Item is added to inventory";
        }
    }
}