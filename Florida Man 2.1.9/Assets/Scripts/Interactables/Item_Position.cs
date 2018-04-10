using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Position : MonoBehaviour {

    private Vector3 itemSpawn;

    // Use this for initialization
    void Start()
    {
        itemSpawn = this.transform.position;
    }
	
	public void Send2Spawn()
    {
        this.transform.position = itemSpawn;
    }
}
