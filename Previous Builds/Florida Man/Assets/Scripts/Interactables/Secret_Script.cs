using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret_Script : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y >= 25.0f)
        {
            this.gameObject.SetActive(false);
        }
    }
}
