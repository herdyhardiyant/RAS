using System;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class SmelterCraftingSelection : MonoBehaviour
    {
        [SerializeField] private GameObject smelterPrefab;

        [SerializeField] private Trash glassBottlePrefab;

        [SerializeField] private GameObject glassSlabPrefab;
        
        [SerializeField] private GameObject metalCansPrefab;
        
        [SerializeField] private GameObject metalSlabPrefab;

        private IMachine _smelter;
        private string _glassBottleTrashName;
        private string _metalCansTrashName;

        private void Awake()
        {
            _smelter = smelterPrefab.GetComponent<IMachine>();
            _glassBottleTrashName = glassBottlePrefab.GetComponent<Trash>().TrashName;
            _metalCansTrashName = metalCansPrefab.GetComponent<Trash>().TrashName;
        }

        public bool IsObjectCanBeSmelt(string objectRecycleType)
        {
            if (objectRecycleType == _smelter.RecycleType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public GameObject GetSmelterResultFromInputObject(string trashName)
        {

            if (trashName == _glassBottleTrashName)
            {
                return glassSlabPrefab;
            }
            else if (trashName == _metalCansTrashName)
            {
                return metalSlabPrefab;
            }
            else
            {
                return null;
            }


        }
    }
}