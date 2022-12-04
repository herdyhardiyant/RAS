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
            
            //TODO Order list border animation
            //TODO Add paper sound

            foreach (Transform child in orderList.transform)
            {
                Destroy(child.gameObject);
            }
            
            var orderLinkedList = orders.OrdersList;

            foreach (var order in orderLinkedList)
            {
                var orderUI = Instantiate(orderUIPrefab, orderList.transform);
                orderUI.GetComponent<OrderItemManipulator>()
                    .SetupOrderItem(order.Icon, order.TrashIcon, order.MaterialIcon);
            }
        }

        private void OnDestroy()
        {
            Orders.OnOrderChanged -= OnOrderChanged;
        }
    }
}