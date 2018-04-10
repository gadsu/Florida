using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWall : MonoBehaviour {

    private MeshRenderer msh;

    private void Start()
    {
        msh = transform.GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        msh.enabled = true;
    }
}
