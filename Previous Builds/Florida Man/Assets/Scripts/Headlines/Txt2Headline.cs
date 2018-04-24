using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Txt2Headline : MonoBehaviour
{
    private const int NUM_HEADLINES = 41;

    #region Fields
    private Headline myHeadline;
    public TextAsset TextFile;
    private string lines;
    private static string[] category;
    private static string[] title;
    private static string[] hint;
    private static string[] description;
    HeadlineManager H;
    #endregion

    #region Start
    private void Start()
    {
        
    }
    #endregion

    #region ReadFile
    //[MenuItem("Tools/Read file")]
    public static void ReadFile(Dictionary<string, Headline> headlines, GameObject headlinePrefab)
    {
        string path = Application.dataPath;
        path = path + "/Resources/Headlines.txt";

        StreamReader reader = new StreamReader(path);
        int i = 0;

        string[] category = new string[NUM_HEADLINES];
        string[] title = new string[NUM_HEADLINES];
        string[] hint = new string[NUM_HEADLINES];
        string[] description = new string[NUM_HEADLINES];

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] SplitInput = line.Split(new string[] { "; " }, StringSplitOptions.None);

            try
            {
                category[i] = SplitInput[0];
                title[i] = SplitInput[1];
                hint[i] = SplitInput[2];
                description[i] = SplitInput[3];
            }
            catch
            {
                //Do Nothing
            }

            i++;
        }

        for (int b = 0; b < NUM_HEADLINES; b++)
        {
            CreateHeadline(headlines, headlinePrefab, category[b], title[b], hint[b], description[b]);
            //Want to print all of the headlines to the console? :
            /*Debug.Log("Category:" + category[b]);
            Debug.Log("Title:" + title[b]);
            Debug.Log("Hint:" + hint[b]);
            Debug.Log("Description:" + description[b]);*/
        }

        reader.Close();
    }
    #endregion

    public static void CreateHeadline(Dictionary<string, Headline> headlines, GameObject headlinePrefab, string parent, string title, string hint, string description)
    {
        GameObject headline = (GameObject)Instantiate(headlinePrefab);
        // Add headline to dictionary
        Headline newHeadline = new Headline(title, hint, description, headline);
        headlines.Add(title, newHeadline);

        headline.transform.SetParent(GameObject.Find(parent).transform);
        headline.transform.localScale = new Vector3(1, 1, 1);
        headline.transform.GetChild(1).GetComponent<Text>().text = "Hint: " + title;
        //headline.transform.GetChild(2).GetComponent<Text>().text = headlines[title].Description;
    }
}