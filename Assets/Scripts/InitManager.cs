using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{
    public bool timeManager;
    public bool musicController;
    public bool dialogManager;
    public bool soundingManager;
    public bool dialogBox;
    public bool memoButton;
    public bool entityManager;
    public bool player;
    public bool memoManager;


    private void Start()
    {
        //LayerSorter.instance.Init();
        if(timeManager) TimeManager.instance.Init();
        if(musicController) MusicController.instance.Init();
        if(dialogManager) DialogManager.instance.Init();
        if(soundingManager) SoundingManager.instance.Init();
        if(dialogBox) DialogBox.instance.Init();
        if(memoButton) MemoButton.instance.Init();
        if(memoManager) MemoManager.instance.Init();
        if(entityManager) EntityManager.instance.Init();
        if(player) Player.instance.Init();
    }
}
