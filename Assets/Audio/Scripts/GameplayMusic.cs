using System;
using GameplayData;
using Interfaces;
using Systems;
using UnityEngine;

namespace Audio.Scripts
{
    public class GameplayMusic : MonoBehaviour
    {
        [SerializeField] private AudioSource backgroundMusic;
        [SerializeField] private AudioSource dayComplete;
        [SerializeField] private AudioClip cashRegistered;
        [SerializeField] private AudioClip orderWrong;
        [SerializeField] private Orders orders;
        [SerializeField] private AudioClip paperFlip;
        
        private AudioSource _sellAudioSource;
        private AudioSource _orderUpdateAudioSource;
        
        
        private void Awake()
        {
            _sellAudioSource = gameObject.AddComponent<AudioSource>();
            backgroundMusic.loop = true;
            
            _orderUpdateAudioSource = gameObject.AddComponent<AudioSource>();
            
            RecycleEvents.OnTimerRunOut += PlayDayComplete;
            RecycleEvents.OnTimerWarning += WarningSound;
            RecycleEvents.OnTimerDanger += DangerSound;
            
            RecycleEvents.OnSellItem += PlaySellSound;
            Orders.OnOrderChanged += PlayOrderUpdateSound;
        }

        private void PlayOrderUpdateSound()
        {
            _orderUpdateAudioSource.PlayOneShot(paperFlip);
        }

        private void PlaySellSound(ISellable sellableObject)
        {
            var isInList = orders.IsInOrderList(sellableObject);
           if (isInList)
           {
               _sellAudioSource.PlayOneShot(cashRegistered);

           }
           else
           {
               _sellAudioSource.PlayOneShot(orderWrong);
           }
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
        }
    }
}
