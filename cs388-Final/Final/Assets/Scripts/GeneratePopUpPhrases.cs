using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneratePopUpPhrases : MonoBehaviour
{
    public string[] phrases;
    public float display_time;
    bool generate = false, update = false;
    float t = 0f;
    Vector3 old_pos;

    // Start is called before the first frame update
    void Start()
    {
        old_pos = transform.position;
        transform.position = new Vector3(old_pos.x, old_pos.y * 10f, old_pos.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(generate)
        {
            int rand = Random.Range(0, phrases.Length);
            GetComponent<TextMeshProUGUI>().text = phrases[rand];
            generate = false;
            transform.position = old_pos;
        }

        if (update && t < display_time)
        {
            t += Time.deltaTime;
            Debug.Log(t);
        }
        else
        {
            t = 0f;
            transform.position = new Vector3(old_pos.x, old_pos.y * 10f, old_pos.z);
            update = false;
        }
    }

    public void GenerateText()
    {
        if(!update)
        {
            generate = true;
            update = true;
        }
    }
}
