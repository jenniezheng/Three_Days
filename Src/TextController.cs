using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
    //Unity Objects
    public Text body;
    public Text title;
   
    //Game Variables
    private enum states {_gameOver, _startDay,_tv, _home, _home2, _lab, _lab2, _lab3, _park, _park2 };
    private states state;
    private int day;
    private int researchProgress;
    private int familyProgress;


    // Use this for initialization
    void Start () {
        day = 1;
        researchProgress = 0;
        familyProgress = 0;
        state= states._startDay;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case states._startDay: startDay(); break;
            case states._gameOver: gameOver(); break;
            case states._home: home(); break;
            case states._home2: home2(); break;
            case states._lab: lab(); break;
            case states._lab2: lab2(); break;
            case states._lab3: lab3(); break;
            case states._park: park(); break;
            case states._park2: park2(); break;
            case states._tv: tv(); break;
            default: body.text = "What is happening?"; break;
        }
    }

    void sleep()
    {
        if (day == 3) state = states._gameOver;
        else
        {
            day++;
            state = states._startDay;
        }
    }

    void gameOver()
    {
        string update = "";
        if (researchProgress == 3){
            title.text = "You Won!";
            update = "You manage to find the cure for the virus. Once your wife and surviving daughter recieved the cure, their coughs decreased and they" +
                " started looking healthier. Hospitals are beginning to mass-produce the cure based on your research. You have won a nobel prize for saving the world.";
        }
        else if (familyProgress >=2)
        {
            title.text = "Family Death";
            update = "Your older daughter and your wife pass away in your arms, and you yourself enter the brink of conciousness. ";
        }
        else
        {
            title.text = "Died";
            update = "In the middle of the night, your coughing becomes so bad that you can't breathe. After moments of agonizing oxygen deprivation,"+
                " you die.";
        }
        body.text = update + "\n\n[Press 'y' to restart]";
        if (Input.GetKeyDown("y"))
        Start();
    }

    void choices()
    {
        if (Input.GetKeyDown("h")) state = states._home;
        else if (Input.GetKeyDown("r")) state = states._lab;
        else if (Input.GetKeyDown("p")) state = states._park;
    }


    #region stateHandlers
    void startDay(){
        //update status
        string update = "";
        switch (day)
        {
            case 1: title.text = "Three Days Left...";
                   update = "Today is September 13, 2029. Three days before humanity will perish from the genetically engineered Coli virus. " +
                 " What will you do today?"; break;
            case 2: title.text = "Two Days Left...";
                  update = "Today is September 14, 2029. The virus has killed a third of the population already. Your time is running out. What will you do today?"; break;
            case 3: title.text = "Last Day...";
                update = "Today is September 15, 2029. The virus has killed two thirds of the population. Today is likely the last day of your life."
                    +"What will you do today?";  break;
        }
       body.text=update+ "\n\n['h' to go home, 'r' to go to research, or 'p' to go to the park]";
       choices();
    }

    void lab(){
        string update = "";
        switch (day) {
            case 1: update = "Vats of chemicals, bacteria, and viruses overwhelm you. Dozens of your coworkers are forming theories, collecting data, researching "+
                    "and testing hypotheses. With them you feem a slither of hope that maybe humanity won't perish."; break;
            case 2:  update = "Vats of chemicals bacteria, and viruses surround you. Half of the workers have died due to a virus outbreak accident yesterday. " +
              "The atmosphere is gloomy. Your friend advises you to stop wasting your time as he leaves the lab."; break;
            case 3: update = "The lab is locked. You spend half an hour looking for the janitor and obtaining a key from him. Upon entering, " +
                    "vats of chemicals bacteria, and viruses surround you. You're the only one here. "; break;
        }
        body.text = update  + "\n\n['y' to research,'h' to go home, or 'p' to go to the park]";
        if (Input.GetKeyDown("y"))
        {
            if (1 == Random.Range(0, 2)) { researchProgress++; state = states._lab2; }
            else state = states._lab3;
        }
        choices();
    }

    void lab2(){
        string update = "";
        switch (researchProgress) { 
        case 1: update = "You discover a particular strain of bacteria, the Listeria monocytogenes, is particularly resistant to the virus. Is this a step to the cure?"; break;
        case 2: update = "You have determined that the Listeria monocytogenes releases a restriction enzyme that can cut up the Col virus beyond recognition!. " +
                               "Now all you need to do is somehow isolate the enzyme."; break;
        case 3: update = "By a stroke of luck, you figured out that after cooling the bacteria down to -4 degrees celcius, the bacteria starts mass producing the " +
                    "virus killing enzyme, which can then be effectively gathered for human use.";break;
        }
        body.text = update+ "\n\n[Press 'y' to continue]";
        if (Input.GetKeyDown("y")) sleep();
    }

    void lab3()
    {
        string update="";
        switch (day) {
        case 1: update = "After a full straight hours of agony, you obttain nothing. Not even obtain a sliver of inspiration. What a waste of time."; break;
        case 2: update = "You've just wasted another precious day with your lack of results. If all those other scientists can't find a cure, then how could you?"; break;
        case 3: update = "Nothing! Nothing at all except a horrible stench is hidden within these dead bodies that you're researching."; break;
        }
        body.text = update + "\n\n[Press 'y' to continue]";
        if (Input.GetKeyDown("y")) sleep();

    }

    void home(){
        string update = "";
        switch (day)
        {
            case 1:  update = "You are at home with your family. Your two daughters are confused, and you're not sure how to explain to them that they're " +
                    "going to die, that life is unfair, and life is going to be particularly unfair for them. Your wife is ok."; break;
            case 2:
                update = update = "You are at home with your family. Your six year old daughter has gotten a nasty cough, and you can only pray that " +
                    " she did not contract the Coli virus."; break;
            case 3:
                update = "You are at home with your family. Your younger daughter passed away last night, and your family held a quick funeral " +
                    "for her. Your wife and older daughter are coughing as well. They won't last long. "; break;
        }
        body.text = update + "\n\n['t' to look at tv, 'y' to spend time with family,'r' to go to research, or 'p' to go to the park]";

        if (Input.GetKeyDown("y")) { familyProgress++;  state = states._home2; }
        else if (Input.GetKeyDown("t")) state = states._tv;
        choices();
    }

    void home2()
    {
        string update = "";
        switch (day) {
            case 1: update = "The view from the top of Angel's Landing in Zion is amazing. Your children are so happy to be here."; break;
            case 2: update = "Ah, wild and passionate sex with your wife. Wonder if there's a term called death sex."; break;
            case 3: update = "Now is the time to binge on everything unhealthy. Your surviving daughter get cheetos and icecream, while you and your wife take herion."; break;
        }
        body.text = update + "\n\n[Press 'y' to continue]";
        if (Input.GetKeyDown("y")) sleep();
    }

    void tv()
    {
        string update = "";
        switch (day) {
            case 1: update = "The owner of your favorite Korean Barbeque restaurant has committed suicide and ordered his servant to mix"+
                    " pieces of the owner's flesh into the beef."; break;
            case 2: update = "A suicide roller coaster is offering to kill people through exhilarating prolonged " +
                                 "cerebral hypoxia. If you can’t live, might as well die in the happiest way possible, right?"; break;
            case 3: update = "No channels have a signal. Everybody is killing, dying, or dead. That's the only only thing that matters now."; break;
        }

        body.text = update + "\n\n[Press 'y' to continue]";
        if (Input.GetKeyDown("y")) state=states._home;
    }

    void park(){
        string update = "";
        switch (day)
        {
            case 1: update = "You sit at an empty bench, watching children play on the swing sets and climb on the trees. They seem temporarily happy."; break;
            case 2: update = "You sit at an empty bench, and watch as a few children fight over who gets to use the swing first. Then suddenly one child starts screaming" +
                    " and the rest do as well, until they are all screeching at the top of their lungs."; break;
            case 3: update = "You sit at an empty bench, and you can't help noticing all the corpses hanging from the tree trunks. The park has turned into a" +
                    " suicide spot for those already infected."; break;
        }
       
        body.text = update+ "\n\n['y' to contemplate for an hour,'h' to go home, or 'r' to go research]";
        if (Input.GetKeyDown("y")) state = states._park2;
        choices();
    }

    void park2()
    {
        string update = "";
        switch (day)
        {
            case 1:  update = "Three days. Three days before the end of humanity. All those ground breaking technological accomplishments will decay one by one, " +
                            "until all that’s left is nuclear waste. Maybe you did not live the best you could, but you can still die the best you could."; break;
            case 2: update = "What kind of person invented the ultimate weapon to destroy humanity? A careless idiot trying to fight his enemies? " +
                             "Or a suicidal genius planning his grand death?"; break;
            case 3: update = "You feel that you've been running for your life, for all your life, but never fast enough."; break;
        }
        body.text = update + "\n\n[Press 'y' to continue]";
        if (Input.GetKeyDown("y")) state = states._park;
    }
    #endregion stateHandlers


	
}
