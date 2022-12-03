using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RAS
{
    public class OrderManager : MonoBehaviour
    {
        [SerializeField] private OrderPanel orderPanel;
        [SerializeField] private float orderDuration = 15;
        [SerializeField] private int maxOrder = 5;
        [SerializeField] private int orderTimer = 5;
        [SerializeField] private Order orderPrefab;
        private int placeOrderDuration;

        private void PlaceOrder(){
            placeOrderDuration = orderTimer;
            // StartCoroutine(UpdateOrder);
        }

        // private IEnumerator UpdateOrder(){
        //     while(placeOrderDuration >= 0){
        //         placeOrderDuration --;
        //         yield return new WaitForSeconds(1f);
        //     }
        // }
    }
}
