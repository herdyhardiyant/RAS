using System;
using UnityEngine;

namespace Systems
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private void Awake()
        {
           RecycleEvents.OnTimerRunOut += OnTimerRunOut;
        }

        private void OnTimerRunOut()
        {
            player.SetActive(false);
        }

        private void OnDestroy()
        {
            RecycleEvents.OnTimerRunOut -= OnTimerRunOut;
        }
    }
}
