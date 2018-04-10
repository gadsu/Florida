using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {

    // Florida Man's current respawn location
    public Vector3 FloridaRespawn;

    // Checkpoints
    private GameObject CheckpointChurch;
    public GameObject SpawnChurch;
    private GameObject CheckpointStore;
    public GameObject SpawnStore;
    private GameObject CheckpointLibrary;
    public GameObject SpawnLibrary;
    private GameObject CheckpointMain;

    // Use this for initialization
    void Start () {
        // Spawn points
        SpawnChurch = GameObject.Find("SpawnChurch");
        SpawnStore = GameObject.Find("SpawnStore");
        SpawnLibrary = GameObject.Find("SpawnLibrary");
        CheckpointMain = GameObject.Find("CheckpointMain");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "CheckpointChurch")
        {
            FloridaRespawn = SpawnChurch.transform.position;
        }

        if (other.name == "CheckpointStore")
        {
            FloridaRespawn = SpawnStore.transform.position;
        }

        if (other.name == "CheckpointLibrary")
        {
            FloridaRespawn = SpawnLibrary.transform.position;
        }

        if (other.name == "CheckpointMain")
        {
            FloridaRespawn = CheckpointMain.transform.position;
        }
    }

    // Update is called once per frame
    void Update () {
        this.transform.position = transform.position;
        if (this.transform.position.y < -20f)
        {
            this.transform.position = new Vector3(FloridaRespawn.x, FloridaRespawn.y, FloridaRespawn.z);
        }
    }
}
