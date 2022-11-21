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


        [SerializeField] private GameObject plasticBarPrefab;
        public bool IsProcessing => _isSmelting;
        public bool IsHoldingMaterial => _isSmeltingDone;
        
        private Light[] _lights;
        private bool _isSmelting;
        private bool _isSmeltingDone;
        
        public void InputMaterial(GameObject material)
        {
            if (_isSmeltingDone)
            {
                return;
            }
            
            Destroy(material);
            _isSmelting = true;
            
        }

        public GameObject GetResultAfterProcessing()
        {
            if(!_isSmeltingDone){
                return null;
            }
            print("Get smelting result");
            return plasticBarPrefab;

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
            if (_isSmelting)
            {
                StartCoroutine(ProcessingDelay());
            }

            SmelterFireLightsUpdate();
        }
        
        IEnumerator ProcessingDelay()
        {
            yield return new WaitForSecondsRealtime(3);
            _isSmeltingDone = true;
            _isSmelting = false;
        }
        
        private void SmelterFireLightsUpdate( )
        {
            foreach (var smelterLight in _lights)
            {
                smelterLight.enabled = _isSmelting;
            }
        }

   
    }
}
