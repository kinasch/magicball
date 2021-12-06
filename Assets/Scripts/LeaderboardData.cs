using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LeaderboardData
{
    
    [System.Serializable]
    public struct LBentry
    {
        public string name;
        public float time;
    }

    public List<LBentry> lbentries;

    public string ToJSON()
    {
        return JsonUtility.ToJson(this);
    }

    public void FromJSON(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
}
