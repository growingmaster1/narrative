using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MemoManager : MonoBehaviour,IInit
{
    public static MemoManager instance;

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

    public Dictionary<string, MemoThemeData> memos = new Dictionary<string, MemoThemeData>();
    public List<string> memoKeys = new List<string>();

    public Dictionary<string, MemoThemeData> achievements = new Dictionary<string, MemoThemeData>();
    public List<string> achieveKeys = new List<string>();

    public MemoTheme onTheme;
    public MemoTheme onAchieve;

    public GameObject memoMessage;
    private Queue<string> messages = new Queue<string>();
    private bool messageOn = false;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    public void Init()
    {
        panelOn = "memo";
        AddMemo("我想交朋友-好想交朋友啊");
        AddMemo("迷迭小镇-我住在A区");
        ReadAchievements();
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

        memoMessage.SetActive(false);
        messages.Clear();
        messageOn = false;

        panelOn = "memo";
        ReadThemes();
        ReadContents();
    }

    public void ShutPanel()
    {
        int i = 0;
        for (i = 0; i < hidUI.Count; ++i)
        {
            hidUI[i].SetActive(true);
        }
        greyPanel.SetActive(false);
        memoView.SetActive(false);
        TimeManager.instance.ContinueTime();
    }

    public void SwitchPanel(string panelName)
    {
        panelOn = panelName;
        ReadThemes();
        ReadContents();
    }

    public void ReadAchievements()
    {
        TextAsset jsonText = Resources.Load<TextAsset>("achievements");
        AchievementData achievementData = JsonUtility.FromJson<AchievementData>(jsonText.text);
        foreach(Achievement item in achievementData.achievements)
        {
            achieveKeys.Add(item.name);
            achievements.Add(item.name, new MemoThemeData());
            achievements[item.name].name = item.name;
            achievements[item.name].memos.Add(item.content);
        }
    }

    public void ReadThemes()
    {
        foreach (Transform item in memoThemeContainer.transform)
        {
            Destroy(item.gameObject);
        }
        List<string> onKeys = panelOn == "memo" ? memoKeys : achieveKeys;
        Dictionary<string, MemoThemeData> onDic = panelOn == "memo" ? memos : achievements;
        foreach (string item in onKeys)
        {
            GameObject theme = Instantiate(memoTheme);
            theme.transform.SetParent(memoThemeContainer.transform);
            theme.GetComponent<MemoTheme>().AssignData(onDic[item]);
            if (item == onKeys[0])
            {
                theme.GetComponent<MemoTheme>().Select();
                onTheme = theme.GetComponent<MemoTheme>();
            }
            theme.GetComponent<Text>().text = item;
        }
    }

    public void ReadContents()
    {
        foreach (Transform item in memoContent.transform)
        {
            Destroy(item.gameObject);
        }
        Dictionary<string, MemoThemeData> onDic = panelOn == "memo" ? memos : achievements;
        foreach (string item in onDic[onTheme.themeName].memos)
        {
            GameObject memo = Instantiate(memoUnit);
            memo.transform.SetParent(memoContent.transform);
            memo.GetComponent<Text>().text = item;
        }
        contentScroll.verticalNormalizedPosition = 1;
    }

    public void AddMemo(string newMemo)
    {
        string theme = newMemo.Split("-")[0];
        string memo = newMemo.Split("-")[1];
        if (!memos.ContainsKey(theme))
        {
            memos.Add(theme, new MemoThemeData());
            memoKeys.Add(theme);
            memos[theme].name = theme;
        }
        memos[theme].memos.Add(memo);
        memos[theme].read = false;
        messages.Enqueue("您在\"" + theme + "\"下有新的备忘录");
        if(!messageOn)
        {
            ShowMessage();
        }
    }

    public void SwitchTheme(MemoTheme theme)
    {
        Dictionary<string, MemoThemeData> onDic = panelOn == "memo" ? memos : achievements;
        if (theme != onTheme)
        {
            onTheme.UnSelect();
            onTheme = theme;
            onDic[onTheme.themeName].read = true;
            ReadContents();
        }
    }

    private void ShowMessage()
    {
        if(messageOn)
        {
            return;
        }
        messageOn = true;
        Vector3 initPos = memoMessage.transform.position;
        memoMessage.GetComponent<Text>().text = messages.Dequeue();
        Sequence messageSeq = DOTween.Sequence().SetUpdate(true);
        memoMessage.SetActive(true);
        messageSeq.Append(memoMessage.GetComponent<Text>().DOFade(0, 0));
        messageSeq.Append(memoMessage.transform.DOMove(memoMessage.transform.position + Vector3.up * 30, 0.2f).From());
        messageSeq.Join(memoMessage.GetComponent<Text>().DOFade(1, 0.2f));
        messageSeq.AppendInterval(2);
        messageSeq.Append(memoMessage.transform.DOMove(memoMessage.transform.position + Vector3.up * 30, 0.2f).OnComplete(()=> {
            memoMessage.transform.position = initPos;
            memoMessage.SetActive(false);
            messageOn = false;
            if(messages.Count>0)
            {
                ShowMessage();
            }
        }));
        messageSeq.Join(memoMessage.GetComponent<Text>().DOFade(0, 0.2f));
    }

    public void UnlockAchievement(string achieve)
    {
        achievements[achieve].achieved = true;
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
