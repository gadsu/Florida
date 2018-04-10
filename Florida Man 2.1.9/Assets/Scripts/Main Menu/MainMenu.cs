using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            SceneManager.LoadScene("Testing Area");
        }

        if (Input.GetButtonDown("Exit"))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
    }
}
