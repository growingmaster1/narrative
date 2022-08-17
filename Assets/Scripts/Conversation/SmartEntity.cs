using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Articy.Unity;
using Articy.Unity.Interfaces;

/// <summary>
/// ������Ϸ�о�����Ϊ���ģ�����Ϊ���ŵĸ���
/// ���ᷢ�������ĸ��壨�绵����ˮ�ܣ�
/// </summary>
public class SmartEntity : GameEntity,IChatable, IArticyFlowPlayerCallbacks
{
    private Text sound;
    private string storedWords;
    public IArticyObject state;
    private ArticyFlowPlayer flowPlayer;
    private bool playing = false;

    private SmartEntity speaker;

    //ÿ�η����������øú�����������ÿ�仰�����һ��
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

    //ÿ�仰˵��
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

    //��ʼһ�������Ի�
    public void ArouseChat()
    {
        flowPlayer.StartOn = state;
        playing = true;
        //TODO:��ȡ���з����߲�������Ի�״̬
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
