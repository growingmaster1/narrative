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
public class SmartEntity : GameEntity
{
    public ArticyRef givenState;
    public GameObject soundPos;
    private GameObject sound;

    [HideInInspector]
    public string givenTechnicalName;
    private Text soundText;
    private Queue<string> lastText;

    public override void Init()
    {
        base.Init();
        lastText = new Queue<string>();
        if(givenState!=null&&givenState.GetObject()!=null)
        {
            givenTechnicalName = givenState.GetObject().TechnicalName;
            atFlow = SoundingManager.instance.PutState(entityName, givenTechnicalName);
            (atFlow as StatePlayer).StartSounding();
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
        soundText = sound.GetComponent<Text>();
    }

    public void ReturnText()
    {
        if(soundText!=null)
        {
            soundText.text = "";
            SoundingManager.instance.ReturnText(sound);
            sound.SetActive(false);
            sound = null;
        }
    }

    //开始一段旁听对话
    [Button]
    public void SetState(string stateTechName)
    {
        StatePlayer statePlayer = atFlow as StatePlayer;
        if(statePlayer!=null)
        {
            statePlayer.RemoveEntity(entityName);
        }
        else
        {

        }
        atFlow = SoundingManager.instance.PutState(entityName, stateTechName);
    }

    public void StartSounding()
    {
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
    }
}
