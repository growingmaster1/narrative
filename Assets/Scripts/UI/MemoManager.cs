using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoManager : MonoBehaviour,IInit
{
    public static MemoManager instance;
    public static MemoData memoData;

    public List<GameObject> panelEntrance;
    public List<GameObject> panels;
    private GameObject panelOn;

    public GameObject memoContainer;
    public GameObject memoContent;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    public void Init()
    {
        memoData = new MemoData();
    }

    public void AddMemo(string memo)
    {
        memoData.memos.Add(memo);
        Instantiate(memoContent, memoContainer.transform);
        memoContent.GetComponent<Text>().text = memo;
    }

    public void UnlockAchievement(string achieve)
    {
        memoData.achievements[achieve].achieved = true;
    }

    public void ReadData()
    {
        //TODO:从JSON读入memo数据
    }

    public void SaveData()
    {
        //TODO:存储数据
    }
}
