using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour {

    //Audio
    public AudioSource audioSource;
    public AudioClip StepSound;

    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Walking", 0.1f, 0.4f);
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void Walking()
    {
        var G = GameObject.FindWithTag("Player").GetComponent<Movement>();
        if (G.walking)
        {
            if (G.grounded == true)
            {
                audioSource.pitch = Random.Range(0.4f, 1.0f);
                audioSource.PlayOneShot(StepSound, 0.7f);
            }
        }
    }
}
