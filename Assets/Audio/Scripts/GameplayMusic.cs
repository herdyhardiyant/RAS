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
        [SerializeField] private AudioSource sellAudioSource;

        private void Awake()
        {
            
            backgroundMusic.loop = true;
            
            RecycleEvents.OnTimerRunOut += PlayDayComplete;
            RecycleEvents.OnTimerWarning += WarningSound;
            RecycleEvents.OnTimerDanger += DangerSound;
            
            RecycleEvents.OnSellItem += PlaySellSound;
            
        }

        private void PlaySellSound(ISellable sellableObject)
        {
            
            //TODO Suara gagal jual tetap keluar walaupun jual berhasil
            print("Sellable object: " + sellableObject.SellableName);
            var isInList = orders.IsInOrderList(sellableObject);
           if (isInList)
           {
               sellAudioSource.PlayOneShot(cashRegistered);

           }
           else
           {
               sellAudioSource.PlayOneShot(orderWrong);
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
