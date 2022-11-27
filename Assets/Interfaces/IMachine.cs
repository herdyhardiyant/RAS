using UnityEngine;

namespace Interfaces
{
    public interface IMachine
    {
        public bool IsProcessing { get; }
        public bool IsHoldingOutputItem { get; }
        public string RecycleType { get; }
        
        /// <summary>
        /// Input material to the machine. Return true if the material was accepted and false if it was not.
        /// </summary>
        /// <param name="inputMaterialGameObject that can be picked up by player and can be put in machine"></param>
        /// <returns></returns>
        public bool InputMaterial(GameObject inputMaterialGameObject);
        public GameObject GetInstantiateResultAfterSmelting();



    }
}