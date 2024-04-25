using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModel : MonoBehaviour
{
    GameObject MonsterObj;
    public GameObject Happy;
    public GameObject Sad;
    public GameObject Ugly;
    // REMOVE THIS LATER!!!
    float t = 0f;
    int idx = 0;
    // Start is called before the first frame update
    void Start()
    {
        MonsterObj = GameObject.FindWithTag("Monster");
    }

    // Update is called once per frame
    void Update()
    {
        if(t > 5f)
        {
            Destroy(MonsterObj);
            if (idx % 3 == 0)
                MonsterObj = Instantiate(Happy);
            else if (idx % 3 == 1)
                MonsterObj = Instantiate(Sad);
            else
                MonsterObj = Instantiate(Ugly);
            
            t = 0f;
            idx++;
        }

        t += Time.deltaTime;
    }
}
