using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class TrashContainer : MonoBehaviour, ITrashContainer
    {
        [SerializeField] private GameObject[] trashPrefab;

        public GameObject GetInstantiatedTrash()
        {
            var randomTrashIndex = Random.Range(0, trashPrefab.Length);
            var trashName = trashPrefab[randomTrashIndex].name;
            var trashObject = ObjectPool.Instance.GetPooledObject(trashName);
            return trashObject;
        }
    }
}