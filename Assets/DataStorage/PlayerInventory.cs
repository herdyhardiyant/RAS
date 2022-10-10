using System.Collections.Generic;
using EventSystems;

namespace DataStorage
{
    public static class PlayerInventory
    {
        public static int MaxInventorySize => maxInventorySize;

        public static List<ItemData> Inventory => inventory;

        static PlayerInventory()
        {
            inventory = new List<ItemData>();
        }

        public static void AddItem(ItemData item)
        {
            if (inventory.Count >= maxInventorySize)
            {
                return;
            }

            inventory.Add(item);
            InventoryEventHandler.InvokeInventoryChangedEvent();
        }

        public static void RemoveItem(ItemData item)
        {
            var itemIndex = inventory.FindIndex(checkedItem => checkedItem.id == item.id);
            if (itemIndex == -1)
            {
                return;
            }

            inventory.RemoveAt(itemIndex);
            
            InventoryEventHandler.InvokeInventoryChangedEvent();
        }

        public static List<ItemData> inventory;
        private static readonly int maxInventorySize = 10;
    }
}