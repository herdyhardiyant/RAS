using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DataStorage
{
    public static class PlayerInventory
    {
        public static int MaxInventorySize => maxInventorySize;

        public static LinkedList<ItemData> Inventory => inventory;


        private static readonly ItemData[] dummyStartingItem = new ItemData[]
        {
            new ItemData(
                name: "Dummy Item 1",
                description: "This is a dummy item 1",
                image: AssetDatabase.LoadAssetAtPath<RenderTexture>(
                    "Assets/Environment/RenderTextures/ItemDummy.renderTexture")
            ),

            new ItemData(
                name: "Dummy Item 2",
                description: "This is a dummy item 2",
                image: AssetDatabase.LoadAssetAtPath<RenderTexture>(
                    "Assets/Environment/RenderTextures/ItemDummy2.renderTexture")
            )
        };
        
        private static LinkedList<ItemData> inventory = new LinkedList<ItemData>( dummyStartingItem);

        private static readonly int maxInventorySize = 10;
    }
}