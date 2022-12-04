using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace GameplayData
{
    public class Orders : MonoBehaviour
    {

        // When player sells an item, check if the item is in the order list
        // if it is, remove the item from the order list, and 
        // if it is not, don't remove the item from the order list, and return the item to pool

        public LinkedList<ISellable> OrdersList => _customerOrders;

        [SerializeField] private GameObject[] sellableObjectPrefabs;

        private List<ISellable> _sellableObjects;

        private LinkedList<ISellable> _customerOrders;

        public static Action OnOrderChanged;

        private bool _delayOrderFinish;

        private void Awake()
        {
            _customerOrders = new LinkedList<ISellable>();
            _sellableObjects = new List<ISellable>();

            foreach (var sellableObjectPrefab in sellableObjectPrefabs)
            {
                var sellableObject = sellableObjectPrefab.GetComponent<ISellable>();
                _sellableObjects.Add(sellableObject);
            }
        }

        private void Start()
        {
            AddOrder();

            AddOrder();

            OnOrderChanged?.Invoke();
        }

        private void Update()
        {
            if (_delayOrderFinish)
            {
                AddOrder();
            }
        }

        public void RemoveOrder(ISellable sellableObject)
        {
            _customerOrders.Remove(sellableObject);
            AddOrder();
            OnOrderChanged?.Invoke();
        }

        private void AddOrder()
        {
            var randomOrder = _sellableObjects[UnityEngine.Random.Range(0, sellableObjectPrefabs.Length)];
            _customerOrders.AddLast(randomOrder);
            _delayOrderFinish = false;
        }
    }
}