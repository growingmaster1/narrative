using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{
    private void Start()
    {
        //LayerSorter.instance.Init();
        TimeManager.instance.Init();
        MusicController.instance.Init();
        DialogManager.instance.Init();
        SoundingManager.instance.Init();
        DialogBox.instance.Init();
        MemoButton.instance.Init();
        MemoManager.instance.Init();
        EntityManager.instance.Init();
        Player.instance.Init();
    }
}
