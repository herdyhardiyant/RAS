using DataStorage;
using Environment.Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    /// <summary>
    /// Class component for item that can be stored in inventory
    /// </summary>
    public class Item : MonoBehaviour, IInteractable
    {
        private const string TagName = "Pickupable";

        [SerializeField] private string itemName;

        [SerializeField] private string description;

        [SerializeField] private RenderTexture image;

        private ItemData _itemData;

        void Awake()
        {
            tag = TagName;
            _itemData = new ItemData(itemName + transform.position + gameObject.name, itemName, description, image,
                gameObject);

            CheckDataIsAvailable();
        }

        public void Interact()
        {
            print($"Pickup {itemName}");
            PlayerInventory.AddItem(_itemData);
            gameObject.SetActive(false);
        }

        public string GetInteractionText()
        {
            return "Item is added to inventory";
        }

        public Vector3 Position => transform.position;


        private void CheckDataIsAvailable()
        {
            if (itemName == null || description == null || image == null)
                Debug.LogError("Item " + gameObject.name + " is missing data");
        }
    }
}