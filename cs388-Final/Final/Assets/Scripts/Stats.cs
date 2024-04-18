using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private int Hunger = 0;
    private int Thirsty = 0;
    private int sleep = 0;
    private float Friendship = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

        DontDestroyOnLoad(this.gameObject);
    }

    public int GetHunger() { return Hunger; }
    public int GetThirsty() { return Thirsty; }
    public int Getsleep() { return sleep; }
    public float GetFriendship() { return Friendship; }
    public void ChangeFrienship(float change) {

        if (change < 0.0f)
        {
            //encojer
            //mover hacia abajo change/2.0f
        }
        else{
            
            //crecer
            //mover hacia arribe change/2.0f
        }
    }
}
