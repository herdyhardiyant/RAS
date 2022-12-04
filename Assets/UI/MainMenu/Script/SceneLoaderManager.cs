using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RAS
{
    public class SceneLoaderManager : MonoBehaviour
    {
        public static void Load(string sceneName){
            SceneLoader.Load(sceneName);
        }
        public static void ProgressLoad(string sceneName){
            SceneLoader.ProgressLoad(sceneName);
        }

        public static void ReloadLevel(){
            SceneLoader.ReloadLevel();
        }

        // public static void LoadNextLevel(){
        //     SceneLoader.LoadNextLevel();
        // }
        public static void LoadAddictive(string sceneName){
            SceneLoader.LoadAddictive(sceneName);
        }

        public static void UnloadAddictive(string sceneName){
            SceneLoader.UnloadAddictive(sceneName);
        }

        public void Quitgame(){
            Application.Quit();
        }
    }
}
