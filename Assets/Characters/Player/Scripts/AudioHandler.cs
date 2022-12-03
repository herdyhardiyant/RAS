using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters.Player.Scripts
{
    public class AudioHandler : MonoBehaviour
    {
        [SerializeField] private AudioClip[] walkSound;
        
        [Range(0, 1)]
        [SerializeField] private float walkSoundVolume = 0.3f;
        private AudioSource _audioSource;
        
        private void Awake()
        {
            _audioSource =  gameObject.AddComponent<AudioSource>();
            _audioSource.volume = walkSoundVolume;
        }

        public void PlayFootstep()
        {
            var randomIndex = Random.Range(0, walkSound.Length);
            _audioSource.clip = walkSound[randomIndex];
            _audioSource.Play();
        }
        
    }
}
