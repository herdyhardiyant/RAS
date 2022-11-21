using UnityEngine;

namespace Interfaces
{
    public interface IMachine
    {
        public GameObject CurrentlyProcessedMaterial { get; }
        public bool IsProcessing { get; }
        public bool IsHoldingMaterial { get; }
        
        public void InputMaterial(GameObject material);
        public GameObject GetResultAfterProcessing();
        public GameObject GetExpectedResult(GameObject material);
        
        

    }
}