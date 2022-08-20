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
    private Text soundText;
    private string lastText;

    [HideInInspector]
    public bool atDialog = false;

    public override void Init()
    {
        base.Init();
        if(givenState!=null)
        {
            atFlow = SoundingManager.instance.PutState(entityName, givenState.GetObject().TechnicalName);
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
        lastText = text;
        Invoke("TryFinishSound", 4);
    }

    //每句话说完
    public void TryFinishSound()
    {
        if(soundText.text == lastText)
        {
            FinishSound();
        }
    }

    public void FinishSound()
    {
        soundText.text = "";
    }

    private void AssignText()
    {
        sound = SoundingManager.instance.GetText();
        soundText = sound.GetComponent<Text>();
    }

    public void ReturnText()
    {
        soundText.text = "";
        sound = null;
        SoundingManager.instance.ReturnText(sound);
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

    public override void RaiseDialog()
    {
        StatePlayer statePlayer = atFlow as StatePlayer;
        if(statePlayer!=null)
        {
            statePlayer.PlayDialog();
        }
    }
}
