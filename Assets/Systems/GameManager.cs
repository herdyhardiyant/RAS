using System;
using UnityEngine;

namespace Systems
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] player;
        private void Awake()
        {
           RecycleEvents.OnTimerRunOut += OnTimerRunOut;
        }

        private void OnTimerRunOut()
        {
            foreach(GameObject go in player)
                go.SetActive(false);
        }

        private void OnDestroy()
        {
            RecycleEvents.OnTimerRunOut -= OnTimerRunOut;
        }
    }
}
