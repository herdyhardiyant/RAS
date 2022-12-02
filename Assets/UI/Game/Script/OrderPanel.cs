using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace RAS
{
    public class OrderPanel : MonoBehaviour
    {
        [SerializeField] private Order orderPrefab;


        private void Awake() {
            Assert.IsNotNull(orderPrefab);
        }
    }
}
