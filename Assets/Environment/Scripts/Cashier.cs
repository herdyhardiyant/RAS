
using Interfaces;
using Systems;
using UnityEngine;

namespace Environment.Scripts
{
    public class Cashier : MonoBehaviour, ICashier
    {

        // TODO Customer orders
        // Customer order event system
        // After the customer order is completed, invoke the event
        
        
        [SerializeField] private AudioSource cashRegisterAudioSource;

        
        //TODO Use event system to invoke the event
        public void Sell(ISellable sellableObject, GameObject sellableGameObject)
        {
            var price = sellableObject.Price;
            ObjectPool.Instance.ReturnObjectToPool(sellableGameObject);
            RecycleEvents.SellItem(price);
            cashRegisterAudioSource.Play();
        }
    }
}
