using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundingManager : MonoBehaviour,IInit
{
    public static SoundingManager instance;
    private Pool textPool;
    public GameObject soundingText;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    public void Init()
    {
        textPool = new Pool(soundingText, "sounding", 10);
    }


}
