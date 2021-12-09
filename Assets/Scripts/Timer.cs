using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private string playerName = "Default";
    
    private Leaderboard leaderboard;
    private float timer;
    private bool timeStopped = false;
    public string formattedTime = "00:00.000";
    
    private void Start()
    {
        timer = 0;
        leaderboard = this.GetComponent<Leaderboard>();

        playerName = Application.persistentDataPath.ToString().Replace("C:/Users/", "")
            .Replace("/AppData/LocalLow/DefaultCompany/Jaabni", "");
    }

    private void Update()
    {
        if(!timeStopped && !SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {
            if (!timerText.gameObject.activeSelf)
            {
                timerText.gameObject.SetActive(true);
            }
            timer += Time.deltaTime;
            formattedTime = FormatTime(timer);
            timerText.text = formattedTime;
        }
        else if(timerText.gameObject.activeSelf)
        {
            timerText.gameObject.SetActive(false);
        }
    }

    public void StopTimer()
    {
        if (!timeStopped)
        {
            timeStopped = true;
            var timeStop = timer;
            Debug.Log(timeStop);

            leaderboard.SaveEntry(playerName, timeStop);
        }
    }

    public string GetFormattedTime()
    {
        return this.formattedTime;
    }

    public static string FormatTime(float time)
    {
        var minutes=Mathf.Floor(time/60);
        var seconds = Mathf.Floor(time % 60);
        var milliseconds = (time * 1000) % 1000;
        return $"{minutes:00}:{seconds:00}.{milliseconds:000}";
    }
}
