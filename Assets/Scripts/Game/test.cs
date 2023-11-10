using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class test : MonoBehaviour
{
    TimePeriod timePeriod;
    void Start(){
        timePeriod = new TimePeriod();
        //timePeriod.Hours = 2;
        Debug.Log(timePeriod.Hours);
    }      
}

public class TimePeriod
{
    private double _seconds;

    public double Hours
    {
        get { return _seconds / 3600; }
        protected set
        {
            if (value < 0 || value > 24)
                throw new ArgumentOutOfRangeException(nameof(value),
                      "The valid range is between 0 and 24.");

            _seconds = value * 3600;
        }
    }

    private void ChangeHours(){
        Hours = 10;
    }
}
