using System.Collections.Generic;
using DataStorage;
using EventSystems;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.PlayerMenu.Components.Inventory
{
    public class InventoryManipulator : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset inventoryTreeAsset;
        [SerializeField] private ItemActionWindow itemActionWindow;
        public VisualElement InventoryVisualElement => _inventoryRoot;
        private VisualElement _inventoryRoot;
        private VisualElement _itemSlotsContainer;

        private int _playerInventoryItemCountBeforeInventoryChange;

        private const string ItemSlotClass = "item-slot";

        private List<ItemSlot> _itemSlotsList = new List<ItemSlot>();
        private ItemSlotsBuilder _itemSlotsBuilder;

        void Awake()
        {
            _inventoryRoot = inventoryTreeAsset.CloneTree();
            _itemSlotsContainer = _inventoryRoot.Query<VisualElement>("item-slots");

            SubscribeEvents();
            _playerInventoryItemCountBeforeInventoryChange = PlayerInventory.Inventory.Count;
        }

        private void Start()
        {
            CreateItemSlots();
        }


        private void CreateItemSlots()
        {
            var maxItemSlots = PlayerInventory.MaxInventorySize;

            _itemSlotsBuilder = new ItemSlotsBuilder(maxItemSlots, ItemSlotClass);

            _itemSlotsBuilder.OnClickIndividualItemSlot((itemDataOnSlot =>
            {
                if (itemDataOnSlot == null)
                    return;

                itemActionWindow.ShowItemActionWindow(itemDataOnSlot, () => { DropItem(itemDataOnSlot); });
              
            }));

            _itemSlotsList = _itemSlotsBuilder.ItemSlots;

            foreach (var slot in _itemSlotsList)
            {
                _itemSlotsContainer.Add(slot.SlotVisualElement);
            }
        }

        private void RetrieveInventoryDataItemsToSlots()
        {
            var playerInventoryData = PlayerInventory.Inventory;

            for (int i = 0; i < playerInventoryData.Count; i++)
            {
                var itemData = playerInventoryData[i];
                _itemSlotsList[i].AddItemToSlot(itemData);
            }
        }

        private void ClearItemFromSlots()
        {
            for (int i = 0; i < _playerInventoryItemCountBeforeInventoryChange; i++)
            {
                _itemSlotsList[i].RemoveItemFromSlot();
                var itemSlot = _itemSlotsContainer.Query($"slot-{i}").First();
                itemSlot.style.backgroundImage = null;
            }
        }

        private void DropItem(ItemData item)
        {
            _itemSlotsBuilder.ResetSlotFocus();
            PlayerInventory.RemoveItem(item);
        }

        private void SubscribeEvents()
        {
            GameplayUIEventHandler.OnCloseInventory += CloseInventory;
            
            InventoryEventHandler.OnInventoryChanged += () =>
            {
                ClearItemFromSlots();
                RetrieveInventoryDataItemsToSlots();
                _playerInventoryItemCountBeforeInventoryChange = PlayerInventory.Inventory.Count;
            };
        }

        private void CloseInventory()
        {
            itemActionWindow.Hide();
        }
    }
}