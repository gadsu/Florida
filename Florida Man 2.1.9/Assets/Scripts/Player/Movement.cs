using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour {

    //Movement
    private float h;
    private float v;
    private Vector3 tempPos1;
    private Vector3 tempPos2;
    private Vector3 tempPosFinal;
    private float multiplier = 3.0f;
    private Vector3 movement;
    public GameObject myCamera;
    public bool walking = false;
    //GameObject target;
    public GameObject player;
    private Animator anim;
    private Rigidbody rbody;
    //Jumping
    private float jumpPower = 7.0f;
    private int jumpCount = 0;
    public bool grounded;
    private bool canJump = true;
    public Text jumpTxt;
    private Color jumpColor;
    // Looking
    public Text lookTxt;
    private Color lookColor;
    // Moving
    public Text moveTxt;
    private Color moveColor;

    //Start Menu Controller Support
    public bool noMove;
    public GameObject HeadlineMenu;
    //End Menu Controller Support

    //Raycasting
    private RaycastHit vision; // Used for detecting Raycast collision
    private float rayLength; // Used for assigning a length to the raycast
    //End Raycasting

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        grounded = true;

        // UI
        lookColor = lookTxt.color;
        moveColor = moveTxt.color;
        jumpColor = jumpTxt.color;

        rayLength = 0.6f;
    }

    private void Awake()
    {
        rbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //Start Menu Controller Support
        if (noMove == false)
        {
            Move(h, v);
        }
        //End Menu Controller Support

        //This statement is called when the Raycast is hitting a collider in the scene
        if (Physics.Raycast(transform.position - new Vector3(0, -0.1f, 0), transform.TransformDirection(Vector3.down), out vision, rayLength))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        //Start Menu Controller Support
        if (!HeadlineMenu.activeSelf)
        {
            noMove = false;
        }
        else
        {
            noMove = true;
            EventSystem.current.SetSelectedGameObject(GameObject.Find("Scrollbar"));
        }

        if (noMove == false)
        {
        //End Menu Controller Support

            //Raycasting
            //This will constantly draw the ray in our Scene view so we can see where the ray is going
            Debug.DrawRay(transform.position - new Vector3(0, -0.1f, 0), Vector3.down * rayLength, Color.red, 0.5f);

            if (grounded == true)
            {
                jumpCount = 0;
                canJump = true;
            }

            if (grounded == false && jumpCount < 2)
            {
                canJump = true;
                jumpCount = jumpCount + 1;
            }

            // Double jump
            if (Input.GetButtonDown("Jump"))
            {
                jumpTxt.color = Color.green;
                if (jumpCount > 2)
                {
                    canJump = false;
                }

                if (canJump == true)
                {
                    rbody.velocity = new Vector3(0, 0, 0);
                    rbody.AddForce(0, jumpPower, 0, ForceMode.Impulse);
                    jumpCount = jumpCount + 1;
                }
            }
            else
            {
                jumpTxt.color = jumpColor;
            }

            // Grounded
            if (grounded == true)
            {
                anim.SetBool("Grounded", true);
            }
            else
            {
                anim.SetBool("Grounded", false);
            }

            // Falling
            if (rbody.velocity.y < -0.2)
            {
                anim.SetBool("Falling", true);
            }
            else
            {
                anim.SetBool("Falling", false);
            }

            if (h != 0 || v != 0)
            {
                walking = true;
                anim.SetBool("IsIdle", false);
                moveTxt.color = Color.green;
            }
            else
            {
                walking = false;
                anim.SetBool("IsIdle", true);
                moveTxt.color = moveColor;
            }

            if (Input.GetAxis("Right X") != 0)
            {
                lookTxt.color = Color.green;
            }
            else
            {
                lookTxt.color = lookColor;
            }
        //Start Menu Controller Support
        }
        //End Menu Controller Support
    }

    void Move(float h, float v)
    {
        tempPos1.x = -(myCamera.transform.position.x - this.transform.position.x) * multiplier * v;
        tempPos1.z = -(myCamera.transform.position.z - this.transform.position.z) * multiplier * v;
        tempPos2.x = ((myCamera.transform.position.z - this.transform.position.z) * multiplier * h);
        tempPos2.z = (-(myCamera.transform.position.x - this.transform.position.x) * multiplier * h);

        tempPosFinal.x = this.transform.position.x + (tempPos1.x - tempPos2.x);
        tempPosFinal.y = this.transform.position.y;
        tempPosFinal.z = this.transform.position.z + (tempPos1.z - tempPos2.z);

        Vector3 velocityFinal = new Vector3(0,0,0);
        velocityFinal.x = (tempPos1.x - tempPos2.x);
        velocityFinal.y = rbody.velocity.y;
        velocityFinal.z = (tempPos1.z - tempPos2.z);

        rbody.velocity = velocityFinal;

        transform.LookAt(tempPosFinal);
    }
}
