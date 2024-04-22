using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OnGameLogic : MonoBehaviour
{
    TTS_SceneManager SceneMRef;
    Stats StatsMRef;
    Inventory InventoryRef;
    TimeSystem Clock;

    //fadeout
    private GameObject FO;
    private bool mActive = false;

    public GameObject prefab;
    public Renderer Hunger;
    public Renderer Thirsty;
    public Renderer Sleepy;

    // Start is called before the first frame update
    void Start()
    {

        //get references to the constant components
        SceneMRef = GameObject.FindAnyObjectByType<TTS_SceneManager>();
        Clock = GameObject.FindAnyObjectByType<TimeSystem>();
        StatsMRef = GameObject.FindAnyObjectByType<Stats>();
        InventoryRef = GameObject.FindAnyObjectByType<Inventory>();
        
        FO = GameObject.Find("FadeOut");
        Hunger = GameObject.Find("Hunger").GetComponent<Renderer>();
        Thirsty = GameObject.Find("Thirsty").GetComponent<Renderer>();
        Sleepy = GameObject.Find("Sleepy").GetComponent<Renderer>();
        FO.SetActive(mActive);
        EnableStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if(Clock.TimeEllapsed() > 5){

            int Iterations = (int)(Clock.TimeEllapsed()/5);
            for(int i = 0; i < Iterations; i++){


            }
            EnableStatus();
        }
    }
    private void EnableStatus(){

        if (StatsMRef.GetHunger() > 0) {

            if (Hunger.enabled == false){

                Hunger.enabled = true;
            }
        }
        else{

            if (Hunger.enabled == true){

                Hunger.enabled = false;
            }
        }
        if (StatsMRef.GetThirsty() > 0){

            if (Thirsty.enabled == false){

                Thirsty.enabled = true;
            }
        }
        else{

            if (Thirsty.enabled == true){

                Thirsty.enabled = false;
            }
        }
        if (StatsMRef.Getsleep() > 0){

            if (Sleepy.enabled == false){

                Sleepy.enabled = true;
            }
        }
        else{

            if (Sleepy.enabled == true){

                Sleepy.enabled = false;
            }
        }
    }

    public void SpawnPrefab()
    {
        float x = 0.02f;
        float y = 5.5f;
        GameObject Clone = Instantiate(prefab, new Vector3(x, y, -5.0f), Quaternion.identity);

        Clone.transform.eulerAngles = new Vector3(90.0f,180.0f,0.0f);
        Clone.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
    public void TriggerAction1(){

        mActive = !mActive;
        FO.SetActive(mActive);
    }
    public void TriggerAction2(){

        //if sleeping, return
        if (mActive == true)
            return;
        //generate food
        SpawnPrefab();
        //decrease hunger
        StatsMRef.DecreaseHunger();
    }
    public void TriggerAction3()
    {
        //if sleeping, return
        if (mActive == true)
            return;
        //decrease hunger
        //StatsMRef.DecreaseThirsty();
        
        Debug.Log("Delta " + Clock.TimeEllapsed());
    }
    public void TriggerAction4()
    {
        Clock.StoreCurrentTime();
    }
    public void ExitGame()
    {
        SceneMRef.LoadNextScene(4);
    }
}
