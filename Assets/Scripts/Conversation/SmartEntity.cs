using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Articy.Unity;
using Articy.Unity.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;
using NodeCanvas.Framework;
using NodeCanvas.BehaviourTrees;

/// <summary>
/// 所有游戏中具有行为树的，有行为安排的个体
/// 亦或会发出旁听的个体（如坏掉的水管）
/// </summary>
public class SmartEntity : GameEntity
{
    public ArticyRef givenState;
    public GameObject soundPos;
    private GameObject sound;

    public bool Sounding = false;

    [HideInInspector]
    public string givenTechnicalName;
    private Text soundText;
    private Queue<string> lastText;

    public override void Init()
    {
        base.Init();
        if(dialog != null)
        {
            Debug.LogWarning("SmartEntity\"" + entityName + "\"存在Dialog，请检查是否正常。若想达成干预效果，请使用State进行管理");
        }
        lastText = new Queue<string>();
        if(givenState!=null&&givenState.GetObject()!=null)
        {
            givenTechnicalName = givenState.GetObject().TechnicalName;
            if(GetComponent<BehaviourTreeOwner>()==null)
            {
                SetState(givenTechnicalName);
            }
        }
    }

    private void Update()
    {
        if(sound!=null)
        {
            SoundingManager.instance.PutText(sound, soundPos.transform.position);
        }
    }

    //每次发出声音调用该函数，理论上每句话会调用一次
    public void ArouseSound(string text)
    {
        if (sound == null)
        {
            AssignText();
        }
        soundText.text = text;
        lastText.Enqueue(text);
        //SoundingManager.instance.PutText(sound, soundPos.transform.position);
        Invoke("TryFinishSound", 3);
    }

    //每句话说完
    public void TryFinishSound()
    {
        if(soundText.text == lastText.Dequeue())
        {
            FinishSound();
        }
    }

    public void FinishSound()
    {
        ReturnText();
    }

    private void AssignText()
    {
        sound = SoundingManager.instance.GetText();
        SoundingManager.instance.PutText(sound, soundPos.transform.position);
        soundText = sound.GetComponent<Text>();
    }

    public void ReturnText()
    {
        if(sound!=null)
        {
            soundText.text = "";
            SoundingManager.instance.ReturnText(sound);
            sound.SetActive(false);
            sound = null;
        }
    }

    public void SetState(string stateTechName)
    {
        StatePlayer statePlayer = atFlow as StatePlayer;
        if(statePlayer!=null && (!SoundingManager.instance.states.ContainsKey(stateTechName)||(SoundingManager.instance.states.ContainsKey(stateTechName) && SoundingManager.instance.states[stateTechName]!=statePlayer)))
        {
            statePlayer.RemoveEntity(entityName);
        }
        else
        {

        }
        givenTechnicalName = stateTechName;
        atFlow = SoundingManager.instance.PutState(entityName, stateTechName);
    }

    public void StopSounding()
    {
        Sounding = false;
    }

    public void StartPlaying()
    {
        Sounding = true;
    }

    public void StartSounding()
    {
        Sounding = true;
        (atFlow as StatePlayer).StartSounding();
    }

    public override void RaiseDialog()
    {
        if(!atDialog)
        {
            StatePlayer statePlayer = atFlow as StatePlayer;
            if (statePlayer != null)
            {
                statePlayer.PlayDialog();
            }
        }
        Player.instance.StopTrace();
    }

    public void ContinueChat()
    {
        (atFlow as StatePlayer)?.ContinueChat();
    }

    public void PauseChat()
    {
        (atFlow as StatePlayer)?.PauseChat();
    }

    public void StopChat()
    {
        (atFlow as StatePlayer)?.StopChat();
        StopSounding();
    }

    public void PlayOnce()
    {
        Sounding = true;
        (atFlow as StatePlayer)?.PlayOnce();
    }
}
