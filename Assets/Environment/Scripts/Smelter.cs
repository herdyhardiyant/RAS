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
        // TODO: Add a timer to smelt the material
        // TODO: Add a timer ui to show the progress of the smelting
        // TODO: Add a sound effect when smelting
        // TODO: Add a sound effect when smelting is done
        // TODO: Add UI when smelting is done

        public GameObject CurrentlyProcessedMaterial { get; }
        public string RecycleType => "Smelter";

        [SerializeField] private GameObject plasticBarPrefab;
        [SerializeField] private GameObject machineUI;
        [SerializeField] private SmelterCrafting smelterCrafting;

        public bool IsProcessing => _isSmelting;
        public bool IsHoldingOutputItem => _isHoldingResult;

        private Light[] _lights;
        private bool _isSmelting;
        private bool _isHoldingResult;
        private string _inputTrashName;
      
        public bool InputMaterial(GameObject inputMaterialGameObject)
        {
            var inputRecycleName = inputMaterialGameObject.TryGetComponent<Trash>(out var trash );
            
            if(!inputRecycleName) return false;
            

            if (!smelterCrafting.IsObjectCanBeSmelt(trash.RecycleType))
            {
                return false;
            }

            if (_isHoldingResult || _isSmelting) return false;
            
            _inputTrashName = trash.TrashName;

            // TODO: Send the object to pool and hide it;
            Destroy(inputMaterialGameObject);
            
            _isSmelting = true;
            
            StartCoroutine(ProcessingDelay());
            
            return true;
        }

        public GameObject GetResultAfterProcessing()
        {
            if (!_isHoldingResult)
            {
                return null;
            }

            _isHoldingResult = false;
            machineUI.SetActive(false);
            
            var result = smelterCrafting.GetSmelterResultFromInputObject(_inputTrashName);

            return result;
        }

        public GameObject GetExpectedResult(GameObject material)
        {
            throw new NotImplementedException();
        }


        private void Awake()
        {
            _lights = GetComponentsInChildren<Light>();
            machineUI.SetActive(false);
            var direction = Camera.main.transform.position - transform.position;
            machineUI.transform.forward = direction;
        }

        void Update()
        {
            SmelterFireLightsUpdate();
        }

        private IEnumerator ProcessingDelay()
        {
            _isHoldingResult = false;
            yield return new WaitForSecondsRealtime(1);
            _isHoldingResult = true;
            _isSmelting = false;
            
            machineUI.SetActive(true);
        }

        private void SmelterFireLightsUpdate()
        {
            foreach (var smelterLight in _lights)
            {
                smelterLight.enabled = _isSmelting;
            }
        }
    }
}