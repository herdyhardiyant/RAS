using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace RAS
{
    public class Order : MonoBehaviour
    {
        [SerializeField] private Image itemIMG;
        [SerializeField] private List<Image> materialList = new List<Image>();
        [SerializeField] private RectTransform rootRectTransform;
        public float CurrentAnchorX { get; private set; }
        public float SizeDeltaX => rootRectTransform.sizeDelta.x;
        
    }
}
