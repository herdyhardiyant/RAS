using System;
using GameplayData;
using TMPro;
using UnityEngine;

namespace UI.GameplayUI
{
    public class GameplayUIManipulator : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyText;

        private void Awake()
        {
            PlayerGameplayData.OnMoneyChanged += UpdateMoneyText;
            moneyText.text = "Money: " + PlayerGameplayData.Instance.TotalMoney.ToString();
        }

        private void UpdateMoneyText(int money)
        {
            moneyText.text = "Money: " + money;
        }
    }
}