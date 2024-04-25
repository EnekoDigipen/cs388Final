using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OnGameLogic : MonoBehaviour
{
    //components
    TTS_SceneManager SceneMRef;
    TimeSystem Clock;
    Stats StatsMRef;
    MoveButtons[] MovingButtons;
    Cure CureOption;
    private bool ButtonsActivated = false;

    //fadeout
    private GameObject FO;
    private bool mActive = false;

    //Frienship bar
    private GameObject FB;
    public GameObject prefab;

    private string LastTimeFrienshipReduced = "NONE";
    private string LastTimeSinceSleep = "NONE";
    private string TimeSinceSleepStarted = "NONE";

    //renderer of the objs above the character
    private Renderer Thirsty;
    private Renderer Sleepy;
    private Renderer Hunger;
    private Renderer Sick;

    private Renderer ThirstyB;
    private Renderer SleepyB;
    private Renderer HungerB;
    private Renderer SickB;


    private Renderer Sun;
    private Renderer Moon;


    // Start is called before the first frame update
    void Start()
    {

        //get references to the constant components
        SceneMRef = GameObject.FindAnyObjectByType<TTS_SceneManager>();
        StatsMRef = GameObject.FindAnyObjectByType<Stats>();
        Clock = GameObject.FindAnyObjectByType<TimeSystem>();
        MovingButtons = GameObject.FindObjectsOfType<MoveButtons>();
        CureOption = GameObject.FindAnyObjectByType<Cure>();

        //renderers
        Thirsty = GameObject.Find("Thirsty").GetComponent<Renderer>();
        Hunger = GameObject.Find("Hunger").GetComponent<Renderer>();
        Sleepy = GameObject.Find("Sleepy").GetComponent<Renderer>();
        Sick = GameObject.Find("Sick").GetComponent<Renderer>();

        ThirstyB = GameObject.Find("ThirstyBocadillo").GetComponent<Renderer>();
        HungerB = GameObject.Find("HungerBocadillo").GetComponent<Renderer>();
        SleepyB = GameObject.Find("SleepyBocadillo").GetComponent<Renderer>();
        SickB = GameObject.Find("SickBocadillo").GetComponent<Renderer>();

        Sun = GameObject.Find("Sun").GetComponent<Renderer>();
        Moon = GameObject.Find("Moon").GetComponent<Renderer>();
        Sun.enabled = false;
        Moon.enabled = false;

        //gameobjs
        FB = GameObject.Find("FrienshipBarR");
        FO = GameObject.Find("FadeOut");

        LastTimeFrienshipReduced = PlayerPrefs.GetString("FrienshipClock", "NONE");
        if (LastTimeFrienshipReduced == "NONE") {

            LastTimeFrienshipReduced = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
            PlayerPrefs.SetString("FrienshipClock", LastTimeFrienshipReduced);
        }
        LastTimeSinceSleep = PlayerPrefs.GetString("LastTimeSinceSleep", "NONE");
        if (LastTimeSinceSleep == "NONE"){

            LastTimeSinceSleep = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
            PlayerPrefs.SetString("LastTimeSinceSleep", LastTimeSinceSleep);
        }
        TimeSinceSleepStarted = PlayerPrefs.GetString("TimeSinceSleepStarted", "NONE");
        if (TimeSinceSleepStarted == "NONE"){

            TimeSinceSleepStarted = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
            PlayerPrefs.SetString("TimeSinceSleepStarted", TimeSinceSleepStarted);
        }
        int Lights = PlayerPrefs.GetInt("Sleep Mode", 0);
        if (Lights == 1)
        {

            mActive = true;
        }

        FO.SetActive(mActive);
        //SleepState();
        EnableStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if(Clock.TimeEllapsed() >= 5){

            int Iterations = (int)(Clock.TimeEllapsed()/5);

            for(int i = 0; i < Iterations; i++){
                
                int OptionsReduce = Random.Range(0,3);
                if(OptionsReduce == 0){

                    //increase hunger
                    StatsMRef.IncreaseHunger();
                }
                else if(OptionsReduce == 1){
                    
                    //increase thirsty
                    StatsMRef.IncreaseThirsty();
                }
                else{

                    //Increase Sick
                    StatsMRef.IncreaseSick();
                }
            }
            Clock.StoreCurrentTime();
            Clock.StoreTimeAppData();
            StatsMRef.StoreStatsAppData();
        }
        EnableStatus();
        SleepState();
        CalculateFrienship();
    }

    //enable/diseable the renderers
    private void EnableStatus(){

        if (StatsMRef.GetHunger() > 0) {

            if (Hunger.enabled == false){

                Hunger.enabled = true;
                HungerB.enabled = true;
            }
        }
        else{

            if (Hunger.enabled == true){

                Hunger.enabled = false;
                HungerB.enabled = false;
            }
        }
        if (StatsMRef.GetThirsty() > 0){

            if (Thirsty.enabled == false){

                Thirsty.enabled = true;
                ThirstyB.enabled = true;
            }
        }
        else{

            if (Thirsty.enabled == true){

                Thirsty.enabled = false;
                ThirstyB.enabled = false;
            }
        }
        if (StatsMRef.Getsleep() == true){

            if (Sleepy.enabled == false){

                Sleepy.enabled = true;
                SleepyB.enabled = true;
            }
        }
        else{

            if (Sleepy.enabled == true){

                Sleepy.enabled = false;
                SleepyB.enabled = false;
            }
        }
        if (StatsMRef.GetSick() > 0){

            if (Sick.enabled == false){

                Sick.enabled = true;
                SickB.enabled = true;
            }
        }
        else{

            if (Sick.enabled == true){

                Sick.enabled = false;
                SickB.enabled = false;
            }
        }
        if (mActive == true)
        {
            if (Moon.enabled == false)
            {

                Moon.enabled = true;
                Sun.enabled = false;
            }
        }
        else
        {
            if (Sun.enabled == false)
            {

                Moon.enabled = false;
                Sun.enabled = true;
            }
        }
    }

    //Generate food
    public void SpawnPrefab()
    {
        float x = 0.02f;
        float y = 5.5f;
        GameObject Clone = Instantiate(prefab, new Vector3(x, y, -5.0f), Quaternion.identity);

        Clone.transform.eulerAngles = new Vector3(-40.0f,270.0f,90.0f);
        Clone.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    //(De)Activate lights
    public void TriggerAction1(){

        if (ButtonsActivated == true) {

            TriggerAction5();
        }
        mActive = !mActive;
        FO.SetActive(mActive);
        if (mActive == true)
        {

            TimeSinceSleepStarted = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
            PlayerPrefs.SetString("TimeSinceSleepStarted", TimeSinceSleepStarted);
        }
        StoreSleepState();
    }

    //feed the character
    public void TriggerAction2(){

        if (ButtonsActivated == true)
        {

            TriggerAction5();
        }
        //if sleeping, return
        if (mActive == true)
            return;
        //generate food
        SpawnPrefab();
        //decrease hunger
        StatsMRef.DecreaseHunger();
        StatsMRef.StoreStatsAppData();
    }

    //give water to the character
    public void TriggerAction3()
    {
        if (ButtonsActivated == true)
        {

            TriggerAction5();
        }
        //if sleeping, return
        if (mActive == true)
            return;
        //decrease hunger
        StatsMRef.DecreaseThirsty();
        StatsMRef.StoreStatsAppData();
    }

    //give medicine to the character
    public void TriggerAction4()
    {
        if (ButtonsActivated == true)
        {

            TriggerAction5();
        }
        //if sleeping, return
        if (mActive == true)
            return;
        //decrease sick
        StatsMRef.DecreaseSick();
        StatsMRef.StoreStatsAppData();
        CureOption.TriggerCure();
    }

    public void TriggerAction5(){

        ButtonsActivated = !ButtonsActivated;
        for (int i = 0; i < MovingButtons.Length; i++)
        {
            MovingButtons[i].MoveButton();
        }
    }
    public void TriggerAction6()
    {        
        Application.Quit();
    }

    public void TriggerAction7()
    {
        SceneMRef.LoadNextScene(2);
    }
    public void SleepState() {

        //Sleep activated
        if (mActive == true){

            if (Clock.TimeEllapsedGiven(TimeSinceSleepStarted) >= 1){

                StatsMRef.Setsleep(false);
                StatsMRef.StoreStatsAppData();
                LastTimeSinceSleep = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
                PlayerPrefs.SetString("LastTimeSinceSleep", LastTimeSinceSleep);
                if (Clock.TimeEllapsedGiven(TimeSinceSleepStarted) > 30){

                    StatsMRef.ChangeFrienship(-10.0f);
                }
            }
        }
        else{

            //more than 6 hours since last sleep, so is sleepy
            if (Clock.TimeEllapsedGiven(LastTimeSinceSleep) >= 1){

                StatsMRef.Setsleep(true);
                StatsMRef.StoreStatsAppData();
            }
        }
    }

    public void StoreSleepState(){

        //Sleep activated
        int ValueToStore = 0;
        if (mActive == true)
        {

            ValueToStore = 1;
        }
        PlayerPrefs.SetInt("Sleep Mode", ValueToStore);
    }

    //calculate the current friendship
    public void CalculateFrienship(){

        //minute * (Thirsty + Hunger + Sick)/100
        int MinutesEllapsed = (int)(Clock.TimeEllapsedGiven(LastTimeFrienshipReduced));
        if (MinutesEllapsed >= 10){

            float FrienshipReduced = -(float)(MinutesEllapsed * (StatsMRef.GetThirsty() + StatsMRef.GetHunger() + StatsMRef.GetSick()));
            FrienshipReduced *= 0.01f;
            if (StatsMRef.Getsleep()) {

                FrienshipReduced -= 0.5f;
            }
            StatsMRef.ChangeFrienship(FrienshipReduced);
            LastTimeFrienshipReduced = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
            PlayerPrefs.SetString("FrienshipClock", LastTimeFrienshipReduced);
        }
        
        ChangeFrienshipBar();
    }

    //Change the frienship bar
    public void ChangeFrienshipBar(){

        //Scale of the frienship bar
        Vector3 SVector = new Vector3(FB.transform.localScale.x, FB.transform.localScale.y, StatsMRef.GetFriendship() * 0.007f);
        //Position of the frienship bar
        Vector3 PVector = new Vector3(FB.transform.localPosition.x, (-(100.0f - StatsMRef.GetFriendship()) * 0.035f)+0.47f, FB.transform.localPosition.z);

        //Change scale and position to the frienship bar
        FB.transform.localScale = SVector;
        FB.transform.localPosition = PVector;
    }
}
