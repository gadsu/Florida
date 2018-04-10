using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadlineDisappear : MonoBehaviour {

    public GameObject newspaper;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine("Fade");
	}

    IEnumerator Fade()
    {
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Color c = newspaper.GetComponent<Image>().color;
            c.a = f;
            newspaper.GetComponent<Image>().color = c;
            yield return null;
        }
    }
}
