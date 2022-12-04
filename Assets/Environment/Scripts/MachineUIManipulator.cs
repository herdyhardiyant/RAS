using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Environment.Scripts
{
    public class MachineUIManipulator : MonoBehaviour
    {
        
        [SerializeField] private Image completeImage;
        [SerializeField] private Image blockImage;
        [SerializeField] private Image notifImage;
        
        public void ShowComplete()
        {
            completeImage.gameObject.SetActive(true);
            blockImage.gameObject.SetActive(false);
            notifImage.gameObject.SetActive(false);
        }
        
        public void ShowBlock()
        {
            completeImage.gameObject.SetActive(false);
            blockImage.gameObject.SetActive(true);
            notifImage.gameObject.SetActive(false);
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
            notifImage.gameObject.SetActive(true);
        }

        private void Awake()
        {
            HideImages();
            var direction = Camera.main.transform.position - transform.position;
            gameObject.transform.forward = direction;
        }
    }
}
