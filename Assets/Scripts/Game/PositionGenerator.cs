using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionGenerator : MonoBehaviour
{

    public Vector3 GenerateNewPosition(){
        float posx = Random.Range(-90,1090);
        float posz = Random.Range(-200,1100);
        float posy = Random.Range(120,600);
        return new Vector3(posx,posy,posz);
    }
}
