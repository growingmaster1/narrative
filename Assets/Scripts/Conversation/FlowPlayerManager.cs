using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Unity.Interfaces;

public class FlowPlayerManager : MonoBehaviour,IInit
{
    public static FlowPlayerManager instance;

    public void Init()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Warning: more than one FlowPlayerManager");
        }
    }
}
