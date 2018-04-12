using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private float timer;
    public Text myTextbox;
    private string minutes;
    private string seconds;
    private string ms;
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        minutes = Mathf.Floor(timer / 60).ToString("00");
        seconds = Mathf.Floor(timer % 60).ToString("00");
        ms = ((timer * 100) % 100).ToString("00");
        myTextbox.text = minutes + ":" + seconds + "." + ms;
    }
}