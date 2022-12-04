using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RAS
{
    public class BackToMenu : MonoBehaviour
    {
        // [SerializeField] private Animator creditScene;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)){
                UnloadAddictive("Credit");
            }

            // if (creditScene == )
            // {
            //     UnloadAddictive("Credit");
            // }
        }
        public static void UnloadAddictive(string sceneName){
            SceneLoader.UnloadAddictive(sceneName);
        }

        
    }
}
