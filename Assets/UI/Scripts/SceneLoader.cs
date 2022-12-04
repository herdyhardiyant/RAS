using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RAS
{
    public class SceneLoader : MonoBehaviour
    {
        private static string sceneToLoad;

        public static string SceneToLoad { get => sceneToLoad; }

        public static void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public static void ProgressLoad(string sceneName)
        {
            sceneToLoad = sceneName;
            SceneManager.LoadScene("LoadingScene");
        }

        public static void ReloadLevel()
        {
            var currentScene = SceneManager.GetActiveScene().name;
            ProgressLoad(currentScene);
        }
        public static void LoadNextLevel()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            int nextLevel = int.Parse(currentSceneName.Split("SpawnLevel")[1]) + 1;
            string nextSceneName = "SpawnLevel" + nextLevel;

            if (SceneUtility.GetBuildIndexByScenePath(nextSceneName) == -1)
            {
                nextSceneName = "SpawnLevel1";
                Debug.LogError(nextSceneName + "does not exists");
                return;
            }
            ProgressLoad(nextSceneName);
        }
        public static void LoadAddictive(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

        public static void UnloadAddictive(string scene)
        {
            SceneManager.UnloadSceneAsync(scene);
        }
    }
}
