using UnityEngine;

namespace GameplayData
{
    public class PlayerGameplayData : MonoBehaviour
    {
        //TODO Add customer orders data 
        
        // Create interface for player data
        
        public int TotalMoney => _totalMoney;
        private int _totalMoney;
        
        public void AddMoney(int amount)
        {
            _totalMoney += amount;
        }
        
        public void SubtractMoney(int amount)
        {
            _totalMoney -= amount;
        }
        
    }
}
