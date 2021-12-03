using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private string fileName = "leaderboard.sav";

    private float[] times;

    // Start is called before the first frame update
    void Start()
    {
        // TestSave();
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