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
public class DialogManager : MonoBehaviour,IArticyFlowPlayerCallbacks,IInit
{
    public GameEntity speaker;
    public string text;
    public static DialogManager instance;
    public static ArticyFlowPlayer flowPlayer;

    public void Init()
    {
        if(instance == null)
        {
            instance = this;
        }

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
        //确定文本
        text = DefineText(aObject);
        //TODO:处理文本输入
    }

    public void OnBranchesUpdated(IList<Branch> aBranches)
    {
        //TODO:找到所有带有SingleBranch的组件并赋值
    }

    public GameEntity DefineSpeaker(IFlowObject aObject)
    {
        var withSpeaker = aObject as IObjectWithSpeaker;
        if (withSpeaker != null)
        {
            var speakerEntity = withSpeaker.Speaker as IObjectWithDisplayName;
            if (EntityData.EntitiesDic.ContainsKey(speakerEntity.DisplayName))
            {
                return EntityData.EntitiesDic[speakerEntity.DisplayName];
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
                if(EntityData.EntitiesDic.ContainsKey(withDisplayName.DisplayName))
                {
                    return EntityData.EntitiesDic[withDisplayName.DisplayName];
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
        flowPlayer.StartOn = start;
    }
}
