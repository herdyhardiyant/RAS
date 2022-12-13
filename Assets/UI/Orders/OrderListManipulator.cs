using UI.Pesanan;
using UnityEngine;

namespace UI.Orders
{
    public class OrderListManipulator : MonoBehaviour
    {
        // Get order list from data storage
        // Get order ui prefab
        // Instantiate order ui prefab
        // Add order ui to order list

        [SerializeField] private GameObject orderList;
        [SerializeField] private GameObject orderUIPrefab;
        [SerializeField] private GameplayData.Orders orders;

        private void Awake()
        {
            GameplayData.Orders.OnOrderChanged += OnOrderChanged;
        }

        private void OnOrderChanged()
        {
            DeleteAllItem();
            FetchOrderItem();

        }

        private void FetchOrderItem()
        {
            foreach (var order in orders.OrdersList)
            {
                var orderUI = Instantiate(orderUIPrefab, orderList.transform);
                orderUI.GetComponent<OrderItemManipulator>()
                    .SetupOrderItem(order.Icon, order.TrashIcon, order.MaterialIcon);
            }
        }

        private void DeleteAllItem()
        {
            foreach (Transform child in orderList.transform)
            {
                Destroy(child.gameObject);
            }
        }


        private void OnDestroy()
        {
            GameplayData.Orders.OnOrderChanged -= OnOrderChanged;
        }
    }
}