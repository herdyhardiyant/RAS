using UnityEngine;

namespace Interfaces
{
    public interface ICraftingTable
    {  
 
        public bool IsCrafting { get; }
        
        
        /// <summary>
        /// Start crafting and get the crafted object. Return false if the crafting is not possible
        /// and return true if the crafting is possible
        /// </summary>
        /// <param name="materialInput"></param>
        /// <returns></returns>
        public bool StartCrafting(GameObject materialInput);
    }
}