using System;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Scripts
{
    public class PickupObjectPool : MonoBehaviour
    {
        // TODO Pool
        // Get all object prefab *

        // Create scriptable object for each object prefab
        
        // instantiate all object to pool
        // Create dictionary to store the object
        // Give a name in the prefab script to identify the object
        // Dictionary key is the object name
        // Dictionary value is the list of object

        // get object from pool
        // Call a function and input the object name
        // Set the object to active

        // Return the object
        // return object to pool
        // Call a function and input the object
        // Set the object to inactive

        public static PickupObjectPool SharedInstance;

        [SerializeField] GameObject[] pickupObjectPrefabs;
        [SerializeField] private int amountToPoolForEachObject = 10;

        private Dictionary<string, List<GameObject>> _pooledObjects;

        
        public void ReturnObjectToPool(GameObject objectToReturn)
        {
            objectToReturn.SetActive(false);
        }
        
        public GameObject GetPooledObject(string objectName)
        {
            if (_pooledObjects.ContainsKey(objectName))
            {
                for (int i = 0; i < _pooledObjects[objectName].Count; i++)
                {
                    if (!_pooledObjects[objectName][i].activeInHierarchy)
                    {
                        return _pooledObjects[objectName][i];
                    }
                }
            }

            return null;
        }
        
        private void Awake()
        {
            if (SharedInstance == null)
            {
                SharedInstance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _pooledObjects = new Dictionary<string, List<GameObject>>();

            foreach (var pickupPrefab in pickupObjectPrefabs)
            {
                var objectList = new List<GameObject>();

                for (int i = 0; i < amountToPoolForEachObject; i++)
                {
                    var obj = Instantiate(pickupPrefab);
                    obj.SetActive(false);
                    objectList.Add(obj);
                }

                _pooledObjects.Add(pickupPrefab.name, objectList);
            }
        }
    }
}