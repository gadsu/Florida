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
    public class Headline
    {
        public string fullHeadline;
        public string hint;
        public bool completed = false;
        public List<Action> possibleActions;
        public string location;

        public Headline()
        {
            possibleActions = new List<Action>();
        }
    }

    public class Action
    {
        public string objectNoun;
        public string predicate;
        public string prepositionalNoun;
    }

    public class Noun
    {
        public string word;
        public bool equippable = false;
        public bool location = false;

        public Noun(string tmpWord)
        {
            word = tmpWord;
        }
    }

    public class mainDatabase
    {
        public List<Headline> headlineList = new List<Headline>();//all headlines are stored in this list
        public Dictionary<string, Noun> nounList = new Dictionary<string, Noun>();//nouns are stored in a dictionary that takes the word as a string and returns the noun object
        public List<string> basicVerbList = new List<string>();//normal verb strings stored in this list
        public List<string> itemVerbList = new List<string>();//item verb strings stored in this list

        public mainDatabase()//seeds all this stuff ^
        {
            seedHealines();
            seedNouns();
            seedBasicVerbs();
            seedItemVerbs();
        }

        private void seedHealines()
        {
            //fills the headline list
            Headline tmpHeadline = new Headline();
            Action action1 = new Action();

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man feels enlightened after consuming Bible";
            tmpHeadline.hint = "Absorb the Holy Word";
            action1.objectNoun = "bible";
            action1.predicate = "eat";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man mistakes Diamond Jewelry for rock candy";
            tmpHeadline.hint = "Bejeweled Bowels";
            action1.objectNoun = "diamond jewelry";
            action1.predicate = "eat";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man aquires taste for (item)";
            tmpHeadline.hint = "Bon Appetit";
            action1.objectNoun = "item";
            action1.predicate = "eat";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man topples display of rare books, now deemed worthless";
            tmpHeadline.hint = "Book Belcher";
            action1.objectNoun = "rare book display";
            action1.predicate = "burp";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man contributes to global warming, taxed for carbon output";
            tmpHeadline.hint = "Burp Man";
            action1.predicate = "burp";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            tmpHeadline.fullHeadline = "Florida Man steals empty cash register";
            tmpHeadline.hint = "Crime Doesn't Pay";
            action1.objectNoun = "empty cash register";
            action1.predicate = "pick up";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man takes 20% off Pair of Jeans, does not receive equivalent discount";
            tmpHeadline.hint = "Delicious Denim";
            action1.objectNoun = "pair of jeans";
            action1.predicate = "eat";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man hits the books, learns nothing";
            tmpHeadline.hint = "Desire2Learn";
            action1.objectNoun = "item";
            action1.predicate = "use";
            action1.prepositionalNoun = "bookshelf";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Churchgoers mistake Florida Man’s burp for voice of God";
            tmpHeadline.hint = "Divine Interburption";
            action1.objectNoun = "CHURCH";
            action1.predicate = "burp";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man lost for hours in (location)";
            tmpHeadline.hint = "Don't Give Up";
            action1.objectNoun = "platform";
            action1.predicate = "jump off";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man consumes knowledge, learns about internal paper cuts";
            tmpHeadline.hint = "Eater of Fictional Worlds";
            action1.objectNoun = "book";
            action1.predicate = "eat";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man fights imaginary friend with (item)";
            tmpHeadline.hint = "En Garde!";
            action1.objectNoun = "item";
            action1.predicate = "use";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man breaks escalator with Any Equipped Item, 2nd floor stores file for bankruptcy";
            tmpHeadline.hint = "Escalated Vandalism";
            action1.objectNoun = "item";
            action1.prepositionalNoun = "escalator";
            action1.predicate = "use";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man claims to be Olympic walker";
            tmpHeadline.hint = "Fancy feet";
            action1.predicate = "move";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man unsuccessfully pitches his own line of perfume";
            tmpHeadline.hint = "Florida Man Original Scent";
            action1.objectNoun = "DEPARTMENT STORE";
            action1.predicate = "burp";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man makes an offering of (item)";
            tmpHeadline.hint = "Generous Donor";
            action1.objectNoun = "item";
            action1.predicate = "give";
            action1.prepositionalNoun = "offering plate";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man steals free Magazine";
            tmpHeadline.hint = "Grand Theft Magazine";
            action1.objectNoun = "magazine";
            action1.predicate = "pick up";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man attempts to build an immunity to fire by eating burning Candle";
            tmpHeadline.hint = "Great Gut of Fire";
            action1.objectNoun = "candle";
            action1.predicate = "eat";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man fights malware with (item)";
            tmpHeadline.hint = "Hit any Key to Continue";
            action1.objectNoun = "item";
            action1.prepositionalNoun = "computer";
            action1.predicate = "use";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man drinks all the Communion Wine";
            tmpHeadline.hint = "Holy Merlot";
            action1.objectNoun = "communion wine";
            action1.predicate = "eat";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man eats 10-Gallon Hat, claims it was only 9 gallons";
            tmpHeadline.hint = "Howdy, Stomach";
            action1.objectNoun = "10-gallon hat";
            action1.predicate = "eat";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man eats Incense, does not taste as good as it smells";
            tmpHeadline.hint = "Incense Appetizer";
            action1.objectNoun = "incense";
            action1.predicate = "eat";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man fails to triple-jump, physicists relieved";
            tmpHeadline.hint = "Know Your Limits";
            action1.predicate = "triple jump";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man parts with his precious (item)";
            tmpHeadline.hint = "Litterer";
            action1.objectNoun = "item";
            action1.predicate = "drop";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man expands his territory";
            tmpHeadline.hint = "Marco Polo";
            action1.predicate = "move to";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man 'borrows' (item)";
            tmpHeadline.hint = "Mine!";
            action1.objectNoun = "item";
            action1.predicate = "pick up";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man attempts to receive refund for stolen item";
            tmpHeadline.hint = "Money Back Guarantee";
            action1.objectNoun = "item";
            tmpHeadline.location = "DEPARTMENT STORE";
            action1.prepositionalNoun = "Store Clerk";
            action1.predicate = "give";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man uses (item) to destroy massive perfume display, endangers shoppers with near-lethal dose of perfume";
            tmpHeadline.hint = "Olfactory Overload";
            action1.objectNoun = "item";
            action1.prepositionalNoun = "perfume display";
            action1.predicate = "use";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man attempts to play hymn";
            tmpHeadline.hint = "Organist";
            action1.objectNoun = "item";
            action1.predicate = "use";
            action1.prepositionalNoun = "organ";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man aggressively spreads knowledge";
            tmpHeadline.hint = "READ!";
            action1.objectNoun = "book";
            action1.prepositionalNoun = "Store Clerk";
            action1.predicate = "use";
            tmpHeadline.possibleActions.Add(action1);
            action1 = new Action();
            action1.objectNoun = "book";
            action1.prepositionalNoun = "Librarian";
            action1.predicate = "use";
            tmpHeadline.possibleActions.Add(action1);
            action1 = new Action();
            action1.objectNoun = "book";
            action1.prepositionalNoun = "Priest";
            action1.predicate = "use";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man hits on librarian, quietly rejected";
            tmpHeadline.hint = "Silent Rejection";
            action1.objectNoun = "flowers";
            action1.prepositionalNoun = "Librarian";
            action1.predicate = "give";
            tmpHeadline.possibleActions.Add(action1);
            action1 = new Action();
            action1.objectNoun = "diamond jewelry";
            action1.prepositionalNoun = "Librarian";
            action1.predicate = "give";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man consumes soles";
            tmpHeadline.hint = "Sole-Eater";
            action1.objectNoun = "shoes";
            action1.predicate = "eat";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man defies physics, refuses to reveal secret";
            tmpHeadline.hint = "Super Human";
            action1.predicate = "double jump";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man eats equivalent of Jesus’s body in Wafers";
            tmpHeadline.hint = "Wafer Glutton";
            action1.objectNoun = "wafers";
            action1.predicate = "eat";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man spreads the word on the dangers of alcohol";
            tmpHeadline.hint = "Wine Assault";
            action1.objectNoun = "communion wine";
            action1.prepositionalNoun = "Store Clerk";
            action1.predicate = "use";
            tmpHeadline.possibleActions.Add(action1);
            action1 = new Action();
            action1.objectNoun = "communion wine";
            action1.prepositionalNoun = "Librarian";
            action1.predicate = "use";
            tmpHeadline.possibleActions.Add(action1);
            action1 = new Action();
            action1.objectNoun = "communion wine";
            action1.prepositionalNoun = "Priest";
            action1.predicate = "use";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

            tmpHeadline = new Headline();
            action1 = new Action();
            tmpHeadline.fullHeadline = "Florida Man jumps, nobody is impressed";
            tmpHeadline.hint = "With Great Effort";
            action1.predicate = "jump";
            tmpHeadline.possibleActions.Add(action1);
            headlineList.Add(tmpHeadline);

        }

        private void seedNouns()
        {
            //fills the nouns dictionary

            Noun tmpNoun = new Noun("CHURCH");
            tmpNoun.location = true;
            nounList.Add("CHURCH", tmpNoun);

            tmpNoun = new Noun("DEPARTMENT STORE");
            tmpNoun.location = true;
            nounList.Add("DEPARTMENT STORE", tmpNoun);

            tmpNoun = new Noun("LIBRARY");
            tmpNoun.location = true;
            nounList.Add("LIBRARY", tmpNoun);

            tmpNoun = new Noun("Librarian");
            nounList.Add("Librarian", tmpNoun);

            tmpNoun = new Noun("Priest");
            nounList.Add("Priest", tmpNoun);

            tmpNoun = new Noun("Store Clerk");
            nounList.Add("Store Clerk", tmpNoun);

            tmpNoun = new Noun("10-gallon hat");
            tmpNoun.equippable = true;
            nounList.Add("10-gallon hat", tmpNoun);

            tmpNoun = new Noun("bible");
            tmpNoun.equippable = true;
            nounList.Add("bible", tmpNoun);

            tmpNoun = new Noun("book");
            tmpNoun.equippable = true;
            nounList.Add("book", tmpNoun);

            tmpNoun = new Noun("bookshelf");
            nounList.Add("bookshelf", tmpNoun);

            tmpNoun = new Noun("candle");
            tmpNoun.equippable = true;
            nounList.Add("candle", tmpNoun);

            tmpNoun = new Noun("communion wine");
            tmpNoun.equippable = true;
            nounList.Add("communion wine", tmpNoun);

            tmpNoun = new Noun("computer");
            nounList.Add("computer", tmpNoun);

            tmpNoun = new Noun("diamond jewelry");
            tmpNoun.equippable = true;
            nounList.Add("diamond jewelry", tmpNoun);

            tmpNoun = new Noun("empty cash register");
            tmpNoun.equippable = true;
            nounList.Add("empty cash register", tmpNoun);

            tmpNoun = new Noun("escalator");
            nounList.Add("escalator", tmpNoun);

            tmpNoun = new Noun("flowers");
            tmpNoun.equippable = true;
            nounList.Add("flowers", tmpNoun);

            tmpNoun = new Noun("incense");
            tmpNoun.equippable = true;
            nounList.Add("incense", tmpNoun);

            tmpNoun = new Noun("jewelry stand");
            nounList.Add("jewelry stand", tmpNoun);

            tmpNoun = new Noun("magazine");
            tmpNoun.equippable = true;
            nounList.Add("magazine", tmpNoun);

            tmpNoun = new Noun("offering plate");
            nounList.Add("offering plate", tmpNoun);

            tmpNoun = new Noun("organ");
            nounList.Add("organ", tmpNoun);

            tmpNoun = new Noun("pair of jeans");
            tmpNoun.equippable = true;
            nounList.Add("pair of jeans", tmpNoun);

            tmpNoun = new Noun("perfume display");
            nounList.Add("perfume display", tmpNoun);

            tmpNoun = new Noun("platform");
            nounList.Add("platform", tmpNoun);

            tmpNoun = new Noun("rare book display");
            nounList.Add("rare book display", tmpNoun);

            tmpNoun = new Noun("shoes");
            tmpNoun.equippable = true;
            nounList.Add("shoes", tmpNoun);

            tmpNoun = new Noun("wafers");
            tmpNoun.equippable = true;
            nounList.Add("wafers", tmpNoun);

        }

        private void seedBasicVerbs()
        {
            //fills the basic verbs list
            basicVerbList.Add("burp");
            basicVerbList.Add("double jump");
            basicVerbList.Add("jump");
            basicVerbList.Add("jump off");
            basicVerbList.Add("jump on");
            basicVerbList.Add("move");
            basicVerbList.Add("move to");
            basicVerbList.Add("pick up");
            basicVerbList.Add("triple jump");
        }

        private void seedItemVerbs()
        {
            //fills the item verbs list
            itemVerbList.Add("drop");
            itemVerbList.Add("eat");
            itemVerbList.Add("give");
            itemVerbList.Add("throw");
            itemVerbList.Add("use");
        }
    }


}
