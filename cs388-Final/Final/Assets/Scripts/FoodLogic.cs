using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when the food reaches a certain height, destroy it
        if (transform.localPosition.y < -2.9f) {

            Destroy(gameObject);
        }
    }
}
