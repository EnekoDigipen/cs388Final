using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure : MonoBehaviour
{
    private float timer = 0.0f;
    private bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
        var emission = GetComponent<ParticleSystem>().emission; // Stores the module in a local variable
        emission.enabled = false; // Applies the new value directly to the Particle System
    }

    // Update is called once per frame
    void Update()
    {
        if (activated) { 

            timer += Time.deltaTime;
            int seconds = (int)(timer % 60);
            if (seconds >= 5) {

                GetComponent<Renderer>().enabled = false;
                var emission = GetComponent<ParticleSystem>().emission; // Stores the module in a local variable
                emission.enabled = false; // Applies the new value directly to the Particle System
                activated = false;
                timer = 0.0f;
            }
        }
    }

    public void TriggerCure()
    {
        activated = true;
        GetComponent<Renderer>().enabled = true;
        var emission = GetComponent<ParticleSystem>().emission; // Stores the module in a local variable
        emission.enabled = true; // Applies the new value directly to the Particle System
    }
}
