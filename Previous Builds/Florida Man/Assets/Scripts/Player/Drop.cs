using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drop : MonoBehaviour {

    //Audio
    private AudioSource audioSource;
    public AudioClip dropSound;
    //Animator
    private Animator anim;
    Pickup p;
    //UI
    public GameObject LBButton;
    public Text LBButtonTxt;
    //Start Menu Controller Support
    Movement m;
    HeadlineManager hm;
    //End Menu Controller Support

    // Use this for initialization
    void Start () {
        hm = GameObject.Find("HeadlineManager").GetComponent<HeadlineManager>();
        //Start Menu Controller Support
        m = this.GetComponent<Movement>();
        //End Menu Controller Support
        LBButton.SetActive(false);
        p = this.GetComponent<Pickup>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //Start Menu Controller Support (noMove) 
        if (m.noMove == false)
        {
            if (Input.GetButtonDown("LB") && p.holding == true)
            {
                p.pickup.transform.parent = null;
                p.pickup.layer = 0; //place the opject on the default layer
                audioSource.PlayOneShot(dropSound, 0.7f);
                anim.SetBool("Holding", false);

                if(p.pickup.name == "Perfume")
                {
                    hm.EarnHeadline("Pink Salmon");
                }
            }

            if (p.holding == true)
            {
                LBButton.SetActive(true);
            }
            else
            {
                LBButton.SetActive(false);
            }
        }
        //End Menu Controller Support
    }

    void LateUpdate()
    {
        //Start Menu Controller Support
        if (m.noMove == false)
        {
            if (Input.GetButtonDown("LB"))
            {
                try
                {
                    p.pickup.GetComponent<Rigidbody>().useGravity = true;
                    p.pickup.GetComponent<Rigidbody>().isKinematic = false;
                    p.holding = false;
                }
                catch
                {

                }
            }
        }
        //End Menu Controller Support
    }
}
