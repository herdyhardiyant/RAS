using System;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Scripts
{
    public class PickupObjectPool : MonoBehaviour
    {
        // TODO Pool
        // Get all object prefab
        // instantiate all object to pool
            // Store the object in a list
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
        public List<GameObject> pooledObjects;
        public GameObject objectToPool;
        public int amountToPool;
        
        private void Awake()
        {
            SharedInstance = this;
        }

        private void Start()
        {
            pooledObjects = new List<GameObject>();
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject) Instantiate(objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }
}
