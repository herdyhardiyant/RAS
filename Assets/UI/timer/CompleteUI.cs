using System;
using GameplayData;
using Systems;
using TMPro;
using UnityEngine;

namespace UI.timer
{
    public class CompleteUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text coinText;

        private void OnEnable()
        {
            coinText.text = PlayerGameplayData.Instance.TotalMoney.ToString();
        }

   
    }
}