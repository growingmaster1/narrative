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

    private Vector3 continueButtonStart;
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
        continueButtonStart = continueButton.transform.position;
    }

    public void startDialog()
    {
        joystick.SetActive(false);
        dialogBox.SetActive(true);
        dialogBox.transform.DOMove(dialogBox.transform.position + new Vector3(dialogBox.GetComponent<RectTransform>().rect.width, 0, 0), 0.2f).From();
    }

    public void finishDialog()
    {
        TimeManager.instance.ContinueTime();
        joystick.SetActive(true);
        dialogBox.SetActive(false);
        dialogBox.transform.DOMove(dialogBox.transform.position + new Vector3(dialogBox.GetComponent<RectTransform>().rect.width, 0, 0), 0.2f);
    }

    public void DefineSpeaker(string inSpeaker)
    {
        speaker.text = inSpeaker;
    }

    public void PrintText(string content)
    {
        continueButton.SetActive(false);
        TimeManager.instance.ContinueTime();
        text.DOText(content, content.Length * speekSpeed).OnComplete(Paused);
    }

    public void Paused()
    {
        TimeManager.instance.PauseTime();
        continueButton.SetActive(true);
        continueButton.transform.position = continueButtonStart;
        continueButton.transform.DOMove(continueButtonStart + new Vector3(0, 1, 0), 0.8f).SetLoops(-1,LoopType.Yoyo);
    }
}
