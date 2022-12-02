using System;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Scripts
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool SharedInstance;
        
        [SerializeField] GameObject[] objectPrefabs;
        [SerializeField] private int amountToPoolForEachObject = 10;

        private Dictionary<string, List<GameObject>> _pooledObjects;

        
        public void ReturnObjectToPool(GameObject objectToReturn)
        {
            objectToReturn.transform.parent = transform;
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
                        var pooledObject = _pooledObjects[objectName][i];
                        pooledObject.SetActive(true);
                        return pooledObject;
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
            
            PreparePool();
        }

        private void PreparePool()
        {
            _pooledObjects = new Dictionary<string, List<GameObject>>();

            foreach (var prefab in objectPrefabs)
            {
                var objectList = new List<GameObject>();

                for (int i = 0; i < amountToPoolForEachObject; i++)
                {
                    var obj = Instantiate(prefab, transform);
                    obj.SetActive(false);
                    objectList.Add(obj);
                }

                _pooledObjects.Add(prefab.name, objectList);
            }
        }

     
    }
}