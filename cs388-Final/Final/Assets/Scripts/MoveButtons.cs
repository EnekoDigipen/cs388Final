using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtons : MonoBehaviour
{
    private bool move = false;
    private bool Goback = false;
    public double delay;
    public Vector3 position;
    private Vector3 OriginalPosition;
    private Vector3 destination;
    private string TimeStamp;
    TimeSystem Clock;
    // Start is called before the first frame update
    void Start()
    {
        
        Clock = GameObject.FindAnyObjectByType<TimeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move){

            if(Clock.TimeEllapsedGiven(TimeStamp) > delay){

                if(Goback == false && transform.localPosition.y < destination.y){

                    transform.localPosition = new Vector3(transform.localScale.x, transform.localScale.y + 0.1f, transform.localScale.z);
                }
                else if(Goback == true && transform.localPosition.y > destination.y){

                    transform.localPosition = new Vector3(transform.localScale.x, transform.localScale.y - 0.1f, transform.localScale.z);
                }
                else{

                    move = false;
                }
            }
        }
    }

    public void MoveButton(){

        move = true;
        TimeStamp = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
        if(Goback == true){

            destination = OriginalPosition;
        }
        else{

            destination = position;
        }
    }

    public bool IsMoving(){

        return move;
    }
}
