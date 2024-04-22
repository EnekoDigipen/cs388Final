using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    public int[] Date = new int[3];
    public int[] Time = new int[2];
    public string DateText;
    // Start is called before the first frame update
    void Start()
    {
        DateText = PlayerPrefs.GetString("Date", "No Date");
        if(DateText == "No Date"){

            StoreCurrentTime();
        }
        else{

            int[] ConvertedDate = ConvertStringToDate(DateText);
            for(int i = 0; i < 3; i++){
            
                Date[i] = ConvertedDate[i];
            }
            for(int i = 0; i < 2; i++){
            
                Time[i] = ConvertedDate[i+3];
            }
        }
        //delete later
        StoreCurrentTime();
    }

    public int[] ConvertStringToDate(string time){

        int[] Out = new int[5];
        if (string.IsNullOrEmpty(time)){

            return Out;
        }
        for (int i = 0; i < 2; i++){

            string result = time.Substring(i * 3, 2);
            Out[i] = int.Parse(result);
        }
        {
            string result = time.Substring(6, 4);
            Out[2] = int.Parse(result);
        }
        for (int i = 0; i < 2; i++){

            string result = time.Substring(11 + (i * 3), 2);
            Out[i+3] = int.Parse(result);
        }
        
        return Out;
    }
    public void StoreCurrentTime(){
        
        DateText = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
        int[] ConvertedDate = ConvertStringToDate(DateText);
        for(int i = 0; i < 3; i++){
            
            Date[i] = ConvertedDate[i];
        }
        for(int i = 0; i < 2; i++){
            
            Time[i] = ConvertedDate[i+3];
        }
    }
    public double TimeEllapsed(){
        
        System.DateTime time1 = new System.DateTime(Date[2], Date[1], Date[0], Time[0], Time[1], 0, System.DateTimeKind.Utc);        
        string Current = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
        int[] ConvertedDate = ConvertStringToDate(Current);
        System.DateTime time2 = new System.DateTime(ConvertedDate[2], ConvertedDate[1], ConvertedDate[0], ConvertedDate[3], ConvertedDate[4], 0, System.DateTimeKind.Utc);
        
        System.TimeSpan diferencia =  time2 - time1;
        return diferencia.TotalMinutes;
    }
    public void StoreTimeAppData(){

        string ToApp = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
        PlayerPrefs.SetString("Date", ToApp);
    }
}
