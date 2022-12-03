using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace GameplayData
{
    public class Orders : MonoBehaviour
    {
        // Create recipe in SellableObject component  
        // Get 2D sprite for the recipe ui, **
        // Trash sprite * *
        // material sprite * *
        // Sellable object sprite * *
        
        // Assign the sprite to each of the above **
     
        // Create prefab template for the order UI *done*
        
        // Create a linked list of orders with its recipe
        // Create order randomly,
        // if the order is empty, immediately create a new order
        // if the order is not empty, add delay to create a new order
        // if the order is at max amount, do not create a new order
        // and add to the linked list
        
        // Create a UI from the order list
        // Create a UI for the order timer and line threshold for tips reward

        // When player sells an item, check if the item is in the order list
        // if it is, remove the item from the order list, and 
        // if it is not, don't remove the item from the order list, and return the item to pool
        
        private LinkedList<ISellable> customerOrders;
        
        private void Awake()
        {
            customerOrders = new LinkedList<ISellable>();
        }
    }
}
