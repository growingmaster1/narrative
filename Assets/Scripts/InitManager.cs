using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{
    private void Start()
    {
        //LayerSorter.instance.Init();
        TimeManager.instance.Init();
        Player.instance.Init();
        //EntityManager.instance.Init();
    }
}
