using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class BarrelRoll : MonoBehaviour, ISpawnable
    {
        [SerializeField] private string barrelName;
        public string Name => barrelName;
    }
}