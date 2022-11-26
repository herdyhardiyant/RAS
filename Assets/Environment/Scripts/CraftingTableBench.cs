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
        
        private GameObject _craftingMaterial;
        private bool _isCrafting;

        //TODO craft object if the material is on the table
        // player press f on front of the bench *
        // player put material on the bench *
        // Player start crafting animation and disable player movement *
        // Wait for 3 seconds *
        // Player stop crafting animation and enable player movement
        // Player get crafted object from CraftingMaterial class
        // Hold the crafted object in hand

        //TODO After the crafting complete, player can hold the object


        private void Awake()
        {
            _isCrafting = false;
        }

        public bool StartCrafting(GameObject materialInput)
        {
            if (!materialInput.CompareTag("Material")) return false;
            _craftingMaterial = materialInput;
            PutObjectOnCraftingBench();
            StartCoroutine(CraftingDelay());
            return true;
        }

        private IEnumerator CraftingDelay()
        {
            print("Crafting started");
            _isCrafting = true;
            yield return new WaitForSecondsRealtime(craftingTime);
            _isCrafting = false;
            print("Crafting finished");
        }

        private void PutObjectOnCraftingBench()
        {
            _craftingMaterial.transform.position = putObjectLocation.position;
            _craftingMaterial.transform.rotation = putObjectLocation.rotation;
            _craftingMaterial.transform.parent = putObjectLocation;
            _craftingMaterial.tag = "Untagged";
        }
    }
}