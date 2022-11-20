using UnityEngine;

namespace Interfaces
{
    public interface IMachine
    {
        public GameObject CurrentlyProcessedMaterial { get; }
        
        public void InputMaterial(GameObject material);
        public GameObject GetResultAfterProcessing();
        public GameObject GetExpectedResult(GameObject material);


    }
}