using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OnGameLogic : MonoBehaviour
{
    TTS_SceneManager SceneMRef;
    Stats StatsMRef;
    Inventory InventoryRef;

    //fadeout
    private GameObject FO;
    private bool mActive = false;
    

    // Start is called before the first frame update
    void Start()
    {

        //get references to the constant components
        SceneMRef = GameObject.FindAnyObjectByType<TTS_SceneManager>();
        StatsMRef = GameObject.FindAnyObjectByType<Stats>();
        InventoryRef = GameObject.FindAnyObjectByType<Inventory>();
        
        FO = GameObject.Find("FadeOut");
        FO.SetActive(mActive);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TriggerAction1(){

        //Debug.Log("hello");
        mActive = !mActive;
        FO.SetActive(mActive);
    }
    public void TriggerAction2(){

    }
    public void TriggerAction3(){

    }
    public void ExitGame()
    {
        SceneMRef.LoadNextScene(4);
    }
}
