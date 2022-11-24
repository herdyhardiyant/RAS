using System;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Scripts
{
    public class InputIconManipulator : MonoBehaviour
    {
        [SerializeField] private GameObject iconList;
        [SerializeField] private GameObject iconPrefab;
        [SerializeField] private Sprite[] sprites;
        
        // private Dictionary<string,Sprite> _spriteDictionary = new Dictionary<string, Sprite>();
        
        private Camera _camera;
        private bool _showIcon;
        
        
        public void ToggleShowIcon()
        {
            _showIcon = !_showIcon;
            iconList.SetActive(_showIcon);
        }
      
        private void Awake()
        {
            _showIcon = true;
            // foreach (var iconSprite in sprites)
            // {
            //     _spriteDictionary.Add(iconSprite.name, iconSprite);
            // }
            
            
        }

        private void Update()
        {
            // if (_showIcon)
            // {
            // }
            
            
            // var dirToCam = transform.position - _camera.transform.position;
            // print("dirToCam: " + dirToCam);
            // gameObject.transform.forward = dirToCam;
        }
    }
}
