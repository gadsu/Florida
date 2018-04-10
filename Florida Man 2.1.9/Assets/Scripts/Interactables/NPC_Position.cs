using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Position : MonoBehaviour {

    private Vector3 npcSpawn;

    // Use this for initialization
    void Start()
    {
        npcSpawn = this.transform.position;
    }

    public void Send2Spawn()
    {
        this.transform.position = npcSpawn;
    }
}
