using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RAS
{
    public class SceneLoader : MonoBehaviour
    {
        private static string sceneToLoad;

        public static string SceneToLoad { get => sceneToLoad;}

        public static void Load(string sceneName){
            SceneManager.LoadScene(sceneName);
        }

        public static void ProgressLoad(string sceneName){
            sceneToLoad = sceneName;
            SceneManager.LoadScene("LoadingScene");
        }

        public static void ReloadLevel(){
            var currentScene = SceneManager.GetActiveScene().name;
            ProgressLoad(currentScene);
        }

        public static void LoadAddictive(string sceneName){
            SceneManager.LoadScene(sceneName,LoadSceneMode.Additive);
        }

        public static void UnloadAddictive(string scene){
            SceneManager.UnloadSceneAsync(scene);
        }
    }
}
