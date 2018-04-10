using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    //Audio
    private AudioSource audioSource;
    public AudioClip pickupSound;
    //Animator
    private Animator anim;
    //Picking Up
    //private bool pickupable;
    //Holding
    public GameObject hold_joint;
    public bool holding;
    //Equipped
    public GameObject equipped;
    public Text equippedTxt;
    //Items
    public Vector3 itemScale;
    public Quaternion itemRotation;
    public Vector3 itemSpawn;
    //UI
    public GameObject YButton;
    //Misc.
    Renderer rend;
    public Material[] material;
    public GameObject pickup;
    public GameObject iSeeYou;
    public Vector3 pickupScale;
    public Quaternion pickupRotation;
    public Vector3 pickupSpawn;
    public GameObject[] itemsArray;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        holding = false;
        //pickupable = false;
        YButton.SetActive(false);
        itemsArray = GameObject.FindGameObjectsWithTag("Pickup");
        equipped.SetActive(false);

        foreach(GameObject i in itemsArray)
        {
            i.GetComponent<Rigidbody>().useGravity = true;
            i.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void Update()
    {
        if (holding == true)
        {
            anim.SetBool("Holding", true);
            equippedTxt.text = pickup.name;
            equipped.SetActive(true);
        }
        else
        {
            anim.SetBool("Holding", false);
        }
    }

    GameObject GetClosestItem(GameObject[] items)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialItem in items)
        {
            Vector3 directionToTarget = potentialItem.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialItem;
            }
        }
        return bestTarget.gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Pickup")
        {
            //Renderer information
            rend = other.GetComponentInChildren<Renderer>();
            rend.material.shader = Shader.Find("Standard");

            //Replace Default Renderer Material with Outline Material
            rend.sharedMaterial = material[1];
            //Add Item name to equipped text and set it active
            equipped.SetActive(true);

            if (holding == false)
            {
                pickup = GetClosestItem(itemsArray);
                equippedTxt.text = pickup.name;
                YButton.SetActive(true);

                if (Input.GetButtonDown("Pickup"))
                {
                    YButton.SetActive(false);

                    pickup.GetComponent<Rigidbody>().useGravity = false;
                    pickup.GetComponent<Rigidbody>().isKinematic = true;

                    //Set Renderer Material to the default material
                    rend.sharedMaterial = material[0];

                    //Item information
                    pickupScale = pickup.gameObject.transform.lossyScale;
                    pickupRotation = pickup.gameObject.transform.localRotation;
                    pickupSpawn = pickup.gameObject.transform.position;

                    //Set holding to true now that you are holding an item
                    holding = true;

                    //Close Florida Mans' hand
                    anim.SetTrigger("Pickup");

                    //Play pickup sound
                    audioSource.PlayOneShot(pickupSound, 0.7f);

                    //Change the layer of the item to avoid colliding with Florida Man
                    pickup.layer = 11;

                    //Child the item to Florida Mans' holding joint and set its position
                    pickup.transform.parent = hold_joint.transform;
                    pickup.transform.position = hold_joint.transform.position;

                    //Zero out the items' local position in the holding joint
                    pickup.transform.localPosition = Vector3.zero;
                    pickup.transform.localRotation = Quaternion.Euler(0, 0, -90);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pickup")
        {
            other.GetComponentInChildren<Renderer>().sharedMaterial = material[0];
            //pickup.GetComponent<Rigidbody>().useGravity = true;
            //pickup.GetComponent<Rigidbody>().isKinematic = false;
        }

        equipped.SetActive(false);
        YButton.SetActive(false);
    }
}