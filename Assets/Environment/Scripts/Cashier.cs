
using Interfaces;
using Systems;
using UnityEngine;

namespace Environment.Scripts
{
    public class Cashier : MonoBehaviour, ICashier
    {

        public void Sell(ISellable sellableObject, GameObject sellableGameObject)
        {
            RecycleEvents.SellItem(sellableObject);
            ObjectPool.Instance.ReturnObjectToPool(sellableGameObject);
        }
    }
}
