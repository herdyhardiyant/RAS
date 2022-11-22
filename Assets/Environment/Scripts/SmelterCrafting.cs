using System;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class SmelterCrafting : MonoBehaviour
    {
        [SerializeField] private GameObject smelterPrefab;

        [SerializeField] private Trash glassBottlePrefab;

        [SerializeField] private GameObject glassSlabPrefab;

        private IMachine _smelter;
        private string _glassBottleTrashName;

        private void Awake()
        {
            _smelter = smelterPrefab.GetComponent<IMachine>();
            _glassBottleTrashName = glassBottlePrefab.GetComponent<Trash>().TrashName;
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
            print("inputObjectRecycleName: " + trashName);
            print("glassBottleRecycleName: " + _glassBottleTrashName);
            if (trashName == _glassBottleTrashName)
            {
                print("smelling glass bottle");
                return glassSlabPrefab;
            }
            else
            {
                print("smelling nothing");
                return null;
            }


        }
    }
}