using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Unity.Interfaces;

/// <summary>
/// ע�⣺���಻�����жԻ��Ĺ�������
/// ����ĶԻ�ָ������Ϸ�����еģ���Һ�NPC�ĶԻ�ϵͳ�������������ͱ���¼
/// �ɶԻ�ר�öԻ�����в���
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

        //ȷ��˵����
        speaker = DefineSpeaker(aObject);
        //ȷ���ı�
        text = DefineText(aObject);
        //TODO:�����ı�����
    }

    public void OnBranchesUpdated(IList<Branch> aBranches)
    {
        //TODO:�ҵ����д���SingleBranch���������ֵ
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
