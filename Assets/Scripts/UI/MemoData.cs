using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MemoData
{
    [SerializeField]
    public Dictionary<string, MemoThemeData> memos;

    [SerializeField]
    public List<string> memoKeys;
    [SerializeField]
    private List<MemoThemeData> memoValues;

    [SerializeField]
    private List<string> achieveKeys;
    [SerializeField]
    private List<MemoThemeData> achieveValues;

    public Dictionary<string, MemoThemeData> achievements;

    public MemoData()
    {
        memos = new Dictionary<string, MemoThemeData>();
        achievements = new Dictionary<string, MemoThemeData>();
        memoKeys = new List<string>();
    }

    public void OnBeforeSerialize()
    {
        achieveKeys = new List<string>(achievements.Keys);
        achieveValues = new List<MemoThemeData>(achievements.Values);
    }

    public void OnAfterDeserialize()
    {
        if (achieveKeys.Count == achieveValues.Count)
        {
            achievements = new Dictionary<string, MemoThemeData>();

            for (var index = 0; index < achieveKeys.Count; ++index)
            {
                achievements.Add(achieveKeys[index], achieveValues[index]);
            }
        }
    }

    public void AddMemo(string theme, string memo)
    {
        if (!memos.ContainsKey(theme))
        {
            memos.Add(theme, new MemoThemeData());
            memoKeys.Add(theme);
        }
        memos[theme].memos.Add(memo);
    }
}

[Serializable]
public class MemoThemeData
{
    public string name;
    public bool achieved = false;
    public bool read = false;
    public List<string> memos = new List<string>();
}
