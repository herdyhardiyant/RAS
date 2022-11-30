using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class SellableObject : MonoBehaviour, IPickupable
    {
        [SerializeField] private string objectName;
        [SerializeField] private int price;
        public string Name => objectName;
    }
}
