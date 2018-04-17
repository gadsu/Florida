using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Canvas pauseMenu;
    public Text timer;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start"))
        {
            Pause();
        }

        if (pauseMenu.gameObject.activeInHierarchy == true && Input.GetButtonDown("Exit"))
        {
            SceneManager.LoadScene("MainMenu");
        }
	}

    public void Pause()
    {
        if(pauseMenu.gameObject.activeInHierarchy == false)
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ToggleTimer()
    {
        if (timer.color.a == 0)
        {
            timer.color = Color.white;
        }
        else
        {
            timer.color = Color.clear;
        }
    }
}
