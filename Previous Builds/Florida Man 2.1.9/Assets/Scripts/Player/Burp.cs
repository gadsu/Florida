using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Burp : MonoBehaviour {

    //Audio
    private AudioSource audioSource;
    public AudioClip burpSound;
    //Animator
    private Animator anim;
    //UI
    private GameObject RTButton;
    public Text RTButtonTxt;
    private Color RTColor;
    //Misc.
    private bool AxisInUse;
    public bool _AxisInUse
    {
        get { return AxisInUse; }
        set { AxisInUse = value; }
    }

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        RTColor = RTButtonTxt.color;
    }
	
	// Update is called once per frame
	void Update () {
        if (!anim.GetCurrentAnimatorStateInfo(1).IsName("Burp"))
        {
            if (Input.GetAxisRaw("RT") != 0)
            {
                if (AxisInUse == false)
                {
                    anim.SetTrigger("Burp");
                    audioSource.PlayOneShot(burpSound, 0.1F);
                    AxisInUse = true;
                }
            }
        }
        if (Input.GetAxisRaw("RT") == 0)
        {
            AxisInUse = false;
        }

        if (AxisInUse == true)
        {
            RTButtonTxt.color = Color.green;
        }
        else
        {
            RTButtonTxt.color = RTColor;
        }
    }
}
