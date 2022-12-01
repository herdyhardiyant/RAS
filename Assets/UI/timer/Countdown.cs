using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace RAS
{
    public class Countdown : MonoBehaviour
    {
        [SerializeField] TMP_Text TimerText;
        [SerializeField] GameObject GameOverPanel;
        
        public float Waktu = 100;
        public bool GameActive = true;

        void SetText()
        {
            int Menit = Mathf.FloorToInt(Waktu / 60);
            int Detik = Mathf.FloorToInt(Waktu % 60);
            TimerText.text = Menit.ToString("00") +":"+ Detik.ToString("00");
        }
        
        float sec;
        private void Update()
        {
            // SetText();
            if (GameActive)
            {
                sec += Time.deltaTime;
                if(sec >= 1)
                {
                Waktu--;
                sec = 0;
                }
            }

            if (GameActive && Waktu <=0)
            {
                Debug.Log("Game Over");
                GameOverPanel.SetActive(true);
                GameActive = false;
            }
            SetText();
            
        }

    }
}
