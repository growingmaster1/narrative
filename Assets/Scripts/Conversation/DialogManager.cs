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
    //�����Ի���ʵ��
    [HideInInspector]
    public GameEntity speaker;
    [HideInInspector]
    public string text;

    public GameObject branchButton;
    public GameObject branchParent;

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
        //�����ı�����
        DialogBox.instance.DefineSpeaker(speaker.name);
        DialogBox.instance.PrintText(text);
    }

    public void OnBranchesUpdated(IList<Branch> aBranches)
    {
        if(aBranches.Count==0)
        {
            DialogBox.instance.finishDialog();
            Player.instance.moveable = true;
            return;
        }

        foreach(Transform item in branchParent.transform)
        {
            Destroy(item.gameObject);
        }

        //�ҵ����д���SingleBranch���������ֵ
        for (int i = 0; i < aBranches.Count; ++i)
        {
            GameObject btn = Instantiate<GameObject>(branchButton);
            btn.transform.SetParent(branchParent.transform);

            btn.GetComponent<SingleBranch>().AssignBranch(aBranches[i]);
        }
    }

    public GameEntity DefineSpeaker(IFlowObject aObject)
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
