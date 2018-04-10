using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewspaperOn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("TurnOn");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TurnOn()
    {
        for (int i = 0; i < Mathf.Infinity; i++)
        {
            this.gameObject.SetActive(true);
            yield return new WaitForSeconds(7.5f);
        }
    }
}
