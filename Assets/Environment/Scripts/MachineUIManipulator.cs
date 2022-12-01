using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Environment.Scripts
{
    public class MachineUIManipulator : MonoBehaviour
    {
        
        [SerializeField] private Image completeImage;
        [SerializeField] private Image blockImage;
        [SerializeField] private AudioSource sound;
        [SerializeField] private AudioClip completeSound;
        
        
        public void ShowComplete()
        {
            completeImage.gameObject.SetActive(true);
            blockImage.gameObject.SetActive(false);
            sound.PlayOneShot(completeSound);
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
