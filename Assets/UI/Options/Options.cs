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
        [SerializeField] private Slider brightness;
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private TMP_Dropdown reso;

        public void Start() {
            float db;
            if (masterSlider == null)
                return;
            if (sfxSlider == null)
                return;
            if (bgmSlider == null)
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
                Screen.SetResolution(640,360, false);
                Debug.Log("640 x 360");
                break;
            case 1:
                Screen.SetResolution(1024,768, false);
                Debug.Log("1024 x 768");
                break;
            case 2:
                Screen.SetResolution(1280,720, false);
                Debug.Log("1280 x 720");
                break;
            case 3:
                Screen.SetResolution(1920,1080, false);
                Debug.Log("1920 x 1080");
                break;
            }
        }
        public void Brightness(){

        }
    }
}
