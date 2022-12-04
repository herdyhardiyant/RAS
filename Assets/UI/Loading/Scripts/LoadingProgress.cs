using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingProgress : MonoBehaviour
{
    [SerializeField] Image LoadingBarfill;
        

        private void Start()
        {
            StartCoroutine(LoadSceneAsync());
        }

        IEnumerator LoadSceneAsync()
        {
            LoadingBarfill.fillAmount = 0;
            yield return new WaitForSeconds(1);

            var AsyncOperation = SceneManager.LoadSceneAsync(SceneLoad.SceneToLoad);

            while (AsyncOperation.isDone == false)
            {
                LoadingBarfill.fillAmount = AsyncOperation.progress;
                yield return null;
            }
        } 
}
