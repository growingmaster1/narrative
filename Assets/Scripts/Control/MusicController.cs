using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MusicController : MonoBehaviour,IInit
{
    public static MusicController instance;
    public AudioSource[] musicPlayer;
    public AudioClip initialMusic;

    public Dictionary<string, MusicTrigger> audioRegions;

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

        MusicTrigger[] regions = transform.GetComponentsInChildren<MusicTrigger>();
        audioRegions = new Dictionary<string, MusicTrigger>();
        foreach (MusicTrigger item in regions)
        {
            item.Init();
        }
    }

    public void SwitchMusic(AudioClip music)
    {
        int nowPlayer = onPlayer;
        AudioSource source1 = musicPlayer[onPlayer];
        AudioSource source2 = musicPlayer[1 - onPlayer];
        if(music != source1.clip)
        {
            if(source2.volume > 0)
            {
                source2.DOFade(0, 1);
            }
            musicPlayer[onPlayer].DOFade(0, 2).SetEase(Ease.Linear);
            source2.clip = music;
            source2.DOFade(1, 2).SetEase(Ease.Linear).OnComplete(() => { onPlayer = 1 - nowPlayer; });
            source2.time = 0;
            source2.Play();
        }
        else
        {
            if (source1.volume < 1) 
            {
                source1.DOFade(1, 2 * (1 - source1.volume)).SetEase(Ease.Linear).OnComplete(()=> { onPlayer = nowPlayer; });
                source2.DOFade(0, 2 * source2.volume).SetEase(Ease.Linear);
            }
        }
    }

    public void ShutAllTriggers()
    {
        foreach(MusicTrigger item in audioRegions.Values)
        {
            item.triggerable = false;
        }
    }
}
