using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModel : MonoBehaviour
{
    GameObject MonsterObj;
    public GameObject Happy;
    public GameObject Sad;
    public GameObject Ugly;
    string State = "Happy";

    // Start is called before the first frame update
    void Start()
    {
        MonsterObj = GameObject.FindWithTag("Monster");
    }

    public void CreateHappy()
    {
        Vector3 pos = MonsterObj.transform.position;
        Destroy(MonsterObj);
        MonsterObj = Instantiate(Happy);
        MonsterObj.transform.position = pos;
    }

    public void CreateSad()
    {
        Vector3 pos = MonsterObj.transform.position;
        Destroy(MonsterObj);
        MonsterObj = Instantiate(Sad);
        MonsterObj.transform.position = pos;
    }

    public void CreateUgly()
    {
        Vector3 pos = MonsterObj.transform.position;
        Destroy(MonsterObj);
        MonsterObj = Instantiate(Ugly);
        MonsterObj.transform.position = pos;
    }

    public string GetState() { return State; }
    public void SetState(string new_state) { State = new_state; }
}
