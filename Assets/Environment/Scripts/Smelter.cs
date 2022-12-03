using System;
using System.Collections;
using System.Security.Cryptography;
using Interfaces;
using UnityEngine;

namespace Environment.Scripts
{
    public class Smelter : MonoBehaviour, IMachine
    {
        public string RecycleType => "Smelter";
        [SerializeField] private float smeltingTime = 5f;
        [SerializeField] private MachineUIManipulator machineUI;
        [SerializeField] private AudioClip smeltingSound;
        [SerializeField] private AudioClip smeltingCompleteSound;
        // [SerializeField] private AudioSource sound;

        public bool IsProcessing => _isSmelting;
        public bool IsHoldingOutputItem => _isHoldingResult;
        
        private AudioSource _sound;
        private Light[] _lights;
        private bool _isSmelting;
        private bool _isHoldingResult;

        private Trash _inputTrash;

        public bool InputMaterial(GameObject inputMaterialGameObject)
        {
            if (_isHoldingResult || _isSmelting)
            {
                return false;
            }

            var isTrashCompAvailable = inputMaterialGameObject.TryGetComponent<Trash>(out var trash);

            if (!isTrashCompAvailable)
            {
                StartCoroutine(machineUI.ShowBlockDelay());
                return false;
            }

            _inputTrash = trash;

            inputMaterialGameObject.SetActive(false);

            _isSmelting = true;
            _sound.PlayOneShot(smeltingSound);
            StartCoroutine(ProcessingDelay());

            return true;
        }

        public GameObject GetInstantiateResultAfterSmelting()
        {
            if (!_isHoldingResult || !_inputTrash)
            {
                return null;
            }
            
            _isHoldingResult = false;
            var result = ObjectPool.Instance.GetPooledObject(_inputTrash.GetSmeltedPrefab.name);
            machineUI.HideImages();
            
            ObjectPool.Instance.ReturnObjectToPool(_inputTrash.gameObject);
            
            _inputTrash = null;

            return result;
        }

        private void Awake()
        {
            _lights = GetComponentsInChildren<Light>();
            _sound = gameObject.AddComponent<AudioSource>();
            
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
            _sound.PlayOneShot(smeltingCompleteSound);

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