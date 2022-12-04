using System;
using DG.Tweening;
using GameplayData;
using TMPro;
using UnityEngine;

namespace UI.GameplayUI
{
    public class GameplayUIManipulator : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyText;

        private Color _defaultColor;
        
        private void Awake()
        {
            PlayerGameplayData.OnMoneyChanged += UpdateMoneyText;
            moneyText.text = PlayerGameplayData.Instance.TotalMoney.ToString();
            _defaultColor = moneyText.color;
        }

        private void UpdateMoneyText(int money)
        {
            moneyText.text = PlayerGameplayData.Instance.TotalMoney.ToString();

            TextAnimation();
        }

        private void TextAnimation()
        {
            moneyText.color = Color.green;
            moneyText.transform.DOScale(1.5f, 0.2f).OnComplete(() =>
            {
                moneyText.color = _defaultColor;
                moneyText.transform.DOScale(1f, 0.2f);
            });
        }


        private void OnDestroy()
        {
            PlayerGameplayData.OnMoneyChanged -= UpdateMoneyText;
        }
    }
    
}