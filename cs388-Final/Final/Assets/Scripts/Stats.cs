using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private float Friendship = 0.0f;
    private bool sleep = false;
    private int Thirsty = 0;
    private int Hunger = 0;
    private int Sick = 0;

    // Start is called before the first frame update
    void Start(){

        DontDestroyOnLoad(this.gameObject);
        ExtractStatsAppData();
    }
       
    //Get the hunger of the character
    public int GetHunger() {
        
        return Hunger; 
    }

    //Get the sleep of the character
    public bool Getsleep() {
        
        return sleep;
    }

    //Get the thirsty of the character
    public int GetThirsty() { 
        
        return Thirsty; 
    }

    //Get the sick stat of the character
    public int GetSick() { 
        
        return Sick; 
    }

    //Get the friendship of the character
    public float GetFriendship() { 

        return Friendship; 
    }

    //Get the sleep of the character
    public void Setsleep(bool NewState){

        sleep = NewState;
    }

    //Character was healed
    public void DecreaseSick(){

        if (Sick > 0){


            ChangeFrienship(3.0f);
            Sick -= 1;
        }
    }

    //Character was feed
    public void DecreaseHunger(){

        if (Hunger > 0){

            ChangeFrienship(3.0f);
            Hunger -= 1;
        }
    }

    //Character was given water
    public void DecreaseThirsty(){

        if (Thirsty > 0){
            
            ChangeFrienship(3.0f);
            Thirsty -= 1;
        }
    }

    //Character gets sick
    public void IncreaseSick() {

        if (Sick < 9) { 
        
            Sick += 1;
        }
    }

    //Character gets hungry
    public void IncreaseHunger()
    {

        if (Hunger < 9) { 
        
            Hunger += 1;
        }
    }

    //Character gets thirsty
    public void IncreaseThirsty()
    {

        if (Thirsty < 9) { 

            Thirsty += 1;
        }
}

    //Change the frienship bar
    public void ChangeFrienship(float change) {

        //change frienship
        Friendship += change;
        //make sure that it is between boundaries
        if (Friendship > 100.0f || Friendship < 0.0f) {

            Friendship = Mathf.Max(Friendship, 0.0f);
            Friendship = Mathf.Min(Friendship, 100.0f);
        }

        //store the stats
        PlayerPrefs.SetFloat("Frienship", Friendship);
    }

    //Retrieve the stored data
    public void ExtractStatsAppData(){

        // Hunger: 0-9
        // Thirsty: 0-9
        // Sick: 0-9
        // format: wxyz where w = sleep, x = Hunger, y = Thirsty, z = Sick
        int Stats = PlayerPrefs.GetInt("Stats", 0);

        //Get the stored frienship
        Friendship = PlayerPrefs.GetFloat("Frienship", 100.0f);
        if (Stats != 0){
            
            //sleep activated
            if(Stats >= 1000){

                Stats -= 1000;
                sleep = true;
            }
            //no hunger
            if(Stats < 100){

                //no thirsty
                if(Stats < 10){

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

    //Store the sats on AppData
    public void StoreStatsAppData(){

        // Hunger: 0-9
        // Thirsty: 0-9
        // Sick: 0-9
        // format: wxyz where w = sleep, x = Hunger, y = Thirsty, z = Sick
        int ValueToStore = Hunger * 100 + Thirsty * 10 + Sick;
        if(sleep == true){

            ValueToStore += 1000;
        }

        //store the stats
        PlayerPrefs.SetInt("Stats", ValueToStore);
    }
}
