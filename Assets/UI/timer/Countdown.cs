using System;
using Systems;
using TMPro;
using UnityEngine;

namespace UI.timer
{
    public class Countdown : MonoBehaviour
    {
        [SerializeField] TMP_Text TimerText;
        [SerializeField] GameObject GameOverPanel;
        [SerializeField] AudioSource beepSound;

        public float Waktu = 100;
        
        private bool _isTimerStopped;
        private bool _isTimerWarning;
        private bool _isTImerDanger;
        
        void SetText()
        {
            int Menit = Mathf.FloorToInt(Waktu / 60);
            int Detik = Mathf.FloorToInt(Waktu % 60);
            TimerText.text = Menit.ToString("00") + ":" + Detik.ToString("00");
        }

        float sec;

        
        
        private void Awake()
        {
            _isTimerStopped = false;
            _isTImerDanger = false;
            _isTimerWarning = false;
        }

        private void Update()
        {
            if (Waktu > 0)
            {
                sec += Time.deltaTime;
                if (sec >= 1)
                {
                    Waktu--;
                    sec = 0;

                    if (_isTImerDanger)
                    {
                        beepSound.Play();
                    }
                    
                }
            }

            if (!_isTimerWarning && Waktu <= 20)
            {
                _isTimerWarning = true;
                RecycleEvents.TimerWarning();
            }
            
            if (!_isTImerDanger && Waktu <= 10)
            {
                _isTImerDanger = true;
                RecycleEvents.TimerDanger();
            }

            if (!_isTimerStopped && Waktu <= 0)
            {
                _isTImerDanger = false;
                _isTimerWarning = false;
                _isTimerStopped = true;
                RecycleEvents.TimerRunOut();
                GameOverPanel.SetActive(true);
            }

            SetText();
        }
    }
}