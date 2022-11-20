using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class Smelter : MonoBehaviour, IMachine
    {
    
        // TODO: Add a list of ores that can be smelted
        // TODO: Import the materials assets that can be smelted
        // TODO: Player holds the material and click f to smelt
        // TODO: Add a timer to smelt the material
        // TODO: UI to show the smelting progress
        // TODO: Add a sound effect when smelting
        // TODO: Add a sound effect when smelting is done
        // TODO: Add UI when smelting is done
        
        public GameObject CurrentlyProcessedMaterial { get; }
        
        
        // [SerializeField] private bool debugActiveSmelting = false;
        
        private Light[] _lights;
        private bool _isSmelting;
        
        public void InputMaterial(GameObject material)
        {
            Destroy(material);
            _isSmelting = true;
        }

        public GameObject GetResultAfterProcessing()
        {
            throw new NotImplementedException();
        }

        public GameObject GetExpectedResult(GameObject material)
        {
            throw new NotImplementedException();
        }

        private void Awake()
        {
            _lights = GetComponentsInChildren<Light>();
        }

        void Update()
        {
            SetSmelterFireActive(_isSmelting);
            
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
