using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Respawn : MonoBehaviour {

    HeadlineManager hm;

    private void Start()
    {
        hm = GameObject.Find("HeadlineManager").GetComponent<HeadlineManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            other.gameObject.GetComponent<NPC_Position>().Send2Spawn();
            hm.EarnHeadline("Banished to the Depths");
        }
    }
}
