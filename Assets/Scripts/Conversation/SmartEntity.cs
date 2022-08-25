using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Articy.Unity;
using Articy.Unity.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

/// <summary>
/// ������Ϸ�о�����Ϊ���ģ�����Ϊ���ŵĸ���
/// ���ᷢ�������ĸ��壨�绵����ˮ�ܣ�
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

    //ÿ�η����������øú�����������ÿ�仰�����һ��
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

    //ÿ�仰˵��
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

    //��ʼһ�������Ի�
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
