using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private int Hunger = 0;
    private int Thirsty = 0;
    private int sleep = 0;
    private float Friendship = 0.0f;

    private GameObject FB;
    // Start is called before the first frame update
    void Start()
    {

        DontDestroyOnLoad(this.gameObject);
        
        FB = GameObject.Find("FrienshipBarR");
        Friendship = 100.0f;
    }

    public int GetHunger() { return Hunger; }
    public void DecreaseHunger() { 

        if(Hunger > 0)
            Hunger -= 1; 
    }

    public int GetThirsty() { return Thirsty; }
    public void DecreaseThirsty()
    {
        if (Thirsty > 0)
            Thirsty -= 1;
    }
    public int Getsleep() { return sleep; }
    public float GetFriendship() { return Friendship; }
    public void ChangeFrienship(float change) {

        if (Friendship + change > 100.0f || Friendship + change < 0.0f)
            return;
        Friendship += change;
        float size = Friendship * 0.007f;
        float Pos = (100.0f - Friendship)*0.035f;
        Vector3 SVector = new Vector3(FB.transform.localScale.x, FB.transform.localScale.y, size);
        Vector3 CVector2 = new Vector3(FB.transform.localPosition.x, -Pos, FB.transform.localPosition.z);

        FB.transform.localScale = SVector;
        FB.transform.localPosition = CVector2;
    }
}
