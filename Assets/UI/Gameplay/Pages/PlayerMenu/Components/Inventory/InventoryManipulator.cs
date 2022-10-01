using System;
using System.Linq;
using DataStorage;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.Pages.PlayerMenu.Components.Inventory
{
    public class InventoryManipulator : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset _inventoryTreeAsset;
        private VisualElement _inventoryRoot;

        public VisualElement InventoryVisualElement => _inventoryRoot;

        private VisualElement _itemSlots;

        void Awake()
        {
            _inventoryRoot = _inventoryTreeAsset.CloneTree();
            _itemSlots = _inventoryRoot.Query<VisualElement>("item-slots");
            
        }

        private void Start()
        {
            CreateItemSlots();
            FetchInventoryDataToSlots();
        }

        private void CreateItemSlots()
        {
            var maxItemSlots = PlayerInventory.MaxInventorySize;

            for (var i = 0; i < maxItemSlots; i++)
            {
                var itemSlot = new VisualElement();
                itemSlot.name = "slot-" + i;
                _itemSlots.Add(itemSlot.contentContainer);
                itemSlot.AddToClassList("item-slot");
            }
        }

        private void FetchInventoryDataToSlots()
        {
            var playerInventory = PlayerInventory.Inventory;

            for (int i = 0; i < playerInventory.Count; i++)
            {
                var itemSlot = _inventoryRoot.Query<VisualElement>($"slot-{i}").First();
                var item = playerInventory.ElementAt(i);
                itemSlot.style.backgroundImage = Background.FromRenderTexture(item.image);
            }
        }
        
    }
}