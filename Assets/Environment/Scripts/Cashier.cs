using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class Cashier : MonoBehaviour, ICashier
    {
        //TODO Sell object here
        // Add SellableObject interface to objects that can be sold
        // Add cashier interface to connect to the cashier
        
        // SEll
        // Player press f on cashier whlie holding an object
        // check if object is sellable by checking if it has the sellable interface
        // if it does, detach it from the player and input it into the cashier
        // cashier will then check if it has the sellable interface
        // Input gameobject with sellable interface
        // if not sellable dont do anything
        // get the price from the sellable interface
        // return gameobject to pool
        // price ui
        // add to total cash
        // add the price to the total cash


        public void Sell(ISellable sellableObject, GameObject sellableGameObject)
        {
            var price = sellableObject.Price;
            ObjectPool.SharedInstance.ReturnObjectToPool(sellableGameObject);
            print("Sold " + sellableGameObject.name + " for " + price);
        }
    }
}
