using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Articy.Unity;
using Articy.Littletown.GlobalVariables;

public class TimeManager : MonoBehaviour,IInit
{
    public static TimeManager instance;

    public int days;
    public int hours;
    public int minutes;

    //public int seconds;
    public Text timeText;
    public Text daysText;

    public Image pauseButton;
    public Sprite pauseSprite;
    public Sprite runningSprite;
    private bool paused = false;
    private bool handyPaused = false;

    private float timer=2.5f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Init()
    {
        days = ArticyGlobalVariables.Default.day_and_time.days;
        hours = ArticyGlobalVariables.Default.day_and_time.hours;
        minutes = ArticyGlobalVariables.Default.day_and_time.minutes;
        //seconds = ArticyGlobalVariables.Default.day_and_time.seconds;
        timeText.text = hours.ToString("D2") + ":" + minutes.ToString("D2");// +":"+seconds.ToString("D2");
        daysText.text = "Day" + days;
    }

    private void Update()
    {
        if (!paused)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                addSecond();
                timer += 2.5f;
            }
        }
    }

    private void addSecond()
    {
        //seconds += 1;
        //if(seconds >= 60)
        //{
        //    seconds -= 60;
        minutes += 1;
        if (minutes >= 60)
        {
            hours += 1;
            minutes -= 60;
            if (hours >= 23)
            {
                //TODO:时间超过晚上23点时的处理。
            }
            ArticyGlobalVariables.Default.day_and_time.hours = hours;
        }
        ArticyGlobalVariables.Default.day_and_time.minutes = minutes;
        //}
        timeText.text = hours.ToString("D2") + ":" + minutes.ToString("D2");// + ":" + seconds.ToString("D2");
        //ArticyGlobalVariables.Default.day_and_time.seconds = seconds;
        //Debug.Log(ArticyGlobalVariables.Default.day_and_time.seconds);
    }

    public void PauseTime()
    {
        paused = true;
        pauseButton.sprite = runningSprite;
        Time.timeScale = 0;
    }

    public void ContinueTime()
    {
        paused = false;
        pauseButton.sprite = pauseSprite;
        Time.timeScale = 1;
    }

    public void SwitchPause()
    {
        if(handyPaused&&paused)
        {
            handyPaused = false;
            ContinueTime();
        }
        else if(!paused&&!handyPaused)
        {
            handyPaused = true;
            PauseTime();
        }
    }
}
