using System;
using System.Collections;
using Interfaces;
using RAS.Environment.MachineUI;
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

        public GameObject CurrentlyProcessedMaterial { get; }
        public string RecycleType => "Smelter";
        [SerializeField] private float smeltingTime = 5f;
        [SerializeField] private MachineUIManipulator machineUI;
        [SerializeField] private SmelterCraftingSelection smelterCraftingSelection;

        public bool IsProcessing => _isSmelting;
        public bool IsHoldingOutputItem => _isHoldingResult;

        private Light[] _lights;
        private bool _isSmelting;
        private bool _isHoldingResult;
        private string _inputTrashName;
      
        public bool InputMaterial(GameObject inputMaterialGameObject)
        {
            var inputRecycleName = inputMaterialGameObject.TryGetComponent<Trash>(out var trash );

            if (!inputRecycleName)
            {
                StartCoroutine(machineUI.ShowBlockDelay());
                return false;
            }

            if (!smelterCraftingSelection.IsObjectCanBeSmelt(trash.RecycleType))
            {
                StartCoroutine(machineUI.ShowBlockDelay());
                return false;
            }

            if (_isHoldingResult || _isSmelting)
            {
                return false;
            }

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

            var result = smelterCraftingSelection.GetSmelterResultFromInputObject(_inputTrashName);
            
            machineUI.HideImages();
            
            return result;
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
            SmelterFireLightsUpdate();
        }

        private IEnumerator ProcessingDelay()
        {
            
            _isHoldingResult = false;
            yield return new WaitForSecondsRealtime(smeltingTime);
            _isHoldingResult = true;
            _isSmelting = false;
            machineUI.ShowComplete();
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