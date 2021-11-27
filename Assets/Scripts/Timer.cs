using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;
    private float timer;
    private bool timeStopped = false;
    
    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        if(!timeStopped)
        {
            timer = Time.time;
            timerText.text = "Time: " + timer;
        }
    }

    public void StopTimer()
    {
        timeStopped = true;
        var timeStop = timer;
        Debug.Log(timeStop);
    }
}
