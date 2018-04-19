using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HeadlineManager : MonoBehaviour {

    public GameObject headlinePrefab;
    public GameObject visualHeadline;
    public HeadlineButton activeButton;
    public HeadlineButton headlineButton;
    public ScrollRect scrollRect;
    public GameObject headlineMenu;
    public GameObject scrollObject;
    public GameObject player;
    public Pickup p;
    public PlayerRespawn r;
    public Movement m;

    //Start Menu Controller Support
    private int category = 0;
    //private HeadlineButton btnOther;
    private HeadlineButton btnGeneral;
    private HeadlineButton btnChurch;
    private HeadlineButton btnLibrary;
    private HeadlineButton btnStore;
    private bool changed;
    HeadlineButton L;
    Hit H;
    //End Menu Controller Support

    //Start Headline Queue
    Queue<IEnumerator> headlineQueue = new Queue<IEnumerator>();
    //End Headline Queue

    //Access an object without an instance of an object
    private static HeadlineManager instance;
    public static HeadlineManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<HeadlineManager>();
            }
            return HeadlineManager.instance;
        }
    }
    
    public Dictionary<string, Headline> headlines = new Dictionary<string, Headline>();

    string heldItem;
    string location;

    public string Location
    {
        get { return location; }
        set { location = value; }
    }

    //Jump Counter
    int JC = 0;

    // Use this for initialization
    void Start()
    {
        H = GameObject.Find("Florida Man").GetComponent<Hit>();
        StartCoroutine(Process());
        activeButton = GameObject.Find("BtnGeneral").GetComponent<HeadlineButton>();
        //Start Menu Controller Support
        btnGeneral = GameObject.Find("BtnGeneral").GetComponent<HeadlineButton>();
        btnChurch = GameObject.Find("BtnChurch").GetComponent<HeadlineButton>();
        btnLibrary = GameObject.Find("BtnLibrary").GetComponent<HeadlineButton>();
        btnStore = GameObject.Find("BtnStore").GetComponent<HeadlineButton>();
        GameObject.Find("BtnChurch").gameObject.GetComponent<Button>().image.color = GameObject.Find("BtnChurch").gameObject.GetComponent<Button>().colors.normalColor;
        GameObject.Find("BtnLibrary").gameObject.GetComponent<Button>().image.color = GameObject.Find("BtnLibrary").gameObject.GetComponent<Button>().colors.normalColor;
        GameObject.Find("BtnStore").gameObject.GetComponent<Button>().image.color = GameObject.Find("BtnStore").gameObject.GetComponent<Button>().colors.normalColor;
        //End Menu Controller Support

        Txt2Headline.ReadFile(headlines, headlinePrefab);

        foreach (GameObject headlineList in GameObject.FindGameObjectsWithTag("HeadlineList"))
        {
            headlineList.SetActive(false);
        }

        activeButton.headlineList.SetActive(true);

        headlineMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Start Menu Controller Support
        if (Input.GetButtonDown("RB"))
        {
            if (category < 3)
            {
                category++;
                changed = true;
            }
            else
            {
                changed = false;
            }
        }

        if (Input.GetButtonDown("LB") && m.noMove == true)
        {
            if (category > 0)
            {
                category--;
                changed = true;
            }
            else
            {
                changed = false;
            }
        }

        if (m.noMove == true)
        {
            if (Input.GetButtonDown("RB") ^ Input.GetButtonDown("LB"))
            {
                if (changed)
                {
                    switch (category)
                    {
                        case 0:
                            btnGeneral.Click();
                            break;
                        case 1:
                            btnChurch.Click();
                            break;
                        case 2:
                            btnStore.Click();
                            break;
                        case 3:
                            btnLibrary.Click();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        // End Menu Controller Support

        if (Input.GetKeyDown(KeyCode.I) || Input.GetButtonDown("Exit"))
        {
            headlineMenu.SetActive(!headlineMenu.activeSelf);
            activeButton.gameObject.GetComponent<Button>().enabled = false;
            activeButton.gameObject.GetComponent<Button>().image.color = activeButton.gameObject.GetComponent<Button>().colors.highlightedColor;
            Pause();
            //Controller Support for scrollbar
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(scrollObject, null);
        }
        
        try
        {
            heldItem = p.equippedTxt.text;
        } 
        catch
        {
            //Debug.Log("Florida Man is not holding an item.");
        }

        //Location Check
        try
        {
            if (r.FloridaRespawn == r.SpawnChurch.transform.position)
            {
                location = "church";
            }
            else if (r.FloridaRespawn == r.SpawnStore.transform.position)
            {
                location = "department store";
            }
            else if (r.FloridaRespawn == r.SpawnLibrary.transform.position)
            {
                location = "library";
            }
            else
            {
                location = "tutorial";
            }
        } catch
        {
            //Debug.Log("Respawn Point: " + location);
        }

        //HEADLINES
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            EarnHeadline("Fancy Feet");
        }

        if (Input.GetButtonDown("Hit"))
        {
            EarnHeadline("En Garde!");
        }

        if (Input.GetButtonDown("LB") && p.holding == true)
        {
            EarnHeadline("Litterer");
        }

        if (Input.GetButtonDown("B") && p.holding == true)
        {
            EarnHeadline("Bon Appetit");
        }

        /* to complex
        if (Input.GetButtonDown("LB") && location == "library" && heldItem == "Diamonds")
        {
            EarnHeadline("Silent Rejection");
        }*/

        if (Input.GetButtonDown("LB") && p.holding == true && location == "department store")
        {
            EarnHeadline("Money Back Guarantee");
        }

        /* Evidentally removed
        if (Input.GetButtonDown("LB") && p.holding == true && location == "church")
        {
            EarnHeadline("Generous Donor");
        }*/

        /*moved
        if (Input.GetButtonDown("Hit") && location == "library")
        {
            EarnHeadline("Hit any Key to Continue");
        }*/

        /*if (Input.GetButtonDown("Hit") && heldItem == "Book" && p.holding == true)
        {
            EarnHeadline("READ!");
        }*/

        if (Input.GetButtonDown("Hit") && location == "department store" && p.name == "Perfume")
        {
            EarnHeadline("Pretty in Pink");
        }

        /*
        if (Input.GetButtonDown("Hit") && location == "department store")
        {
            EarnHeadline("Escalated Vandalism");
        }*/

        /*if (Input.GetButtonDown("Hit") && location == "department store")
        {
            EarnHeadline("Olfactory Overload");
        }*/

        /* Removed
        if (Input.GetButtonDown("Hit") && heldItem == "Book" && p.holding == true)
        {
            EarnHeadline("Desire2Learn");
        }*/

        
        
        if (heldItem == "Magazine" && p.holding == true)
        {
            EarnHeadline("Grand Theft Magazine");
        }

        if (heldItem == "Cash Register" && p.holding == true)
        {
            EarnHeadline("Crime Doesn't Pay");
        }

        try
        {
            if (p.holding == true)
            {
                EarnHeadline("Mine!");
            }
        } catch
        {
            //Debug.Log("Holdsies is causing null reference exception");
        }
        
        //if (Input.GetAxis("RT") == 1 && location == library)
        //{
        //    EarnHeadline("Book Belcher");
        //}
        
        /* Updated and moved
         * if (location == "department store" && Input.GetAxis("RT") == 1)
        {
            EarnHeadline("Original Scent");
        }*/

        if (location == "church" && Input.GetAxis("RT") == 1)
        {
            EarnHeadline("Divine Interburption");
        }

        if (Input.GetAxis("RT") == 1)
        {
            EarnHeadline("Burp Man");
        }

        if (location == "church" || location == "department store" || location == "library")
        {
            EarnHeadline("Marco Polo");
        }

        if (player.transform.position.y < -19)
        {
            EarnHeadline("Don't Give Up");
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (m.grounded == false && JC == 2)
            {
                EarnHeadline("Know Your Limits");
                JC += 2;
            }
            if (m.grounded == true)
            {
                H.anim.SetTrigger("Jump");
                EarnHeadline("With Great Effort");
                JC++;
                if (JC <= 2)
                    JC = 1;
            }
            else if (m.grounded == false && JC % 2 == 1)
            {
                H.anim.SetTrigger("Jump");
                EarnHeadline("Super Human");
                JC = 2;
            }
        }

        if (Input.GetButtonDown("B") == true && heldItem == "Book" && p.holding == true)
        {
            EarnHeadline("Eater of Fictional Worlds");
        }

        if (Input.GetButtonDown("B") == true && heldItem == "Shoes" && p.holding == true)
        {
            EarnHeadline("Sole-Eater");
        }

        if (Input.GetButtonDown("B") == true && heldItem == "Pants" && p.holding == true)
        {
            EarnHeadline("Delicious Denim");
        }

        if (Input.GetButtonDown("B") == true && heldItem == "Diamonds" && p.holding == true)
        {
            EarnHeadline("Bejeweled Bowels");
        }

        if (Input.GetButtonDown("B") == true && heldItem == "10GallonHat" && p.holding == true)
        {
            EarnHeadline("Howdy, Stomach");
        }

        if (Input.GetButtonDown("B") == true && heldItem == "Candle" && p.holding == true)
        {
            EarnHeadline("Burning Calories");
        }

        if (Input.GetButtonDown("B") == true && heldItem == "Incense" && p.holding == true)
        {
            EarnHeadline("Incense Appetizer");
        }

        if (Input.GetButtonDown("B") == true && heldItem == "Bible" && p.holding == true)
        {
            EarnHeadline("Absorb the Holy Word");
        }

        if (Input.GetButtonDown("B") == true && heldItem == "Wafer" && p.holding == true)
        {
            EarnHeadline("Wafer Glutton");
        }

        if (Input.GetButtonDown("B") == true && heldItem == "Communion Wine" && p.holding == true)
        {
            EarnHeadline("Wine Assault");
        }
    }

    public void EarnHeadline(string title)
    {
        if (headlines[title].EarnHeadline())
        {
            //Earned new headline, Do Stuff
            headlineQueue.Enqueue(HideHeadline(title));
        }
    }

    public IEnumerator HideHeadline(string title)
    {
        //Debug.Log("Creating Headline:" + title);
        GameObject headline = Instantiate(visualHeadline);
        SetHeadlineInfo("HeadlinesCanvas", headline, title);
        yield return new WaitForSeconds(5f);
        Destroy(headline);
    }

    /*private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
    }*/

    private IEnumerator Process()
    {
        //Debug.Log("Process Headline Queue");
        while (true)
        {
            if (headlineQueue.Count > 0)
                yield return StartCoroutine(headlineQueue.Dequeue());
            else
                yield return null;
        }
    }

    /*public void CreateHeadline(string parent, string title, string description)
    {
        GameObject headline = (GameObject)Instantiate(headlinePrefab);
        // Add headline to dictionary
        Headline newHeadline = new Headline(name, description, headline);
        headlines.Add(title, newHeadline);

        SetHeadlineInfo(parent, headline, title);
    }*/

    public void SetHeadlineInfo(string parent, GameObject headline, string title)
    {
        headline.transform.SetParent(GameObject.Find(parent).transform);
        headline.transform.localScale = new Vector3(1, 1, 1);
        headline.transform.GetChild(1).GetComponent<Text>().text = headlines[title].Hint;
        if (headlines[title].Description.Length > 30)
        {
            string myStr = headlines[title].Description;
            string[] arr = myStr.Split('^');
            headline.transform.GetChild(2).GetComponent<Text>().text = "" + arr[0] + "...";
        }
        //headline.transform.GetChild(2).GetComponent<Text>().text = headlines[title].Description;
    }

    public void ChangeCategory(GameObject button)
    {
        headlineButton = button.GetComponent<HeadlineButton>();

        scrollRect.content = headlineButton.headlineList.GetComponent<RectTransform>();
        
        activeButton.Click();
        activeButton = headlineButton;
    }

    private void Pause()
    {
        if (headlineMenu.gameObject.activeInHierarchy)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
    }
}