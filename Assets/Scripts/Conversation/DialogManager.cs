using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Unity.Interfaces;

/// <summary>
/// 注意：该类不是所有对话的管理器！
/// 这里的对话指的是游戏中特有的，玩家和NPC的对话系统，不包括旁听和备忘录
/// 由对话专用对话框进行播放
/// </summary>
public class DialogManager : MonoBehaviour,IMyFlowPlayer,IInit
{
    //发出对话的实体
    [HideInInspector]
    public IWithEntity speaker;
    [HideInInspector]
    public string text;

    public static DialogManager instance;
    public static ArticyFlowPlayer FlowPlayer;
    public ArticyFlowPlayer flowPlayer
    {
        get
        {
            return FlowPlayer;
        }
        set
        {
            FlowPlayer = value;
        }
    }

    public List<SmartEntity> speakers { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Init()
    {
        speakers = new List<SmartEntity>();
        flowPlayer = GetComponent<ArticyFlowPlayer>();
        if(flowPlayer == null)
        {
            Debug.Log("Error: FlowPlayer hasn't onload");
        }
    }

    public void OnFlowPlayerPaused(IFlowObject aObject)
    {
        if(aObject == null)
        {
            Debug.Log("Warning: aObject is null");
            return;
        }

        //确定说话人
        speaker = DefineSpeaker(aObject);
        SmartEntity speakEntity = speaker as SmartEntity;
        if(speakEntity!=null&&!speakers.Contains(speakEntity))
        {
            speakers.Add(speakEntity);
            speakEntity.SetFlow(this);
        }
        //确定文本
        text = DefineText(aObject);
        //处理文本输入
        DialogBox.instance.DefineSpeaker(speaker.entityName);
        DialogBox.instance.PrintText(text);
    }

    public void OnBranchesUpdated(IList<Branch> aBranches)
    {
        DialogBox.instance.ParseBranches(aBranches);
    }

    public void CompleteDialog()
    {
        foreach (SmartEntity item in speakers)
        {
            item.SetFlow(null);
        }
    }

    public IWithEntity DefineSpeaker(IFlowObject aObject)
    {
        var withSpeaker = aObject as IObjectWithSpeaker;
        if (withSpeaker != null)
        {
            var speakerEntity = withSpeaker.Speaker as IObjectWithDisplayName;
            if (EntityManager.EntitiesDic.ContainsKey(speakerEntity.DisplayName))
            {
                return EntityManager.EntitiesDic[speakerEntity.DisplayName];
            }
            else
            {
                Debug.Log("Warning: NPC " + speakerEntity.DisplayName + " doesn't exist");
            }
        }
        else
        {
            var withDisplayName = aObject as IObjectWithDisplayName;
            if (withDisplayName != null)
            {
                if(EntityManager.EntitiesDic.ContainsKey(withDisplayName.DisplayName))
                {
                    return EntityManager.EntitiesDic[withDisplayName.DisplayName];
                }
            }
        }
        return null;
    }

    public string DefineText(IFlowObject aObject)
    {
        return (aObject as IObjectWithText)?.Text;
    }

    public void SetStart(IArticyObject start)
    {
        DialogBox.instance.startDialog();
        flowPlayer.StartOn = start;
    }
}
