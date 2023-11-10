using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Cam2 : MonoBehaviour
{
    public CinematicControl cine;
    void Start(){
        cine.Load_title_scene();
    }   
}
