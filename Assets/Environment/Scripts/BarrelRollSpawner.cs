
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Environment.Scripts
{
    public class BarrelRollSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject barrelPrefabs;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float maxSpawnDelay = 3f;
        [SerializeField] private float minSpawnDelay = 1f;

        private GameObject _barrel;
        private Rigidbody _barrelRb;

        private void Start()
        {
            StartCoroutine(SpawnBarrel());
        }

        private IEnumerator SpawnBarrel()
        {
            while (true)
            {
                var delay = Random.Range(minSpawnDelay, maxSpawnDelay);
                yield return new WaitForSeconds(delay);
                
                _barrel = ObjectPool.SharedInstance.GetPooledObject(barrelPrefabs.name);
                _barrel.transform.position = spawnPoint.position;
                _barrel.transform.forward = spawnPoint.forward;
                _barrel.transform.parent = spawnPoint;
                _barrel.transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            

        }
    }
}