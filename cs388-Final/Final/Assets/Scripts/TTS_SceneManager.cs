using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTS_SceneManager : MonoBehaviour
{
    Inventory inventoryRef;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        inventoryRef = GameObject.FindAnyObjectByType<Inventory>();
        DontDestroyOnLoad(inventoryRef);
    }

    public void LoadNextScene(int NewSceneToLoad){

        //call the transition
        SceneToLoad = NewSceneToLoad;
        //stop the input and whatever event is being called
        Invoke("RealLoadNextScene", 1f);
    }

    int SceneToLoad = 0;
    void RealLoadNextScene(){

        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneToLoad);
    }
}
