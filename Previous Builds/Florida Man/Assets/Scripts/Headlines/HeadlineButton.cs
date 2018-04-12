using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadlineButton : MonoBehaviour {

    public GameObject headlineList;
    HeadlineManager H;

    private void Start()
    {
        H = GameObject.Find("HeadlineManager").GetComponent<HeadlineManager>();
    }

    public void Click()
    {
        if (H.activeButton.gameObject != gameObject)
        {
            headlineList.SetActive(true);
            H.ChangeCategory(gameObject);
            gameObject.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Button>().image.color = gameObject.GetComponent<Button>().colors.highlightedColor;
        }
        else
        {
            gameObject.GetComponent<Button>().image.color = gameObject.GetComponent<Button>().colors.normalColor;
            gameObject.GetComponent<Button>().enabled = true;
            headlineList.SetActive(false);
        }
    }
}
