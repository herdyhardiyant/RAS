using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneLoadManager : MonoBehaviour
{
    public static void Load(string sceneName)
    {
        SceneLoad.Load(sceneName);
    }

    public static void ProgressLoad(string sceneName)
    {
        SceneLoad.ProgressLoad(sceneName);
    }

    // public static void LoadNextLevel()
    // {
    //     SceneLoad.LoadNextLevel();
    // }

    public static void ReloadLevel()
    {
        SceneLoad.ReloadLevel();
    }
}