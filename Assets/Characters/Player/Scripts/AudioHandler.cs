using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters.Player.Scripts
{
    public class AudioHandler : MonoBehaviour
    {
        [SerializeField] private AudioClip[] walkSound;
        private AudioSource _audioSource;
        
        private void Awake()
        {
            _audioSource =  gameObject.AddComponent<AudioSource>();
        }

        public void PlayFootstep()
        {
            var randomIndex = Random.Range(0, walkSound.Length);
            _audioSource.clip = walkSound[randomIndex];
            _audioSource.Play();
        }
        
    }
}
