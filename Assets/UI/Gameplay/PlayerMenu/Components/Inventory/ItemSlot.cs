using System;
using DataStorage;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Gameplay.PlayerMenu.Components.Inventory
{
    public class ItemSlot
    {
        public VisualElement SlotVisualElement => _slotVisualElement;
        public string Name => _name;
        
        [CanBeNull] public ItemData StoredItemData => _storedItemData;

        private string _name;
        private VisualElement _slotVisualElement;

        private const int DefaultBorderWidth = 0;
        private const int FocusBorderWidth = 2;
        
        private ItemData _storedItemData;

        public void AddItemToSlot(ItemData item)
        {
            _storedItemData = item;
            _slotVisualElement.style.backgroundImage = Background.FromRenderTexture(item.Image);
        }
        
        public void RemoveItemFromSlot()
        {
            _storedItemData = null;
            _slotVisualElement.style.backgroundImage = null;
        }

        public void Focus()
        {
            if(_storedItemData == null)
                return;
            
            _slotVisualElement.style.borderLeftWidth = FocusBorderWidth;
            _slotVisualElement.style.borderRightWidth = FocusBorderWidth;
            _slotVisualElement.style.borderTopWidth = FocusBorderWidth;
            _slotVisualElement.style.borderBottomWidth = FocusBorderWidth;
        }
        
        public void StopFocusing()
        {
            _slotVisualElement.style.borderLeftWidth = DefaultBorderWidth;
            _slotVisualElement.style.borderRightWidth = DefaultBorderWidth;
            _slotVisualElement.style.borderTopWidth = DefaultBorderWidth;
            _slotVisualElement.style.borderBottomWidth = DefaultBorderWidth;
        }

        public ItemSlot(string slotName, string itemSlotVisualClass)
        {
            _name = slotName;
            var slot = new VisualElement
            {
                name = _name
            };
            slot.AddToClassList(itemSlotVisualClass);
            SetupSlotBorderStyle(slot);
            _slotVisualElement = slot;
        }

        private static void SetupSlotBorderStyle(VisualElement slot)
        {
            slot.style.borderLeftWidth = DefaultBorderWidth;
            slot.style.borderRightWidth = DefaultBorderWidth;
            slot.style.borderTopWidth = DefaultBorderWidth;
            slot.style.borderBottomWidth = DefaultBorderWidth;

            slot.style.borderLeftColor = Color.white;
            slot.style.borderRightColor = Color.white;
            slot.style.borderTopColor = Color.white;
            slot.style.borderBottomColor = Color.white;
        }

        
    }
}