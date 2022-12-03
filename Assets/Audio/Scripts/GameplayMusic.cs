using System;
using Systems;
using UnityEngine;

namespace Audio.Scripts
{
    public class GameplayMusic : MonoBehaviour
    {
        [SerializeField] private AudioSource backgroundMusic;
        [SerializeField] private AudioSource dayComplete;

        private void Awake()
        {
            RecycleEvents.OnTimerRunOut += PlayDayComplete;
            RecycleEvents.OnTimerWarning += WarningSound;
            RecycleEvents.OnTimerDanger += DangerSound;
        }

        private void DangerSound()
        {
            backgroundMusic.pitch = 1.4f;
        }

        private void WarningSound()
        {
            backgroundMusic.pitch = 1.2f;
        }

        private void PlayDayComplete()
        {
            backgroundMusic.Stop();
            dayComplete.Play();
        }

        private void Start()
        {
            backgroundMusic.Play();
        }
        
        private void OnDestroy()
        {
            RecycleEvents.OnTimerRunOut -= PlayDayComplete;
            RecycleEvents.OnTimerWarning -= WarningSound;
            RecycleEvents.OnTimerDanger -= DangerSound;
        }

        public void OnExit(){
            backgroundMusic.Stop();
        }
    }
}
