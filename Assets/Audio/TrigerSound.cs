using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RAS
{
    public class TrigerSound : MonoBehaviour
    {
        public AudioSource playSound;

        void OnTriggerEnter(Collider picola)
        {
            playSound.Play();
        }
        
        void OnTriggerExit(Collider picola)
        {
            playSound.Pause();
        }
    }
}
