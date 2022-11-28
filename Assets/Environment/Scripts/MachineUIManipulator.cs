using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RAS.Environment.MachineUI
{
    public class MachineUIManipulator : MonoBehaviour
    {
        
        [SerializeField] private Image completeImage;
        [SerializeField] private Image blockImage;
        
        
        public void ShowComplete()
        {
            completeImage.gameObject.SetActive(true);
            blockImage.gameObject.SetActive(false);
        }
        
        public void ShowBlock()
        {
            completeImage.gameObject.SetActive(false);
            blockImage.gameObject.SetActive(true);
        }

        public IEnumerator ShowBlockDelay()
        {
            ShowBlock();
            yield return new WaitForSeconds(.5f);
            HideImages();
        }
        
        public void HideImages()
        {
            completeImage.gameObject.SetActive(false);
            blockImage.gameObject.SetActive(false);
        }

        private void Awake()
        {
            HideImages();
            var direction = Camera.main.transform.position - transform.position;
            gameObject.transform.forward = direction;
        }
    }
}
