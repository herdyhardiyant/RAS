using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class TrashContainer : MonoBehaviour, ITrashContainer
    {
        // Store all trash objects in this array *
        // Player press f to interact with trash container
        // Randomly select trash from array
        // Instantiate trash
        // Hold trash in hand

        [SerializeField] private GameObject[] trashPrefab;

        public GameObject GetInstantiatedTrash()
        {
            var randomTrashIndex = Random.Range(0, trashPrefab.Length);
            var trash = Instantiate(trashPrefab[randomTrashIndex], transform.position, Quaternion.identity);
            return trash;
        }
    }
}