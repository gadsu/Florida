using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Canvas pauseMenu;
    public Text timer;
    HeadlineManager hm;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        hm = GameObject.Find("HeadlineManager").GetComponent<HeadlineManager>();
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

        if (Input.GetButtonDown("Jump") && hm.headlines["The Nuclear Option"].Unlocked)
        {
            MainMenu();
        }
	}

    public void Pause()
    {
        if (!hm.headlines["The Nuclear Option"].Unlocked)
        {
            if (pauseMenu.gameObject.activeInHierarchy == false)
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

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
