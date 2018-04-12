using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUI : MonoBehaviour {

    public GameObject headlineMenu;
    public GameObject LBButton;
    public GameObject RTButton;
    public GameObject YButton;
    public GameObject XButton;
    public GameObject AButton;
    public GameObject BButton;
    public GameObject equipped;
    public GameObject Look;
    public GameObject Move;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (headlineMenu.activeSelf)
        {
            LBButton.SetActive(false);
            RTButton.SetActive(false);
            YButton.SetActive(false);
            XButton.SetActive(false);
            BButton.SetActive(false);
            AButton.SetActive(false);
            equipped.SetActive(false);
            Look.SetActive(false);
            Move.SetActive(false);
        }
        else
        {
            RTButton.SetActive(true);
            XButton.SetActive(true);
            AButton.SetActive(true);
            Look.SetActive(true);
            Move.SetActive(true);
        }
    }
}
