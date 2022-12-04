using System;
using Interfaces;
using Systems;
using UnityEngine;

namespace GameplayData
{
    public class PlayerGameplayData : MonoBehaviour
    {
        //TODO Add customer orders data 

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
            RecycleEvents.OnSellItem += AddMoney;
        }

        public void AddMoney(ISellable objectSell)
        {
            _totalMoney += objectSell.Price;
            OnMoneyChanged?.Invoke(_totalMoney);
        }
    }
}