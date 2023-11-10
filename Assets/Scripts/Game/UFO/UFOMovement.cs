using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    private PositionGenerator pos_g;

    private Vector3 position;
    private Vector3 new_position;
    private float journey_length;
    private float start_time;    
    private float distCovered;
    private float frac_journey;    

    [SerializeField]
    [Range(25.0f,50.0f)]
    public float speed;  
    [SerializeField]
    private bool is_moving;


    private Vector3 direction;
    private float leaving_speed;
    private float time_to_change;
    private bool is_leaving;



    private float entering_speed;
    private bool is_entering;
    
    //control of states of the ufo
    public enum State{
        Idle,
        Moving,
        Leaving,
        Entering,
    }  

    public State state{get; protected set;}


    private float delay;
    private float time_elapsed;


    void Start(){
        pos_g = GameObject.Find("PositionGenerator").GetComponent<PositionGenerator>();
        start_time = Time.time;
        position = GetComponent<Transform>().position;
        state = State.Idle;        
    }

    void Update(){

        switch (state)
        {
            case State.Idle:
                IdleUFO();
                break;
            case State.Moving:
                MovingUFO();
                break;
            case State.Leaving:
                LeavingUFO();
                break;
            case State.Entering:
                EnteringUFO();
                break;           
        }        
        
    }

    private void IdleUFO(){
        
    }     


    private void MovingUFO(){
        if(is_moving){
            
            distCovered = (Time.time-start_time)*speed;
            frac_journey = distCovered/journey_length;
            transform.position = Vector3.Lerp(position, new_position, frac_journey);           
            
            if(Vector3.Distance(transform.position, new_position)<5){
                is_moving = false;
            }
        }
        else
        {
            if (new_position != Vector3.zero){
                position = new_position;
            }
            new_position = pos_g.GenerateNewPosition();
            journey_length = Vector3.Distance(position, new_position);
            start_time = Time.time;
            is_moving = true;
        }
    }
    private void LeavingUFO(){
        if (time_to_change<0.5f){
            direction = new Vector3(1,0,0);
            leaving_speed  = 2500;
        }
        else if (time_to_change<1){
            direction = new Vector3(0,1,0);
            leaving_speed = 5000;
        }
        else{
            this.gameObject.SetActive(false);
        } 
        time_to_change+=Time.deltaTime;      
        transform.Translate(direction*leaving_speed*Time.deltaTime);  
        
    }

    public void ResetValues(){
        is_moving = false;
        is_entering = false;
        is_leaving = false;
        position = GetComponent<Transform>().position;
        new_position = Vector3.zero;
    }

    

    public void EnteringUFO(){
        if (!is_entering){
            position = pos_g.GenerateNewPosition();
            direction = new Vector3(0,-1,0);
            entering_speed = 200;
            transform.position = new Vector3(position.x,position.y+200,position.z);
            is_entering = true;
        }
        else{
            if(Vector3.Distance(transform.position, position)>5){
                transform.Translate(direction*entering_speed*Time.deltaTime); 
                
            }
        }

         
        
    }

    public void SwitchToIdle(){
        state = State.Idle;
    }
    public void SwitchToMoving(){
        state = State.Moving;
    }
    public void SwitchToLeaving(){
        state = State.Leaving;
    }

    public void SwitchTOEntering(){
        state = State.Entering;
    }

    
}
