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
        private const string TAG_NAME = "Pickupable";
        
        [SerializeField]
        private string _itemName;
        
        [SerializeField]
        private string _description;
        
        [SerializeField]
        private RenderTexture _image;

        private ItemData _itemData;

        void Awake()
        {
            tag = TAG_NAME;
            _itemData = new ItemData(_itemName, _description, _image);
        }

        public void Interact()
        {
            print($"Pickup {_itemName}");
            PlayerInventory.AddItem(_itemData);
            Destroy(gameObject);
        }

        public string GetInteractionText()
        {
            return "Item is added to inventory";
        }

        public Vector3 Position => transform.position;
    }
}