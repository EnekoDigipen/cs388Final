using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 old_pos;
    bool stop_sleeping = false;
    float t = 0f;
    public float playing_time;
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        old_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(stop_sleeping && t < playing_time)
            t += Time.deltaTime;
        else
        {
            t = 0f;
            stop_sleeping = false;
            transform.position = old_pos;
            GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public void MoveBall()
    {
        Vector3 new_pos = transform.position;
        new_pos.z = 10;
        transform.position = new_pos;
        stop_sleeping = true;
        GetComponent<Rigidbody>().useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<RotateThis>().RotateNow();
    }
}
