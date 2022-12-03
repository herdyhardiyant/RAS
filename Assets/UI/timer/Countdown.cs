using Systems;
using TMPro;
using UnityEngine;

namespace UI.timer
{
    public class Countdown : MonoBehaviour
    {
        [SerializeField] TMP_Text TimerText;
        [SerializeField] GameObject GameOverPanel;

        public float Waktu = 100;
        
        void SetText()
        {
            int Menit = Mathf.FloorToInt(Waktu / 60);
            int Detik = Mathf.FloorToInt(Waktu % 60);
            TimerText.text = Menit.ToString("00") + ":" + Detik.ToString("00");
        }

        float sec;

        private void Update()
        {
            // SetText();
            if (Waktu > 0)
            {
                sec += Time.deltaTime;
                if (sec >= 1)
                {
                    Waktu--;
                    sec = 0;
                }
            }

            if (Waktu <= 0)
            {
                RecycleEvents.TimerRunOut();
                GameOverPanel.SetActive(true);
            }

            SetText();
        }
    }
}