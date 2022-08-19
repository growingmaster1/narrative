using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Articy.Unity;
using Articy.Unity.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

/// <summary>
/// 所有游戏中具有行为树的，有行为安排的个体
/// 亦或会发出旁听的个体（如坏掉的水管）
/// </summary>
public class SmartEntity : GameEntity, IMyFlowPlayer
{
    public ArticyRef givenSounding;
    public GameObject soundPos;
    private GameObject sound;
    private Text soundText;
    private string storedWords;
    public IArticyObject state;
    public ArticyFlowPlayer flowPlayer { get; set; }
    public List<SmartEntity> speakers { get; set; }

    private bool playing = false;
    private SmartEntity playLock = null;

    private List<ArticyObject> attachedDialog;
    private int attachTalkPlace;

    private bool blocked = false;

    private SmartEntity speaker;

    public override void Init()
    {
        base.Init();
        state = givenSounding.GetObject();
        flowPlayer = GetComponent<ArticyFlowPlayer>();
        speakers = new List<SmartEntity>();
    }

    private void Update()
    {
        if(sound!=null)
        {
            SoundingManager.instance.PutText(sound, soundPos.transform.position);
        }
    }

    //每次发出声音调用该函数，理论上每句话会调用一次
    public bool ArouseSound(string text)
    {
        if(sound == null)
        {
            AssignText();
        }
        if(soundText.text=="")
        {
            soundText.text = text;
            Invoke("FinishSound", 2);
            return true;
        }
        else
        {
            storedWords = text;
            return false;
        }
    }

    //每句话说完
    public void FinishSound()
    {
        soundText.text = "";
        if(storedWords!="")
        {
            ArouseSound(storedWords);
            storedWords = "";
            Invoke("ContinueChat", 1);
        }
        else
        {
            soundText.text = "";
            //SoundingManager.instance.ReturnText(sound);
        }
    }

    private void AssignText()
    {
        sound = SoundingManager.instance.GetText();
        soundText = sound.GetComponent<Text>();
    }

    public void ReturnText()
    {
        soundText.text = "";
        sound = null;
        SoundingManager.instance.ReturnText(sound);
    }

    public void SetFlow(IMyFlowPlayer flow)
    {
        atFlow = flow;
    }

    public void CompleteChat()
    {
        foreach(SmartEntity item in speakers)
        {
            item.ReturnText();
            item.SetFlow(null);
        }
    }

    public void ExitFlow()
    {
        atFlow.speakers.Remove(this);
        atFlow = null;
    }

    //开始一段旁听对话
    [Button]
    public void SetState(string stateTechName)
    {
        //if(state != ArticyDatabase.GetObject(stateTechName))
        //{
            //state = ArticyDatabase.GetObject(stateTechName);
            IObjectWithAttachments attached = state as IObjectWithAttachments;
            if (attached != null)
            {
                attachedDialog = attached.Attachments;
                attachTalkPlace = 0;
                dialog = attachedDialog[attachTalkPlace];
            }
            flowPlayer.StartOn = state;
        //}
        blocked = false;
        playing = true;
        //TODO:获取所有发言者并设置其对话状态
    }

    public void OnFlowPlayerPaused(IFlowObject aObject)
    {
        playing = true;
        if (aObject == null)
        {
            Debug.Log("Warning: aObject is null");
            return;
        }

        speaker = DialogManager.instance.DefineSpeaker(aObject) as SmartEntity;
        if (speaker == null)
        {
            Debug.Log("talking to " + DialogManager.instance.DefineSpeaker(aObject).entityName + " is wooden");
            return;
        }
        if (!speaker.ArouseSound(DialogManager.instance.DefineText(aObject)))
        {
            playing = false;
        }
        if(speaker.atFlow == null)
        {
            speaker.SetFlow(this);
            speakers.Add(speaker);
        }
    }

    public void OnBranchesUpdated(IList<Branch> aBranches)
    {
        if(playing)
        {
            if(aBranches.Count<1)
            {
                flowPlayer.FinishCurrentPausedObject();
                flowPlayer.StartOn = null;
            }
            else
            {
                Invoke("PlayChat", 1);
            }
        }
        else
        {
            LockChat(speaker);
        }
    }

    public void PlayChat()
    {
        if(!blocked)
        {
            flowPlayer.Play();
        }
    }

    public void ContinueChat()
    {
        SmartEntity flow = atFlow as SmartEntity;
        if(flow != null)
        {
            if(flow.playLock == this)
            {
                flow.playLock = null;
                flow.playing = true;
                flow.PlayChat();
            }
        }
    }

    private void LockChat(SmartEntity lockAt)
    {
        playLock = lockAt;
    }

    public override void RaiseDialog()
    {
        if (dialog != null)
        {
            blocked = true;
            if (atFlow!=null)
            {
                (atFlow as SmartEntity).blocked = true;
            }
            DialogManager.instance.SetStart(dialog as IArticyObject);
            if(attachTalkPlace+1<attachedDialog.Count)
            {
                attachTalkPlace++;
            }
            
            Player.instance.moveable = false;
        }
    }
}
