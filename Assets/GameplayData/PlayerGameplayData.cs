using System;
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
        }

        public void AddMoney(int amount)
        {
            _totalMoney += amount;
            OnMoneyChanged?.Invoke(_totalMoney);
        }

        public void SubtractMoney(int amount)
        {
            _totalMoney -= amount;

            if (_totalMoney < 0)
            {
                _totalMoney = 0;
            }

            OnMoneyChanged?.Invoke(_totalMoney);
        }
    }
}