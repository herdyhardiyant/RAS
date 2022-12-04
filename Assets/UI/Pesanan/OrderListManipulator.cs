using System;
using GameplayData;
using UnityEngine;

namespace UI.Pesanan
{
    public class OrderListManipulator : MonoBehaviour
    {
        // Get order list from data storage
        // Get order ui prefab
        // Instantiate order ui prefab
        // Add order ui to order list

        [SerializeField] private GameObject orderList;
        [SerializeField] private GameObject orderUIPrefab;
        [SerializeField] private Orders orders;

        private void Awake()
        {
            Orders.OnOrderChanged += OnOrderChanged;
        }

        private void OnOrderChanged()
        {
            print("Order changed");
            // Get order list from data storage
            var orderLinkedList = orders.OrdersList;

            foreach (var order in orderLinkedList)
            {
                var orderUI = Instantiate(orderUIPrefab, orderList.transform);
                orderUI.GetComponent<OrderItemManipulator>()
                    .SetupOrderItem(order.Icon, order.TrashIcon, order.MaterialIcon);
            }
        }
    }
}