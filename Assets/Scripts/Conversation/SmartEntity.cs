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

    //ÿ�η����������øú�����������ÿ�仰�����һ��
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

    //ÿ�仰˵��
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

    public override void RaiseDialog()
    {
        StatePlayer statePlayer = atFlow as StatePlayer;
        if(statePlayer!=null)
        {
            statePlayer.PlayDialog();
        }
    }
}
