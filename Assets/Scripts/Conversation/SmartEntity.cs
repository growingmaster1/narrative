using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Articy.Unity;
using Articy.Unity.Interfaces;

/// <summary>
/// 所有游戏中具有行为树的，有行为安排的个体
/// 亦或会发出旁听的个体（如坏掉的水管）
/// </summary>
public class SmartEntity : GameEntity,IChatable, IArticyFlowPlayerCallbacks
{
    private Text sound;
    private string storedWords;
    public IArticyObject state;
    private ArticyFlowPlayer flowPlayer;
    private bool playing = false;

    private SmartEntity speaker;

    //每次发出声音调用该函数，理论上每句话会调用一次
    public bool ArouseSound(string text)
    {
        if(sound.text=="")
        {
            sound.text = text;
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
        sound.text = "";
        if(storedWords!="")
        {
            storedWords = "";
            ArouseSound(storedWords);
            Invoke("ContinueChat", 1);
        }
    }

    //开始一段旁听对话
    public void ArouseChat()
    {
        flowPlayer.StartOn = state;
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
        }
        if (!speaker.ArouseSound(DialogManager.instance.DefineText(aObject)))
        {
            playing = false;
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
                Invoke("ContinueChat", 1);
            }
        }
    }

    public void ContinueChat()
    {
        SmartEntity flow = atFlow as SmartEntity;
        if(flow != null)
        {
            flow.playing = true;
            flow.flowPlayer.Play();
        }
    }
}
