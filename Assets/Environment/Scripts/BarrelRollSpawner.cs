using System;
using System.Collections;
using UnityEngine;

namespace Environment.Scripts
{
    public class BarrelRollSpawner : MonoBehaviour
    {
        // TODO Barrel Spawner from the big trash container
        // Get all barrel prefab to get their names
        // randomly get the instance of the barrel from the pool
        // Spawn position from inside the container
        // Barrel rotation 90 degrees in the z axis
        // Barrel roll and move forward

        // If the player hit the barrel
        // the barrel will return to pool
        // the player will get knocked back

        [SerializeField] private GameObject barrelPrefabs;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnDelay = 3f;

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
                
                yield return new WaitForSeconds(spawnDelay);
                
                _barrel = ObjectPool.SharedInstance.GetPooledObject(barrelPrefabs.name);
                _barrel.transform.position = spawnPoint.position;
                _barrel.transform.forward = spawnPoint.forward;
                _barrel.transform.parent = spawnPoint;
                _barrel.transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            

        }
    }
}