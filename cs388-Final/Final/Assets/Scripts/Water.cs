using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private float timer = 0.0f;
    private bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated) { 

            timer += Time.deltaTime;
            int seconds = (int)(timer % 60);
            if (seconds >= 5) {

                GetComponent<Renderer>().enabled = false;
                activated = false;
                timer = 0.0f;
            }
        }
    }
    
    public void TriggerWater()
    {
        activated = true;
        GetComponent<Renderer>().enabled = true;
    }
}
