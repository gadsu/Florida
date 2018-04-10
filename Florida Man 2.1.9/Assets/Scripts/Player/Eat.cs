using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour {

    //Audio
    private AudioSource audioSource;
    public AudioClip eatSound;
    //Animator
    private Animator anim;
    //Eat
    private bool yummy = false;
    private int countDown = 80;
    //UI
    public GameObject BButton;
    public Text BButtonTxt;
    //private Color BColor;
    Pickup p;

    // Use this for initialization
    void Start () {
        BButton.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        p = GetComponent<Pickup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(4).normalizedTime > 1 && !anim.IsInTransition(4))
        {
            if (Input.GetButtonDown("B") && p.holding == true)
            {
                anim.SetTrigger("Eat");
                audioSource.PlayOneShot(eatSound, 0.7F);
                yummy = true;
            }
        }
        if (yummy == true)
        {
            p.pickup.transform.localScale = Vector3.Lerp(p.pickup.transform.localScale, Vector3.zero, 2 * Time.deltaTime);
            countDown -= 2;
        }

        if (countDown == 0)
        {
            yummy = false;
            p.pickup.transform.parent = null;
            p.pickup.layer = 0;
            p.pickup.gameObject.transform.position = p.pickupSpawn;
            p.pickup.gameObject.transform.localScale = p.pickupScale;
            p.pickup.gameObject.transform.localRotation = p.pickupRotation;
            p.pickup.GetComponent<Rigidbody>().useGravity = true;
            p.pickup.GetComponent<Rigidbody>().isKinematic = false;
            p.holding = false;
            yummy = false;
            countDown = 80;
        }

        if (p.holding == true)
        {
            BButton.SetActive(true);
        }
        else
        {
            BButton.SetActive(false);
        }
    }
}
