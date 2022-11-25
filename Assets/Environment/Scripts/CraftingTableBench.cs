using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class CraftingTableBench : MonoBehaviour, ICraftingTable
    {
        //TODO put object on the crafting table
        //TODO craft object
        //TODO After the crafting complete, player can hold the object

        public void PutObjectOnCraftingBench(GameObject objectToCraft)
        {
            print("Put object on crafting bench");
        }
    }
}
