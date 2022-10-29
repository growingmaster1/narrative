using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour,IInit
{
    public string regionName;
    public AudioClip clip;

    public bool triggerable;

    public void Init()
    {
        MusicController.instance.audioRegions.Add(regionName, this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(triggerable)
        {
            MusicController.instance.SwitchMusic(clip);
        }
    }

    
}
