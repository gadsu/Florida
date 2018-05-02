using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    //Audio
    private AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip bellSound;
    public AudioClip organSound;
    public AudioClip missileSound;
    //Animator
    public Animator anim;
    public Animator dome_anim;
    //Raycasting
    //private GameObject currentHitObject;
    private float sphereRadius = 0.3f;
    private float maxDistance = 1f;
    private LayerMask layerMask;
    //private Vector3 origin;
    //private Vector3 direction;
    private float currentHitDistance;
    private RaycastHit hit;
    private float forceModifier;
    //UI
    public GameObject XButton;
    public Text XButtonTxt;
    private Color XColor;
    //Super Burp
    Burp b;
    HeadlineManager hm;
    Rigidbody brb;
    Rigidbody globe;
    //private float _superBurpForce;

    public GameObject missile;
    public GameObject secret;
    public GameObject errorDisplay;

    // Use this for initialization
    void Start()
    {
        brb = GameObject.Find("Bell").GetComponent<Rigidbody>();
        globe = GameObject.Find("Globe").GetComponent<Rigidbody>();
        hm = GameObject.Find("HeadlineManager").GetComponent<HeadlineManager>();
        audioSource = GetComponent<AudioSource>();
        anim = this.GetComponent<Animator>();
        XColor = XButtonTxt.color;
        forceModifier = 350.0f;

        b = this.GetComponent<Burp>();
        //_superBurpForce = 9000.1f;
        missile.SetActive(false);
        errorDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Raycasting
        //origin = this.transform.position;
        
        //direction = transform.forward;

        if (Input.GetButtonDown("Hit"))
        {
            anim.SetTrigger("Hit");
        }

        if (Input.GetButton("Hit"))
        {
            XButtonTxt.color = Color.green;
        }
        else
        {
            XButtonTxt.color = XColor;
        }

        if (brb.position.y <= -25)
        {
            brb.gameObject.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(this.transform.position, this.transform.position + new Vector3(0, 0.7f, 0) + transform.forward, Color.blue);
        Gizmos.DrawWireSphere(this.transform.position + new Vector3(0, 0.7f, 0) + transform.forward, sphereRadius);
    }

    private void FixedUpdate()
    {
        var p = GetComponent<Pickup>();

        if (Input.GetButtonDown("Hit"))
        {
            //Raycasting
            if (Physics.SphereCast(this.transform.position + new Vector3(0, 0.7f, 0), sphereRadius, transform.forward, out hit, maxDistance))
            {
                //Debug.Log("You can hit: " + hit.transform.gameObject);
                if (!anim.GetCurrentAnimatorStateInfo(2).IsName("Hit") && hit.collider.tag != "Organ")
                {
                    audioSource.PlayOneShot(hitSound, 0.3f);
                }

                if(hit.collider.tag == "Escalator" && hm.Location == "department store")
                {
                    hm.EarnHeadline("Escalated Vandalism");
                }

                if (hit.collider.tag == "PerfumeDisplay" && hm.Location == "department store")
                {
                    hm.EarnHeadline("Olfactory Overload");
                }

                if (p.holding == true)
                {
                    if (hit.collider.tag == "NPC" && hm.Location == "library" && hm.p.pickup.name == "Book" && hm.p.holding == true)
                    {
                        hm.EarnHeadline("READ!");
                    }

                    if (hit.collider.tag == "NPC" && hm.p.pickup.name == "Communion Wine" && hm.p.holding == true)
                    {
                        hm.EarnHeadline("Wine Assault");
                    }

                    if (hit.collider.tag == "NPC" && hm.Location == "department store" && hm.p.pickup.name == "Perfume" && hm.p.holding == true)
                    {
                        hm.EarnHeadline("Pretty in Pink");
                    }
                }

                if (hit.collider.tag == "NPC")
                {
                    hit.rigidbody.AddForce(transform.forward * forceModifier);
                }

                if (hit.collider.tag == "Bookshelf")
                {
                    hm.EarnHeadline("Hit the Books");
                }

                if (hit.collider.tag == "Computer")
                {
                    hm.EarnHeadline("Hit any Key to Continue");
                }

                if (hit.collider.tag == "Globe")
                {
                    globe.constraints &= ~RigidbodyConstraints.FreezePositionY;
                    hm.EarnHeadline("Weight of the World");
                }

                if (hit.collider.tag == "Secret")
                {
                    hm.EarnHeadline("Secret Entrance");
                    secret.SetActive(false);
                }
                
                if (hit.collider.tag == "ControlPanel")
                {
                    if (hm.headlines["Weight of the World"].Unlocked)
                    {
                        dome_anim.SetTrigger("Open");
                        missile.SetActive(true);
                        hm.EarnHeadline("Big Red Button");
                        StartCoroutine("Wait2");
                    }
                    else
                    {
                        errorDisplay.SetActive(true);
                        StartCoroutine("Wait");
                    }
                }
                
                if (hit.collider.tag == "Bell")
                {
                    brb.GetComponentInChildren<MeshCollider>().convex = true;
                    brb.isKinematic = false;
                    brb.useGravity = true;
                    hit.rigidbody.AddForce(transform.forward * 280f);
                    hm.EarnHeadline("Bells of Fury");
                    hit.collider.GetComponent<AudioSource>().PlayOneShot(bellSound, 0.3f);
                }

                if (hit.collider.tag == "Organ" && !anim.GetCurrentAnimatorStateInfo(2).IsName("Hit"))
                {
                    hm.EarnHeadline("Angry Organist");
                    hit.collider.GetComponent<AudioSource>().PlayOneShot(organSound, 0.3f);
                }
            }
            else
            {
                //currentHitDistance = maxDistance;
            }
        }

        if (!anim.GetCurrentAnimatorStateInfo(1).IsName("Burp"))
        {
            if (Input.GetAxisRaw("RT") != 0)
            {
                if (b._AxisInUse == false)
                {
                    //Raycasting  + new Vector3(0, 0.7f, 0)
                    if (Physics.SphereCast(this.transform.position, sphereRadius, transform.forward, out hit, maxDistance))
                    {
                        //Debug.Log("You can super burp on: " + hit.transform.gameObject);
                        if (hit.collider.tag == "NPC")
                        {
                            hit.rigidbody.AddForce(transform.forward * forceModifier);
                        }

                        //Debug.Log("Equipped: " + p.equippedTxt.text);

                        if (hit.collider.tag == "PerfumeDisplay" && hm.Location == "department store")
                        {
                            hm.EarnHeadline("Original Scent");
                        }
                    }
                }
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        errorDisplay.SetActive(false);
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(2);
        missile.GetComponent<AudioSource>().PlayOneShot(missileSound, 1.5f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!anim.GetCurrentAnimatorStateInfo(1).IsName("Burp"))
        {
            if (Input.GetAxisRaw("RT") != 0)
            {
                if (b._AxisInUse == false)
                {
                    if (other.tag == "PerfumeDisplay")
                    {
                        hm.EarnHeadline("Original Scent");
                    }
                }
            }
        }
    }
}
