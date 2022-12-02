using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RAS
{
    public class OrderManager : MonoBehaviour
    {
        [SerializeField] private float orderDuration = 15;
        [SerializeField] private int maxOrder = 5;
        [SerializeField] private float orderTimer = 5;
        [SerializeField] private Order orderPrefab;
    }
}
