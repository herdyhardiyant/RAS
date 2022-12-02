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
        
        public GameObject GetPooledObject(string prefabName)
        {
            if (_pooledObjects.ContainsKey(prefabName))
            {
                for (int i = 0; i < _pooledObjects[prefabName].Count; i++)
                {
                    if (!_pooledObjects[prefabName][i].activeInHierarchy)
                    {
                        var pooledObject = _pooledObjects[prefabName][i];
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