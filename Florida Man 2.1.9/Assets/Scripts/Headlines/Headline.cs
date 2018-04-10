using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Headline
{
    private string name;
    private GameObject headlineRef;
    private bool unlocked;
    private string description;
    private string hint;
    //HeadlineManager hm;

    private void Start()
    {
        //hm = GameObject.Find("HeadlineManager").GetComponent<HeadlineManager>();
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public string Hint
    {
        get { return hint; }
        set { hint = value; }
    }

    public bool Unlocked
    {
        get { return unlocked; }
        set { unlocked = value; }
    }

    public Headline(string name, string hint, string description, GameObject headlineRef)
    {
        this.Name = name;
        this.Hint = hint;
        this.description = description;
        this.unlocked = false;
        this.headlineRef = headlineRef;
    }

    public bool EarnHeadline()
    {
        if (!unlocked)
        {
            //headlineRef.GetComponent<Image>().sprite = HeadlineManager.Instance.unlockedSprite;
            //headline.transform.GetChild(2).GetComponent<Text>().text = headlines[title].Description;
            headlineRef.transform.GetChild(1).GetComponent<Text>().text = "" + this.hint;
            if (this.description.Length > 30)
            {
                try
                {
                    string myStr = this.description;
                    string[] arr = myStr.Split('^');
                    headlineRef.transform.GetChild(2).GetComponent<Text>().text = "" + arr[0] + arr[1];
                }
                catch
                {
                    Debug.Log("This headline does not have a splitting character for the pop up headline: " + headlineRef.transform.GetChild(1).GetComponent<Text>().text);
                }
            }
            //headlineRef.transform.GetChild(2).GetComponent<Text>().text = "" + this.description;
            headlineRef.transform.GetChild(3).GetComponent<Text>().text = "Complete";
            unlocked = true;
            return true;
        }
        return false;
    }
}
