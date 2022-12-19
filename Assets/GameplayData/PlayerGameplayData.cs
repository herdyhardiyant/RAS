using System;
using Interfaces;
using Systems;
using UnityEngine;

namespace GameplayData
{
    public class PlayerGameplayData : MonoBehaviour
    {
        [SerializeField] private Orders orders;

        public static PlayerGameplayData Instance;
        public static event Action<int> OnMoneyChanged;
        public int TotalMoney => _totalMoney;
        private int _totalMoney;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            _totalMoney = 0;
            RecycleEvents.OnSellItem += SellHandler;
        }

        public void SellHandler(ISellable objectSell)
        {
            var isInList = orders.IsInOrderList(objectSell);
            if (isInList)
            {
                _totalMoney += objectSell.Price;
                OnMoneyChanged?.Invoke(_totalMoney);
            }
        }
    }
}