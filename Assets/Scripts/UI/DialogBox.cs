using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour,IInit
{
    public static DialogBox instance;
    public GameObject joystick;
    public GameObject dialogBox;
    public GameObject buttonHolder;
    public GameObject continueButton;
    public Text speaker;
    public Text text;
    private float speekSpeed = 0.1f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Init()
    {

    }

    public void startDialog()
    {
        joystick.SetActive(false);
        dialogBox.SetActive(true);
    }

    public void finishDialog()
    {
        TimeManager.instance.ContinueTime();
        joystick.SetActive(true);
        dialogBox.SetActive(false);
    }

    public void DefineSpeaker(string inSpeaker)
    {
        speaker.text = inSpeaker;
    }

    public void PrintText(string content)
    {
        TimeManager.instance.ContinueTime();
        text.DOText(content, content.Length * speekSpeed).OnComplete(TimeManager.instance.PauseTime);
    }
}
