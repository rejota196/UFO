using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cam1 : MonoBehaviour
{
    public CinematicControl cine;
    void Start(){
        cine.Start_second_part();
    }   
}
