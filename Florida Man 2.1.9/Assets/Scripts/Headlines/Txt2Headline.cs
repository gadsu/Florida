using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Txt2Headline : MonoBehaviour
{
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
        string path = "Assets/Resources/Headlines.txt";
        //TextAsset path = (TextAsset)Resources.Load("Headlines.txt") as TextAsset;
        //TextAsset textFile = (TextAsset)Resources.Load("Headlines.txt") as TextAsset;
        //string path = textFile.text;
        //string file = path.text;
        StreamReader reader = new StreamReader(path);
        int i = 0;

        string[] category = new string[37];
        string[] title = new string[37];
        string[] hint = new string[37];
        string[] description = new string[37];

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

        for (int b = 0; b < 37; b++)
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