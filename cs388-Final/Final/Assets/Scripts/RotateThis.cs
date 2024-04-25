using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis : MonoBehaviour
{
    bool rotate = false;
    float rot = 0f;
    Quaternion origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate && rot < 360f)
        {
            transform.Rotate(new Vector3(0, 10f, 0));
            rot += 10f;
        }
        else
        {
            rotate = false;
            rot = 0f;
            transform.rotation = origin;
        }
    }

    public void RotateNow()
    {
        rotate = true;
    }
}
