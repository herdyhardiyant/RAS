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

        private List<ItemSlotBuilder> _itemSlots = new List<ItemSlotBuilder>();

        private ItemSlotBuilder _currentFocusedItemSlotBuilder;
        private Action<ItemData> _onItemSlotClicked;

        private const string ItemSlotClass = "item-slot";
        private VisualElement _itemSlotsContainerOnInventoryRoot;
        private int _filledSlotCountBeforeInventoryChange;
        
        private const string ItemSlotsName = "item-slots";

        public void ResetSlotFocus()
        {
            if (_currentFocusedItemSlotBuilder != null)
            {
                _currentFocusedItemSlotBuilder.StopFocusing();
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
            var slotsCount = PlayerInventory.MaxInventorySize;

            for (var slotId = 0; slotId < slotsCount; slotId++)
            {
                var itemSlot = CreateNewSlot(slotId);

                itemSlot.SlotVisualElement.RegisterCallback<ClickEvent>(clickEvent =>
                {
                    ItemSlotClickHandler(clickEvent, itemSlot);
                });

                _itemSlots.Add(itemSlot);
            }
        }

        private void ItemSlotClickHandler(ClickEvent clickEvent, ItemSlotBuilder itemSlotBuilder)
        {
            if (clickEvent.propagationPhase != PropagationPhase.AtTarget)
                return;

            ResetSlotFocus();

            SetCurrentFocusSlot(itemSlotBuilder);

            if (_onItemSlotClicked != null)
            {
                _onItemSlotClicked(itemSlotBuilder.StoredItemData);
            }
        }

        private void SetCurrentFocusSlot(ItemSlotBuilder itemSlotBuilder)
        {
            _currentFocusedItemSlotBuilder = itemSlotBuilder;
            _currentFocusedItemSlotBuilder.Focus();
        }

        private ItemSlotBuilder CreateNewSlot(int slotId)
        {
            var slotName = "slot-" + slotId;
            var itemSlot = new ItemSlotBuilder(slotName, ItemSlotClass);
            return itemSlot;
        }
    }
}