using System;
using DG.Tweening;
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
        [SerializeField] GameObject sandClockImage;

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

        private Color _defaultTextTimeColor;

        private void Awake()
        {
            _isTimerStopped = false;
            _isTImerDanger = false;
            _isTimerWarning = false;
            _defaultTextTimeColor = TimerText.color;
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

                    if (_isTimerWarning)
                    {
                        beepSound.Play();
                        TimerTextAnimation();
                        sandClockImage.transform.DOShakePosition(1f, 50, 50, 90, false, true);
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

        private void TimerTextAnimation()
        {
            TimerText.color = Color.red;
            TimerText.transform.DOScale(1.2f, 0.5f).onComplete += () =>
            {
                TimerText.color = _defaultTextTimeColor;
                TimerText.transform.DOScale(1f, 0.5f);
            };
        }
    }
}