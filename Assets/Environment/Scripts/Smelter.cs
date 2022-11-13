using System;
using UnityEngine;

namespace Environment.Scripts
{
    public class Smelter : MonoBehaviour
    {
    
        // TODO: Add a list of ores that can be smelted
        // TODO: Add on and off states
        // TODO: Import the materials assets that can be smelted
        // TODO: Player holds the material and click f to smelt
        // TODO: Add a timer to smelt the material
        // TODO: UI to show the smelting progress
        // TODO: Add a sound effect when smelting
        // TODO: Add a sound effect when smelting is done
        

        [SerializeField] private bool debugActiveSmelting = false;
        
        private Light[] _lights;

        private void Awake()
        {
            _lights = GetComponentsInChildren<Light>();
        }

        void Update()
        {
            if (debugActiveSmelting)
            {
                SetSmelterFireActive(true);

            } else
            {
                SetSmelterFireActive(false);
            }
        
        }

        private void SetSmelterFireActive( bool active)
        {
            foreach (var light in _lights)
            {
                light.enabled = active;
            }
        }
    }
}
