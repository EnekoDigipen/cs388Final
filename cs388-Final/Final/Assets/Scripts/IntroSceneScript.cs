using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSceneScript : MonoBehaviour
{

    TTS_SceneManager SceneMRef;
    int NextScene = 1;
    // Start is called before the first frame update
    void Start()
    {
        SceneMRef = GameObject.FindAnyObjectByType<TTS_SceneManager>();
        Invoke("GoToMenu", 1f);
    }

    void GoToMenu()
    {
        SceneMRef.LoadNextScene(NextScene);
    }
}
