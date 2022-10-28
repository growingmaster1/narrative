using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MusicController : MonoBehaviour,IInit
{
    public static MusicController instance;
    public AudioSource[] musicPlayer;
    public AudioClip initialMusic;

    public int onPlayer;
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Init()
    {
        if(initialMusic != null)
        {
            musicPlayer[0].clip = initialMusic;
            musicPlayer[0].Play();
        }
        onPlayer = 0;
    }

    public void SwitchMusic(AudioClip music)
    {
        
        musicPlayer[onPlayer].DOFade(0, 2);
        musicPlayer[1 - onPlayer].clip = music;
        musicPlayer[1 - onPlayer].DOFade(1, 2);
    }
}
