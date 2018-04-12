using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Respawn : MonoBehaviour {

    GameObject player;
    Pickup p;
    //Item_Position ip;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        p = player.GetComponent<Pickup>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pickup" && p.pickup.name != other.gameObject.name)
        {
            other.gameObject.GetComponent<Item_Position>().Send2Spawn();
        }
        
        if (other.tag == "Bookshelf")
        {
            other.gameObject.GetComponent<Item_Position>().Send2Spawn();
        }
    }
}
