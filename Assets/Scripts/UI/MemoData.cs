using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MemoData
{
    [SerializeField]
    public List<string> memos;

    [SerializeField]
    private List<string> achieveKeys;
    [SerializeField]
    private List<Achievement> achieveValues;

    public Dictionary<string, Achievement> achievements;

    public MemoData()
    {
        memos = new List<string>();
        achievements = new Dictionary<string, Achievement>();
    }

    public void OnBeforeSerialize()
    {
        achieveKeys = new List<string>(achievements.Keys);
        achieveValues = new List<Achievement>(achievements.Values);
    }

    public void OnAfterDeserialize()
    {
        if (achieveKeys.Count == achieveValues.Count)
        {
            achievements = new Dictionary<string,Achievement>();

            for (var index = 0; index < achieveKeys.Count; ++index)
            {
                achievements.Add(achieveKeys[index], achieveValues[index]);
            }
        }
    }
}

[Serializable]
public class Achievement
{
    public string name;
    public bool achieved = false;
    public bool read = false;
    public string content;
}
