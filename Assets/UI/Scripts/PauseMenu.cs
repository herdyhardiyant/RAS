using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RAS
{
    public class PauseMenu : MonoBehaviour
    {
        private bool gameIsPaused = false;
        [SerializeField] public GameObject pauseMenuCanvas;

        private void Start(){
            Time.timeScale = 1f;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(gameIsPaused){
                    Resume();
                }
                else{
                    Pause();
                }
            }
        }
        void Pause(){
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
        public void Resume(){
            pauseMenuCanvas.SetActive(false);
                Time.timeScale = 1f;
            gameIsPaused = false;
        }
    }
}
