using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private int Hunger = 0;
    private int Thirsty = 0;
    private bool sleep = false;
    private int Sick = 0;

    private float Friendship = 0.0f;

    private GameObject FB;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);        
        FB = GameObject.Find("FrienshipBarR");
        Friendship = 100.0f;
        ExtractStatsAppData();
    }

    public int GetHunger() { return Hunger; }
    public void DecreaseHunger() { 

        if(Hunger > 0)
            Hunger -= 1; 
    }
    public void IncreaseHunger() { 

        if(Hunger < 9)
            Hunger += 1; 
    }

    public int GetThirsty() { return Thirsty; }
    public void DecreaseThirsty()
    {
        if (Thirsty > 0)
            Thirsty -= 1;
    }
    public void IncreaseThirsty() { 

        if(Thirsty < 9)
            Thirsty += 1; 
    }
    public bool Getsleep() { return sleep; }
    public int GetSick() { return Sick; }
    public void DecreaseSick()
    {
        if (Sick > 0)
            Sick -= 1;
    }
    public void IncreaseSick() { 

        if(Sick < 9)
            Sick += 1; 
    }
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
    public void ExtractStatsAppData(){

        // Hunger: 0-9
        // Thirsty: 0-9
        // Sick: 0-9
        // format: xyz where  w = sleep, x = Hunger, y = Thirsty, z = Sick
        string StatsText = PlayerPrefs.GetString("Stats", "No Stats");
        Debug.Log("" + StatsText);
        if(StatsText != "No Stats"){

            int Stats = int.Parse(StatsText);
            
            if(Stats >= 1000){

                Stats -= 1000;
                sleep = true;
            }
            if(Stats < 100){

                if(Stats < 10){

                    if(Stats == 0){

                        return;
                    }

                    Sick = Stats;
                    return;
                }

                Thirsty = Stats / 10;                
                Sick = Stats % 10;
                return;
            }

            Hunger = Stats / 100;
            Thirsty = (Stats % 100) / 10; 
            Sick = (Stats % 100) % 10;
            return;
        }
    }
    public void StoreStatsAppData(){

        // Hunger: 0-9
        // Thirsty: 0-9
        // Sick: 0-9
        // format: wxyz where w = sleep, x = Hunger, y = Thirsty, z = Sick
        int ValueToStore = Hunger * 100 + Thirsty * 10 + Sick;
        if(sleep == true){

            ValueToStore += 1000;
        }
        PlayerPrefs.SetString("Stats", ValueToStore.ToString());
        string ToApp = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
    }
}
