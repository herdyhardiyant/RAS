using System;
using System.Collections.Generic;
using DataStorage;
using UnityEngine.UIElements;

namespace UI.Gameplay.PlayerMenu.Components.Inventory
{
    public class ItemSlotsBuilder
    {
        public List<ItemSlot> ItemSlots => _itemSlots;
        private List<ItemSlot> _itemSlots = new List<ItemSlot>();
        private int _itemSlotsCount;
        private string _individualItemSlotClass;

        private ItemSlot _focusedItemSlot;
        private Action<ItemData> _onItemSlotClicked;

        public void ResetSlotFocus()
        {
            if (_focusedItemSlot != null)
            {
                _focusedItemSlot.StopFocusing();
            }
        }

        public ItemSlotsBuilder(int itemSlotsCount, string individualItemSlotClass)
        {
            _itemSlotsCount = itemSlotsCount;
            _individualItemSlotClass = individualItemSlotClass;
            CreateItemSlots();
        }

        public void OnClickIndividualItemSlot(Action<ItemData> callback)
        {
            if (callback != null)
                _onItemSlotClicked = callback;
        }

        private void CreateItemSlots()
        {
            var maxItemSlots = _itemSlotsCount;

            for (var slotId = 0; slotId < maxItemSlots; slotId++)
            {
                var itemSlot = CreateItem(slotId);

                itemSlot.SlotVisualElement.RegisterCallback<ClickEvent>(clickEvent =>
                {
                    if (clickEvent.propagationPhase != PropagationPhase.AtTarget)
                        return;

                    if (_focusedItemSlot != null)
                    {
                        _focusedItemSlot.StopFocusing();
                    }

                    _focusedItemSlot = itemSlot;
                    itemSlot.Focus();

                    if (_onItemSlotClicked != null)
                    {
                        _onItemSlotClicked(itemSlot.StoredItemData);
                    }
                });

                _itemSlots.Add(itemSlot);
            }
        }

        private ItemSlot CreateItem(int slotId)
        {
            var slotName = "slot-" + slotId;
            var itemSlot = new ItemSlot(slotName, _individualItemSlotClass);
            return itemSlot;
        }
    }
}