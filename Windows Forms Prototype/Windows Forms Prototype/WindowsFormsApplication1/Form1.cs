using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        mainDatabase myDatabase;//declares the database so it can use all the headlines, nouns, and verbs I put in the database

        public Form1()//this runs when the program starts
        {
            InitializeComponent();

            myDatabase = new mainDatabase();

            for (int i = 0; i < myDatabase.headlineList.Count; i++)//fills the listbox (thing on the right side of the form) with headline hints
            {
                listBox1.Items.Add(myDatabase.headlineList[i].hint);
            }

            listBox1.SelectedIndex = 0;
            checkHeadlineCompletion(myDatabase.headlineList[0]);//just initially sets the label below the listbox to say "not unlocked"

            //fills up the combo boxes
            fillNounCB(ObjectBox);
            fillNounCB(ItemObjectBox);
            fillVerbCB(ActionsBox);
            fillItemVerbCB(ItemActionsToBox);
        }

        private void button1_Click(object sender, EventArgs e)//runs when the user clicks Execute
        {
            HeadlineLabel.Text = "";
            locationUpdate();           
            checkForHeadlineUnlock();
            itemPanelUpdate();
        }

        private void checkForHeadlineUnlock()//searches through headlines to see if the user action matches up to any headlines
        {
            //fill action 1 with user entered words
            Action action1 = new Action();
            if (ItemActionToggle.Checked == false)//item panel checkbox is NOT checked
            {
                action1.predicate = ActionsBox.Text;
                action1.objectNoun = ObjectBox.Text;
            }
            else//item panel checkbox is checked
            {
                action1.predicate = ItemActionsToBox.Text;
                action1.objectNoun = UsableItemBox.Text;
                action1.prepositionalNoun = ItemObjectBox.Text;
            }

            for (int i = 0; i < myDatabase.headlineList.Count; i++)//compare actions to headlines
            {
                if (myDatabase.headlineList[i].completed == false)//tells the program "don't bother checking if the headline is already unlocked"
                {
                    if (myDatabase.headlineList[i].location == null || myDatabase.headlineList[i].location == locationBox.Text)//checks if user has the right location, unless there is no required location
                    {
                        for (int j = 0; j < myDatabase.headlineList[i].possibleActions.Count; j++)
                        {
                            if (actionEquality(action1, myDatabase.headlineList[i].possibleActions[j]))
                            {                                
                                HeadlineLabel.Text = "Headline Unlocked!: " + myDatabase.headlineList[i].hint;//user unlocked the headline, update the label to tell the user and update the headline in the database
                                myDatabase.headlineList[i].completed = true;
                                if (listBox1.SelectedIndex == i)//if the user has the headline selected in the listbox, the label under the listbox needs to updated as well
                                {
                                    checkHeadlineCompletion(myDatabase.headlineList[i]);
                                }
                                break;//this might break out of both loops, which wouldn't allow for unlocking more than one headline at once. We don't have the ui for that either
                            }
                        }
                    }
                }
            }
        }

        private void checkHeadlineCompletion(Headline tmpHeadline)//checks the database to see if specified headline is completed, then sets the label below the listbox accordingly
        {
            if (tmpHeadline.completed)
            {
                HeadlineCompleteLabel.Text = "Headline Unlocked\r\n" + tmpHeadline.fullHeadline;
            }
            else
            {
                HeadlineCompleteLabel.Text = "Not Unlocked";
            }
        }

        private void locationUpdate()//updates location box
        {
            if (ItemActionToggle.Checked == false && ActionsBox.Text == "move to" && myDatabase.nounList[ObjectBox.Text].location == true)
            {
                locationBox.Text = ObjectBox.Text;
            }
        }

        private void itemPanelUpdate()//updates item panel
        {
            if (ItemActionToggle.Checked == false && ActionsBox.Text == "pick up")//item panel checkbox is NOT checked, and the verb is "pick up". This means the program needs to update the item panel with the newly picked up item
            {
                if (ObjectBox.Text != "" && myDatabase.nounList[ObjectBox.Text].equippable)//make sure there is a noun selected and that it is equippable
                {
                    UsableItemBox.Text = myDatabase.nounList[ObjectBox.Text].word;//updates the text box on the form
                    ItemActionToggle.Enabled = true;//enables the item action checkbox
                }
                else
                {
                    HeadlineLabel.Text = "Noun is not equippable";
                }
            }
            else//item panel checkbox is checked
            {
                if (ItemActionsToBox.Text == "drop" || ItemActionsToBox.Text == "throw" || ItemActionsToBox.Text == "give" || ItemActionsToBox.Text == "eat")//if item verb is drop or throw, unequip item
                {
                    UsableItemBox.Text = "";//resets and disables the item panel
                    ItemPanel.Enabled = false;
                    ItemActionToggle.Checked = false;
                    ItemActionToggle.Enabled = false;
                    ItemActionsToBox.SelectedItem = null;
                    ItemObjectBox.SelectedItem = null;
                }
                //I just realized that since this code runs before the program checks for headline unlocks, if a headline requires Florida Man to drop or throw an item, it wouldn't unlock...
                //The item and verb would need to be temporarily stored
                //Just overlook my shitty code
            }           
        }

        private bool actionEquality(Action tmpAction1, Action tmpAction2)//checks if two Action objects are the same
        {
            if (tmpAction1.objectNoun != tmpAction2.objectNoun && tmpAction2.objectNoun != "item" && tmpAction2.objectNoun != null)
                return false;
            else if (tmpAction1.predicate != tmpAction2.predicate && tmpAction2.predicate != null)
                return false;
            else if (tmpAction1.prepositionalNoun != tmpAction2.prepositionalNoun && tmpAction2.prepositionalNoun != null)
                return false;
            else
                return true;
        }

        private void fillNounCB(ComboBox tmpBox)//fills combo boxes with the contents of the noun list
        {
            var tmpNounList = myDatabase.nounList.Keys.ToList();
            for (int i = 0; i < tmpNounList.Count; i++)
            {
                tmpBox.Items.Add(tmpNounList[i]);
            }
        }

        private void fillVerbCB(ComboBox tmpBox)//fills combo boxes with the basic verb list
        {
            for (int i = 0; i < myDatabase.basicVerbList.Count; i++)
            {
                tmpBox.Items.Add(myDatabase.basicVerbList[i]);
            }
        }

        private void fillItemVerbCB(ComboBox tmpBox)//fills combo boxes with the item verb list
        {
            for (int i = 0; i < myDatabase.itemVerbList.Count; i++)
            {
                tmpBox.Items.Add(myDatabase.itemVerbList[i]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)//runs when the user clicks on a headline hint from the listbox
        {
            checkHeadlineCompletion(myDatabase.headlineList[listBox1.SelectedIndex]);
        }

        private void ItemActionToggle_CheckedChanged(object sender, EventArgs e)//item toggle. Tells the program where to get the words from and disables parts of the form to tell the user what words will be used.
        {
            if (ItemActionToggle.Checked)
            {
                ItemPanel.Enabled = true;
                UniversalActionPanel.Enabled = false;
            }
            else
            {
                ItemPanel.Enabled = false;
                UniversalActionPanel.Enabled = true;
            }
        }
    }
}
