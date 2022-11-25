using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class CraftingTableBench : MonoBehaviour, ICraftingTable
    {
        [SerializeField] private Transform putObjectLocation;
        private GameObject _objectOnCraftingTable;
        
        
        //TODO craft object if the material is on the table
        // player put material on the bench
        // player press f on front of the bench
        // Player start crafting animation and disable player movement
        // Wait for 3 seconds
        // Player stop crafting animation and enable player movement
        // Player get crafted object from CraftingMaterial class
        // Hold the crafted object in hand
        
        //TODO After the crafting complete, player can hold the object


        public void StartCrafting()
        {
            
        }
        
        public void PutObjectOnCraftingBench(GameObject objectToCraft)
        {
            _objectOnCraftingTable = objectToCraft;
            _objectOnCraftingTable.transform.position = putObjectLocation.position;
            _objectOnCraftingTable.transform.rotation = putObjectLocation.rotation;
            _objectOnCraftingTable.transform.parent = putObjectLocation;
            _objectOnCraftingTable.tag = "Untagged";
        }
    }
}