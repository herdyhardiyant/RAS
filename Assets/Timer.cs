using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RAS
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] Image timeBar;
        [SerializeField] private int time = 100;
        [SerializeField] private TMP_Text timeText;

        private int remainingDuration;
        private void Start() {
            Being(timeRemaining);
        }

        private void Being(int timeRemaining)
        {
            remainingDuration = timeRemaining; 
            StartCoroutine(UpdateTimer());
        }

        private IEnumerator UpdateTimer()
        {
            while (remainingDuration >= 0){
                timeText.text = $"{remainingDuration/ 60}:{remainingDuration % 60}";
                timeBar.fillAmount = Mathf.InverseLerp(0,timeRemaining,remainingDuration);
                remainingDuration --;
                yield return new WaitForSeconds(1f);
            }
            onEnd();
        }
        private void onEnd(){
            Debug.Log("Game Over");
        }
    }
}
