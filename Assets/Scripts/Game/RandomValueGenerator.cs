using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomValueGenerator : MonoBehaviour
{
    public int Generate1(float initial_value, float final_value){
        return (int)Random.Range(initial_value, final_value);
    }
    public float Generate2(float initial_value, float final_value){
        return Random.Range(initial_value, final_value);
    }
}
