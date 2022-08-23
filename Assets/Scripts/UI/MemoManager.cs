using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MemoManager : MonoBehaviour,IInit
{
    public static MemoManager instance;
    public static MemoData memoData;

    public GameObject greyPanel;
    public List<GameObject> toHideUI;
    private List<GameObject> hidUI;
    public GameObject memoView;

    //public GameObject memoPanel;
    //public GameObject achievePanel;
    private string panelOn;

    public ScrollRect themeScroll;
    public ScrollRect contentScroll;
    public GameObject memoThemeContainer;
    public GameObject memoContent;
    public GameObject memoTheme;
    public GameObject memoUnit;

    public MemoTheme onTheme;
    public MemoTheme onAchieve;

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
        panelOn = "memo";
        memoData.AddMemo("���뽻����", "���뽻���Ѱ�");
        memoData.AddMemo("�Ե�С��", "��ס��A��");
        hidUI = new List<GameObject>();
    }

    public void OpenPanel()
    {
        int i = 0;
        hidUI.Clear();
        for(i=0;i<toHideUI.Count;++i)
        {
            if(toHideUI[i].activeInHierarchy)
            {
                toHideUI[i].SetActive(false);
                hidUI.Add(toHideUI[i]);
            }
        }
        greyPanel.SetActive(true);
        memoView.SetActive(true);
        TimeManager.instance.PauseTime();

        ReadThemes();
        ReadContents();
    }

    public void ShutPanel()
    {
        int i = 0;
        for (i = 0; i < toHideUI.Count; ++i)
        {
            hidUI[i].SetActive(true);
        }
        greyPanel.SetActive(false);
        memoView.SetActive(false);
        TimeManager.instance.ContinueTime();
    }

    public void SwitchPanel()
    {

    }

    public void ReadThemes()
    {
        foreach(Transform item in memoThemeContainer.transform)
        {
            Destroy(item.gameObject);
        }
        if(panelOn == "memo")
        {
            foreach(string item in memoData.memoKeys)
            {
                GameObject theme = Instantiate(memoTheme);
                theme.transform.SetParent(memoThemeContainer.transform);
                theme.GetComponent<MemoTheme>().AssignName(item);
                if(item == memoData.memoKeys[0])
                {
                    theme.GetComponent<MemoTheme>().Select();
                    onTheme = theme.GetComponent<MemoTheme>();
                }
                theme.GetComponent<Text>().text = item;
            }
        }
    }

    public void ReadContents()
    {
        foreach (Transform item in memoContent.transform)
        {
            Destroy(item.gameObject);
        }
        if (panelOn == "memo")
        {
            foreach (string item in memoData.memos[onTheme.themeName].memos)
            {
                GameObject memo = Instantiate(memoUnit);
                memo.transform.SetParent(memoContent.transform);
                memo.GetComponent<Text>().text = item;
            }
        }
        contentScroll.verticalNormalizedPosition = 1;
    }

    public void AddMemo(string newMemo)
    {
        string theme = newMemo.Split("-")[0];
        string memo = newMemo.Split("-")[1];
        memoData.AddMemo(theme, memo);
        ShowMessage("����\""+theme+"\"�����µı���¼");
    }

    public void SwitchTheme(MemoTheme theme)
    {
        if(panelOn == "memo")
        {
            if(theme!=onTheme)
            {
                onTheme.UnSelect();
                onTheme = theme;
                ReadContents();
            }
        }
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
        //TODO:��JSON����memo����
    }

    public void SaveData()
    {
        //TODO:�洢����
    }
}
