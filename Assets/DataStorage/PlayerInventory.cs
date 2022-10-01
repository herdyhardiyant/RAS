using System.Collections.Generic;
using System.Linq;
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
            AddDummyItem();
        }
        
        private static void AddDummyItem()
        {
            inventory.AddLast(
                new ItemData(
                    name: "Dummy Item 1",
                    description: "This is a dummy item",
                    image: AssetDatabase.LoadAssetAtPath<RenderTexture>(
                        "Assets/Environment/RenderTextures/ItemDummy.renderTexture")
                )
            );

            inventory.AddLast(
                new ItemData(
                    name: "Dummy Item 2",
                    description: "This is a dummy item 2",
                    image: AssetDatabase.LoadAssetAtPath<RenderTexture>(
                        "Assets/Environment/RenderTextures/ItemDummy2.renderTexture")
                )
            );
        }


        private static LinkedList<ItemData> inventory = new();

        private static readonly int maxInventorySize = 10;
    }
}