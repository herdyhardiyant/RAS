using GameplayData;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class Cashier : MonoBehaviour, ICashier
    {

        // TODO Customer orders
        // Customer order event system
        // After the customer order is completed, invoke the event
        
        
        [SerializeField] private AudioSource cashRegisterAudioSource;

        public void Sell(ISellable sellableObject, GameObject sellableGameObject)
        {
            var price = sellableObject.Price;
            ObjectPool.Instance.ReturnObjectToPool(sellableGameObject);
            PlayerGameplayData.Instance.AddMoney(price);
            cashRegisterAudioSource.Play();
        }
    }
}
