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
public class DialogManager : MonoBehaviour,IMyFlowPlayer,IInit
{
    //�����Ի���ʵ��
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

        //ȷ��˵����
        speaker = DefineSpeaker(aObject);
        SmartEntity speakEntity = speaker as SmartEntity;
        if(speakEntity!=null&&!speakers.Contains(speakEntity))
        {
            speakers.Add(speakEntity);
            speakEntity.SetFlow(this);
        }
        //ȷ���ı�
        text = DefineText(aObject);
        //�����ı�����
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
