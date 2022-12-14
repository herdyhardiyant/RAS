using System;
using UnityEngine;

namespace Characters.Player.Scripts
{
    [RequireComponent(typeof(Movement))]
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject spawnEffectPrefab;
        [SerializeField] private AudioClip spawnSound;

        private Movement _movement;
        private ParticleSystem _spawnEffect;
        private AudioSource _spawnAudio;

        private void Awake()
        {
            _movement = GetComponent<Movement>();
            _spawnEffect = Instantiate(spawnEffectPrefab, spawnPoint.position, Quaternion.identity)
                .GetComponent<ParticleSystem>();
            _spawnAudio = gameObject.AddComponent<AudioSource>();
            _spawnAudio.clip = spawnSound;
            _spawnAudio.time = 0.15f;
        }
        
        

        private void Update()
        {
            if (transform.position.y < -10)
            {
                RespawnToSpawnPoint();
            }
        }

        private void RespawnToSpawnPoint()
        {
            _movement.enabled = false;
            gameObject.transform.position = spawnPoint.position;
            _spawnEffect.Play();
            _spawnAudio.Play();
            _movement.enabled = true;
        }
    }
}