using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Systems;
using UnityEngine;

namespace GameplayData
{
    public class Orders : MonoBehaviour
    {
        public List<ISellable> OrdersList => _customerOrders;

        [SerializeField] private GameObject[] sellableObjectPrefabs;

        private List<ISellable> _sellableObjects;

        private List<ISellable> _customerOrders;

        public static Action OnOrderChanged;

        private void Awake()
        {
            _customerOrders = new List<ISellable>();
            _sellableObjects = new List<ISellable>();

            foreach (var sellableObjectPrefab in sellableObjectPrefabs)
            {
                var sellableObject = sellableObjectPrefab.GetComponent<ISellable>();
                _sellableObjects.Add(sellableObject);
            }

            RecycleEvents.OnSellItem += OnSellItem;
        }

        private void OnSellItem(ISellable objectSell)
        {
            
            var isInList = IsInOrderList(objectSell);
            if (isInList)
            {
                RemoveOrder(objectSell);
            }
        }

        private void Start()
        {
            AddOrder();

            AddOrder();

            OnOrderChanged?.Invoke();
        }

        public void RemoveOrder(ISellable sellableObject)
        {
            foreach (var order in _customerOrders)
            {
                if (order.SellableName == sellableObject.SellableName)
                {
                    _customerOrders.Remove(order);
                }

                break;
            }

            OnOrderChanged?.Invoke();
            
            StartCoroutine(DelayOrder());
        }

        public bool IsInOrderList(ISellable sellableObject)
        {
            foreach (var order in _customerOrders)
            {
                if (order.SellableName == sellableObject.SellableName)
                {
                    return true;
                }
            }

            return false;
        }

        private IEnumerator DelayOrder()
        {
            yield return new WaitForSeconds(1f);
            AddOrder();

        }

        private void AddOrder()
        {
            var randomOrder = _sellableObjects[UnityEngine.Random.Range(0, sellableObjectPrefabs.Length)];
            _customerOrders.Add(randomOrder);
            OnOrderChanged?.Invoke();
        }

        private void OnDestroy()
        {
            RecycleEvents.OnSellItem -= OnSellItem;
        }
    }
}