using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreenSwitch : MonoBehaviour
{
    public Camera cam1, cam2;
    public GameObject player2;
    private bool toggleSplit = false;
    private void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                toggleSplit = !toggleSplit;
                SetSplitScreen();
            }
        }
        void SetSplitScreen()
        {
            if (toggleSplit)
            {
                //kalo false jadi multiplayer
                cam2.enabled = true;
                cam1.rect = new Rect(0f, 0f, .5f, 1f);
                cam2.rect = new Rect(.5f, 0f, .5f, 1f);
                player2.SetActive(true);
            }
            else
            {
                //kalo false jadi singleplayer
                cam1.rect = new Rect(0f, 0f, 1f, 1f);
                cam2.enabled = false;
                player2.SetActive(false);
            }
        }
    }
}
