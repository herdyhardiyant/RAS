using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class CraftingTableBench : MonoBehaviour, ICraftingTable
    {
        [SerializeField] private Transform putObjectLocation;

        private GameObject _objectOnCraftingTable;
        //TODO craft object if the material is on the table
        //TODO After the crafting complete, player can hold the object

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