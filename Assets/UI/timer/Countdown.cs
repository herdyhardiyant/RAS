using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace RAS
{
    public class Countdown : MonoBehaviour
    {
        float currentTime = 0f;
        float startTime = 20f;

        [SerializeField] TMP_Text countdownText;
        
        void Start()
        {
            currentTime = startTime;
        }

        
        void Update()
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                countdownText.text = currentTime.ToString("TIMES UP!");
            }

        }
    }
}
