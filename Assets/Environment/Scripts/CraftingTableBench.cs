using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class CraftingTableBench : MonoBehaviour, ICraftingTable
    {
        public bool IsCrafting => _isCrafting;
        

        [SerializeField] private Transform putObjectLocation;
        [SerializeField] private float craftingTime = 2f;
        [SerializeField] private AudioClip soundPalu;

        private GameObject _craftingMaterialInput;
        private bool _isCrafting;
        private GameObject _craftingResultPrefab;
        private AudioSource _audioSource;
        
        private void ReplaceMaterialToCraftingResult()
        {
            ObjectPool.Instance.ReturnObjectToPool(_craftingMaterialInput);
            var craftingResult = ObjectPool.Instance.GetPooledObject(_craftingResultPrefab.name);
            PutObjectOnCraftingBench(craftingResult);
        }

        public bool StartCrafting(GameObject materialInput)
        {
            var isCraftingMaterialExist = materialInput.TryGetComponent<CraftingMaterial>(out var craftingMaterial);

            if (!isCraftingMaterialExist)
            {
                return false;
            }

            _craftingResultPrefab = craftingMaterial.CraftingResultPrefab;

            _craftingMaterialInput = materialInput;

            _craftingMaterialInput.tag = "Untagged";

            PutObjectOnCraftingBench(_craftingMaterialInput);

            _audioSource.PlayOneShot(soundPalu);

            StartCoroutine(CraftingDelay());

            return true;
        }

        private void Awake()
        {
            _isCrafting = false;
            _craftingResultPrefab = null;
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        private IEnumerator CraftingDelay()
        {
            _isCrafting = true;
            yield return new WaitForSecondsRealtime(craftingTime);
            _isCrafting = false;

            ReplaceMaterialToCraftingResult();
        }

        private void PutObjectOnCraftingBench(GameObject objectToPut)
        {
            if (!objectToPut) return;

            objectToPut.transform.position = putObjectLocation.position;
            objectToPut.transform.rotation = putObjectLocation.rotation;
            objectToPut.transform.parent = putObjectLocation;
        }
    }
}