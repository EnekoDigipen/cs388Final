using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPopUpAnimation : MonoBehaviour
{
    private float t = 0f;
    private Vector3 origin, end;
    private void Awake()
    {
        origin = transform.position;
        end = new Vector3(origin.x, origin.y + 1f, origin.z);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(0.2f, 0.2f, 0.2f), t);
        transform.position = Vector3.Lerp(origin, end, t);
        t += Time.deltaTime;
        Debug.Log(transform.position);
    }
}
