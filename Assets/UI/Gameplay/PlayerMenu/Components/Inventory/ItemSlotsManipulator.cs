using System;
using System.Collections.Generic;
using Codice.Client.BaseCommands;
using DataStorage;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.PlayerMenu.Components.Inventory
{
    public class ItemSlotsManipulator
    {
        
        public List<ItemSlot> ItemSlots => _itemSlots;
        private List<ItemSlot> _itemSlots = new List<ItemSlot>();
        private int _itemSlotsCount;
        private string _individualItemSlotClass;

        private ItemSlot _focusedItemSlot;
        private Action<ItemData?> _onItemSlotClicked;

        public void ResetSlotFocus()
        {
            _focusedItemSlot?.StopFocusing();
        }

        public ItemSlotsManipulator(int itemSlotsCount, string individualItemSlotClass)
        {
            _itemSlotsCount = itemSlotsCount;
            _individualItemSlotClass = individualItemSlotClass;
            CreateItemSlots();
        }
        
        public void OnClickIndividualItemSlot(Action<ItemData?> callback)
        {
            _onItemSlotClicked = callback;
        }

        private void CreateItemSlots()
        {
            var maxItemSlots = _itemSlotsCount;

            for (var slotId = 0; slotId < maxItemSlots; slotId++)
            {
                var slotName = "slot-" + slotId;
                var itemSlot = new ItemSlot(slotName, _individualItemSlotClass);
                itemSlot.SlotVisualElement.RegisterCallback<ClickEvent>(clickEvent =>
                {
                    if(clickEvent.propagationPhase != PropagationPhase.AtTarget)
                        return;
                    
                    _focusedItemSlot?.StopFocusing();
                    _focusedItemSlot = itemSlot;
                    itemSlot.Focus();

                    _onItemSlotClicked(itemSlot.StoredItemData);
                } );
                _itemSlots.Add(itemSlot);
            }
        }
    }
}