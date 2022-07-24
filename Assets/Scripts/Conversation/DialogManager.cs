using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Unity.Interfaces;

public class DialogManager : MonoBehaviour,IArticyFlowPlayerCallbacks,IInit
{
    private SpeakInfo info;
    public ISpeak speaker;
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

        DefineSpeaker(aObject);
        DefineText(aObject);
        PrintWords();
    }

    public void OnBranchesUpdated(IList<Branch> aBranches)
    {
        if(aBranches.Count<2)
        {
            return;
        }

        //TODO:找到所有带有SingleBranch的组件并赋值
    }

    private void DefineSpeaker(IFlowObject aObject)
    {
        var withSpeaker = aObject as IObjectWithSpeaker;
        if (withSpeaker != null)
        {
            var speakerEntity = withSpeaker.Speaker as IObjectWithDisplayName;
            if (EntityData.NPCDic.ContainsKey(speakerEntity.DisplayName))
            {
                info.speaker = EntityData.NPCDic[speakerEntity.DisplayName];
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
                if(EntityData.NPCDic.ContainsKey(withDisplayName.DisplayName))
                {
                    info.speaker = EntityData.NPCDic[withDisplayName.DisplayName];
                }
            }
            else
            {
                info.speaker = null;
            }
        }
    }

    private void DefineText(IFlowObject aObject)
    {
        info.words = (aObject as IObjectWithText)?.Text;
    }

    private void PrintWords()
    {
        speaker.speak(info);
    }
}
