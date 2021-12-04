using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private string fileName = "leaderboard.sav";
    [SerializeField] private Text testText;

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

        testText.text = "";
        if (lbData.lbentries != null)
        {
            foreach (var lbE in lbData.lbentries)
            {
                testText.text += lbE.name + ": " + Timer.FormatTime(lbE.time) +"\n";
            }
        }
    }

    public void TestSave()
    {
        const float testTime = 90f;
        var ld = new LeaderboardData
        {
            lbentries = new List<LeaderboardData.LBentry>()
            {
                new LeaderboardData.LBentry()
                {
                    name = "Peter",
                    time = testTime
                },
                new LeaderboardData.LBentry()
                {
                    name = "Gustav",
                    time = testTime/2
                }
            }
        };

        var json = ld.ToJSON();
        Debug.Log(json);

        FileManager.WriteToFile(fileName, json);
    }
}