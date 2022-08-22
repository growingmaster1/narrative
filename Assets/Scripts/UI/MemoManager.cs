using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MemoManager : MonoBehaviour,IInit
{
    public static MemoManager instance;
    public static MemoData memoData;

    public List<GameObject> panelEntrance;
    public List<GameObject> panels;
    private GameObject panelOn;

    public GameObject memoContainer;
    public GameObject memoContent;

    public GameObject memoMessage;

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
        ShowMessage("您有新的备忘录");
    }

    private void ShowMessage(string message)
    {
        memoMessage.GetComponent<Text>().text = message;
        Sequence messageSeq = DOTween.Sequence();
        memoMessage.SetActive(true);
        messageSeq.Append(memoMessage.transform.DOMove(memoMessage.transform.position + Vector3.up, 0.2f).From());
        messageSeq.Join(memoMessage.GetComponent<Text>().DOFade(1, 0.2f));
        messageSeq.AppendInterval(2);
        messageSeq.Append(memoMessage.transform.DOMove(memoMessage.transform.position + Vector3.up, 0.2f).OnComplete(()=> { memoMessage.SetActive(false); }));
        messageSeq.Join(memoMessage.GetComponent<Text>().DOFade(0, 0.2f));
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
