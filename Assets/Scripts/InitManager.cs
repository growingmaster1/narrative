using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{
    private void Start()
    {
        LayerSorter.instance.Init();
        TimeManager.instance.Init();
        DialogManager.instance.Init();
        DialogBox.instance.Init();
        EntityManager.instance.Init();
        Player.instance.Init();
    }
}
