using System;
using System.Collections.Generic;
using EventSystems;
using UnityEngine;

namespace DataStorage
{
    public class PlayerInventory: MonoBehaviour
    {

        public static int MaxInventorySize => _maxInventorySize;

        public static List<ItemData> Inventory => _inventory;

        static PlayerInventory()
        {
            _inventory = new List<ItemData>();
        }

        public static void AddItem(ItemData item)
        {
            if (_inventory.Count >= _maxInventorySize)
            {
                return;
            }
            
            _inventory.Add(item);
            InventoryEventHandler.ItemAdded();
        }

        public static void RemoveItem(ItemData item)
        {
            var itemIndex = _inventory.IndexOf(item);
            _inventory.RemoveAt(itemIndex);
            InventoryEventHandler.ItemRemoved();
        }
        

        private static List<ItemData> _inventory;
        private static readonly int _maxInventorySize = 10;
    }
}