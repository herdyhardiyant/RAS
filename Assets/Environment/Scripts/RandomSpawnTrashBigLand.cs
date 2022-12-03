using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Scripts
{
    public class RandomSpawnTrashBigLand : MonoBehaviour
    {
        public GameObject[] trashPrefabs;
        
        private Vector3 RandomPosition;
        [SerializeField] private int LandSize;
        [SerializeField(), Range(0.01f, 0.49f)] private float DeviationFactor;
        [SerializeField(), Range(0.01f, 0.5f)] private float trashSpawnUpOffset;
        [SerializeField(), Range(1, 9)] private int MinAmountOffTrash;
        [SerializeField(), Range(5, 40)] private int MaxAmountOffTrash;
       
        
        void Start()
        {
            for (int i = MinAmountOffTrash; i < MaxAmountOffTrash; i++)
            {
            float MagicNumberForDisperseTrashPositionX = Random.Range(-DeviationFactor,DeviationFactor);
            float MagicNumberForDisperseTrashPositionZ = Random.Range(-DeviationFactor,DeviationFactor);
            int selectedIndexFromTrashPrefabList = Random.Range(0, trashPrefabs.Length);
            var trashGameObject = ObjectPool.Instance.GetPooledObject(trashPrefabs[selectedIndexFromTrashPrefabList].name);
            float trashSpawnXOffset = LandSize*MagicNumberForDisperseTrashPositionX;
            float trashSpawnZOffset = LandSize*MagicNumberForDisperseTrashPositionZ;
            // trashGameObject.transform.position = transform.position + Vector3.up * trashSpawnUpOffset+Vector3.forward*trashSpawnXOffset+Vector3.right*trashSpawnZOffset;
            trashGameObject.transform.position = transform.position + new Vector3(1* trashSpawnXOffset,1*trashSpawnUpOffset,1*trashSpawnZOffset);
            }
        }

        // private void LegacyFariz()
        // {
        //     for (int i = 0; i < size; i++)
        //     {
        //         var randomPositionMaxRange = 0.5f;

        //         float posisiXacak = Random.Range(-randomPositionMaxRange, randomPositionMaxRange);
        //         float posisiZacak = Random.Range(-randomPositionMaxRange, randomPositionMaxRange);


        //         Vector3 temporaryposition = transform.position;

        //         if (temporaryposition.x == 0)
        //             temporaryposition.x = Random.Range(-25f, 35f);
        //         if (temporaryposition.z == 0)
        //             temporaryposition.z = Random.Range(-20f, 20f);

        //         temporaryposition.x = temporaryposition.x + temporaryposition.x * posisiXacak;
        //         temporaryposition.z = temporaryposition.z + temporaryposition.z * posisiZacak;
        //         temporaryposition.y = trashSpawnUpOffset;

        //         transform.position = temporaryposition;

        //         RandomPosition = transform.position;
        //         int randomSampah = Random.Range(0, trashPrefabs.Length);
        //         var sampah = ObjectPool.Instance.GetPooledObject(trashPrefabs[randomSampah].name);
        //         // Instantiate(tipeSampah[randomSampah],RandomPosition,Quaternion.identity);
        //         print(RandomPosition);
        //         sampah.transform.position = RandomPosition;
        //     }
        // }
    }
}
