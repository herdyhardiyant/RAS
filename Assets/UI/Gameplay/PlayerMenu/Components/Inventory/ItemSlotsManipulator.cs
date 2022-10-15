using System;
using System.Collections.Generic;
using DataStorage;
using EventSystems;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.PlayerMenu.Components.Inventory
{
    public class ItemSlotsManipulator : MonoBehaviour
    {
        [SerializeField] private InventoryController inventory;

        private List<ItemSlot> _itemSlots = new List<ItemSlot>();

        private ItemSlot _currentFocusedItemSlot;
        private Action<ItemData> _onItemSlotClicked;

        private const string ItemSlotClass = "item-slot";
        private VisualElement _itemSlotsContainerOnInventoryRoot;
        private int _filledSlotCountBeforeInventoryChange;
        
        private const string ItemSlotsName = "item-slots";

        public void ResetSlotFocus()
        {
            if (_currentFocusedItemSlot != null)
            {
                _currentFocusedItemSlot.StopFocusing();
            }
        }

        public void OnClickIndividualItemSlot(Action<ItemData> callback)
        {
            if (callback != null)
                _onItemSlotClicked = callback;
        }

        private void RetrieveInventoryDataItemsToSlots()
        {
            var playerInventoryData = PlayerInventory.Inventory;

            for (int i = 0; i < playerInventoryData.Count; i++)
            {
                var itemData = playerInventoryData[i];
                _itemSlots[i].AddItemToSlot(itemData);
            }
        }

        private void ClearItemFromSlots()
        {
            for (int i = 0; i < _filledSlotCountBeforeInventoryChange; i++)
            {
                _itemSlots[i].RemoveItemFromSlot();
                var itemSlot = _itemSlotsContainerOnInventoryRoot.Query($"slot-{i}").First();
                itemSlot.style.backgroundImage = null;
            }
        }

        private void Awake()
        {
            BuildItemSlots();

            InventoryEventHandler.OnInventoryChanged += () =>
            {
                ClearItemFromSlots();
                RetrieveInventoryDataItemsToSlots();
                _filledSlotCountBeforeInventoryChange = PlayerInventory.Inventory.Count;
            };
        }

        private void Start()
        {
            _itemSlotsContainerOnInventoryRoot =
                inventory.InventoryVisualElement.Q<VisualElement>(ItemSlotsName);
            
            AddCreatedItemSlotsToParentContainer();
        }

        private void AddCreatedItemSlotsToParentContainer()
        {
            foreach (var slot in _itemSlots)
            {
                _itemSlotsContainerOnInventoryRoot.Add(slot.SlotVisualElement);
            }
        }

        private void BuildItemSlots()
        {
            var maxItemSlots = PlayerInventory.MaxInventorySize;

            for (var slotId = 0; slotId < maxItemSlots; slotId++)
            {
                var itemSlot = CreateNewItem(slotId);

                itemSlot.SlotVisualElement.RegisterCallback<ClickEvent>(clickEvent =>
                {
                    ItemSlotClickHandler(clickEvent, itemSlot);
                });

                _itemSlots.Add(itemSlot);
            }
        }

        private void ItemSlotClickHandler(ClickEvent clickEvent, ItemSlot itemSlot)
        {
            if (clickEvent.propagationPhase != PropagationPhase.AtTarget)
                return;

            ResetSlotFocus();

            SetCurrentFocusSlot(itemSlot);

            if (_onItemSlotClicked != null)
            {
                _onItemSlotClicked(itemSlot.StoredItemData);
            }
        }

        private void SetCurrentFocusSlot(ItemSlot itemSlot)
        {
            _currentFocusedItemSlot = itemSlot;
            _currentFocusedItemSlot.Focus();
        }

        private ItemSlot CreateNewItem(int slotId)
        {
            var slotName = "slot-" + slotId;
            var itemSlot = new ItemSlot(slotName, ItemSlotClass);
            return itemSlot;
        }
    }
}