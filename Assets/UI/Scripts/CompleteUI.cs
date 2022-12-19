using GameplayData;
using TMPro;
using UnityEngine;

namespace UI.Scripts
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