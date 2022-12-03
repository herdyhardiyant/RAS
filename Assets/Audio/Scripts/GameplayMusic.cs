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
        }
    }
}
