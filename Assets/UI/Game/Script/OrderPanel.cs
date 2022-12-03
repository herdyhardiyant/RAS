using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace RAS
{
    public class OrderPanel : MonoBehaviour
    {
        [SerializeField] private Order orderPrefab;
        private List<Order> _ordersUI = new List<Order>();
        private Queue<Order> _orderPool = new Queue<Order>();
        private void Awake() {
            Assert.IsNotNull(orderPrefab);
        }

        private Order GetOrder(){
            return _orderPool.Count > 0 ? _orderPool.Dequeue() : Instantiate(orderPrefab,transform);
        }

        private void OrderSpawn(){

            var orderUI = GetOrder();
            _ordersUI.Add(orderUI);
        }
    }
}
