using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace RAS
{
    public class Options : MonoBehaviour
    {
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider sfxSlider;
        [SerializeField] private Slider bgmSlider;
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private TMP_Dropdown reso;
        [SerializeField] private TMP_Dropdown screenDropdown;
        private bool screen = true;

        public void Start() {
            float db;
            if (masterSlider == null)
                return;
            if (sfxSlider == null)
                return;
            if (bgmSlider == null)
                return;
            if (reso == null)
                return;
            if (screenDropdown == null)
                return;
            

            if (mixer.GetFloat("Master_Volume", out db))
                sfxSlider.value = (db+80)/80;    

            if (mixer.GetFloat("SFX_Volume", out db))
                sfxSlider.value = (db+80)/80;    

            if (mixer.GetFloat("BGM_Volume", out db))
                sfxSlider.value = (db+80)/80;    
        }

        public void MasterVolume(float value){
            value = value*80 - 80;

            mixer.SetFloat("Master_Volume",value);
        }
        public void SFXVolume(float value){
            value = value*80 - 80;

            mixer.SetFloat("SFX_Volume",value);
        }
        public void BGMVolume(float value){
            value = value*80 - 80;

            mixer.SetFloat("BGM_Volume",value);
        }

        public void Mute(bool Muted){
            if (Muted){
                AudioListener.volume = 1;
            }
            else{
                AudioListener.volume = 0;
            }

        }

        public void Resolution(){
        switch(reso.value){
            case 0:
                Screen.SetResolution(1920,1080, screen);
                break;
            case 1:
                Screen.SetResolution(1366,768, screen);
                break;
            case 2:
                Screen.SetResolution(1280,1024, screen);
                break;
            case 3:
                Screen.SetResolution(1024,768, screen);
                break;
            case 4:
                Screen.SetResolution(800,600, screen);
                break;
            }
        }
        public void ScreenTogle(){
            switch (screenDropdown.value)
            {
                
                case 0:
                    screen = true;
                    Screen.fullScreen = screen;
                    break;
                case 1:
                    screen = false;
                    Screen.fullScreen = screen;
                    break;
            }
        }
    }
}
