using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewspaperOff : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine("TurnOff");
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine("TurnOff");
    }

    IEnumerator TurnOff()
    {
        for (int i = 0; i < Mathf.Infinity; i++)
        {
            yield return new WaitForSeconds(7.5f);
            this.gameObject.SetActive(false);
        }
    }
}
