using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private string fileName = "leaderboard.sav";
    [SerializeField] private TMP_Text[] textFields;

    private float[] times;
    private LeaderboardData lbData;

    // Start is called before the first frame update
    void Start()
    {
        lbData = new LeaderboardData();
        // TestSave();
        if (FileManager.FileExists(fileName))
        {
            lbData.FromJSON(FileManager.LoadFromFile(fileName));
        }
    }

    public void UpdateLeaderboardText()
    {
        foreach (var textField in textFields)
        {
            textField.text = "";
        }
        if (lbData.lbentries != null)
        {
            SortAndLimitLeaderboard(lbData);
            var i = 1;
            foreach (var lbE in lbData.lbentries)
            {
                textFields[0].text +=  ""+i+".\n";
                textFields[1].text += lbE.name + "\n";
                textFields[2].text += Timer.FormatTime(lbE.time) + "\n";
                i++;
            }
        }
    }
    
    public void SaveEntry(string playerName, float playerTime)
    {
        if (lbData.lbentries == null)
        {
            lbData.lbentries = new List<LeaderboardData.LBentry>();
        }
        lbData.lbentries.Add(new LeaderboardData.LBentry()
        {
            name = playerName,
            time = playerTime
        });

        var json = lbData.ToJSON();
        Debug.Log(json);

        FileManager.WriteToFile(fileName, json);
    }

    // Sorts the leaderboard by fastest time and deletes all entries after the tenth.
    private void SortAndLimitLeaderboard(LeaderboardData ld)
    {
        ld.lbentries.Sort((entry1, entry2) =>
        {
            var compare = entry1.time >= entry2.time ? 1 : -1;
            return compare;
        });

        if (ld.lbentries.Count > 10)
        {
            for (int i = 10; i < ld.lbentries.Count; i++)
            {
                ld.lbentries.Remove(ld.lbentries[i]);
            }
        }
    }
}