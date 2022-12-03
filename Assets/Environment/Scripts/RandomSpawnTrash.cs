using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Scripts
{
    public class RandomSpawnTrash : MonoBehaviour
    {
        public GameObject[] trashPrefabs;
        
        private Vector3 posisiRandom;
        
        [SerializeField(), Range(0.01f, 0.5f)] private float trashSpawnUpOffset;
        [SerializeField(), Range(1, 10)] private int size;
       
        
        void Start()
        {
            int selectedIndexFromTrashPrefabList = Random.Range(0, trashPrefabs.Length);
            var trashGameObject = ObjectPool.Instance.GetPooledObject(trashPrefabs[selectedIndexFromTrashPrefabList].name);
            trashGameObject.transform.position = transform.position + Vector3.up * trashSpawnUpOffset;
        }

        private void LegacyFariz()
        {
            for (int i = 0; i < size; i++)
            {
                var randomPositionMaxRange = 0.5f;

                float posisiXacak = Random.Range(-randomPositionMaxRange, randomPositionMaxRange);
                float posisiZacak = Random.Range(-randomPositionMaxRange, randomPositionMaxRange);


                Vector3 temporaryposition = transform.position;

                if (temporaryposition.x == 0)
                    temporaryposition.x = Random.Range(-25f, 35f);
                if (temporaryposition.z == 0)
                    temporaryposition.z = Random.Range(-20f, 20f);

                temporaryposition.x = temporaryposition.x + temporaryposition.x * posisiXacak;
                temporaryposition.z = temporaryposition.z + temporaryposition.z * posisiZacak;
                temporaryposition.y = trashSpawnUpOffset;

                transform.position = temporaryposition;

                posisiRandom = transform.position;
                int randomSampah = Random.Range(0, trashPrefabs.Length);
                var sampah = ObjectPool.Instance.GetPooledObject(trashPrefabs[randomSampah].name);
                // Instantiate(tipeSampah[randomSampah],posisiRandom,Quaternion.identity);
                print(posisiRandom);
                sampah.transform.position = posisiRandom;
            }
        }
    }
}
