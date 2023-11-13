using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UFOManager : MonoBehaviour
{
    private List<GameObject> ufos = new List<GameObject>();
    private string ufo_tag = "UFO";
    private float delay;
    private int ufo_number;
    private RandomValueGenerator random;
    private bool is_playing;

    void Start(){
        random = GameObject.Find("RandomValueGenerator").GetComponent<RandomValueGenerator>();
        ufos = GetUfoList();
        delay = random.Generate2(5,20);
        ufo_number = random.Generate1(0, ufos.Count);
        is_playing = true;
        StartCoroutine(StateControl(delay, ufo_number));
    }

    IEnumerator StateControl(float delay, int ufo_number){
        
        while(is_playing){
            
            yield return new WaitForSeconds(delay);
            UFOMovement ufo_movement = ufos[ufo_number].GetComponent<UFOMovement>();
            switch(ufo_movement.state){
                case UFOMovement.State.Idle:
                    ChangeIdleUFO(ufo_movement);
                    break;
                case UFOMovement.State.Moving:
                    ufo_movement.ResetValues();
                    ChangeMovingUFO(ufo_movement);
                    break;
                case UFOMovement.State.Leaving:
                    ufo_movement.ResetValues();
                    ChangeLeavingUFO(ufo_movement);
                    break;
                case UFOMovement.State.Entering:
                    ufo_movement.ResetValues();
                    ChangeEnteringUFO(ufo_movement);
                    break;
            }
            ufo_number = random.Generate1(0, ufos.Count);
            delay = random.Generate2(5,20);
        }      

    }

    public void ChangeIdleUFO(UFOMovement ufo_movement){
        int state_number = random.Generate1(0,10);
        if(state_number < 9)
            ufo_movement.SwitchToMoving();
        else
            ufo_movement.SwitchToLeaving();
    }
    public void ChangeMovingUFO(UFOMovement ufo_movement){
        ufo_movement.SwitchToIdle();
    }

    public void ChangeLeavingUFO(UFOMovement ufo_movement){
        bool is_active = ufos[ufo_number].gameObject.activeInHierarchy;
        if(!is_active){
            ufos[ufo_number].SetActive(true);
            ufo_movement.SwitchTOEntering();
        }
    }

    public void ChangeEnteringUFO(UFOMovement ufo_movement){
        int state_number = random.Generate1(0,2);
        if(state_number == 0)
            ufo_movement.SwitchToIdle();
        else
            ufo_movement.SwitchToMoving();
    }

    private List<GameObject> GetUfoList(){
        GameObject[] ufos_array = GameObject.FindGameObjectsWithTag(ufo_tag);
        List<GameObject> ufos_list = new List<GameObject>();
        ufos_list.AddRange(ufos_array);
        return ufos_list;
    }
}
