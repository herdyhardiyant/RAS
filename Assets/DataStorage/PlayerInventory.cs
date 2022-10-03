using System.Collections.Generic;
using System.Linq;
using EventSystems;
using UnityEditor;
using UnityEngine;

namespace DataStorage
{
    public static class PlayerInventory
    {
        public static int MaxInventorySize => maxInventorySize;

        public static LinkedList<ItemData> Inventory => inventory;
        
        static PlayerInventory()
        {
            inventory = new LinkedList<ItemData>();
        }

        public static void AddItem(ItemData item)
        {
            if (inventory.Count >= maxInventorySize)
            {
                return;
            }
            
            inventory.AddLast(item);
            InventoryEventHandler.InvokeInventoryChangedEvent();
        }
        private static LinkedList<ItemData> inventory;
        private static readonly int maxInventorySize = 10;
    }
}