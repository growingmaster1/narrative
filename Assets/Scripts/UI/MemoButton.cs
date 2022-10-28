using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoButton : MonoBehaviour,IInit
{
    public static MemoButton instance;

    private Animator anim;
    public GameObject redPoint; 

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Init()
    {
        anim = GetComponent<Animator>();
    }

    public void ShakeNew()
    {
        if(!anim.enabled)
        {
            redPoint.SetActive(true);
            anim.enabled = true;
            anim.Play("MemoButtonShake");
        }
    }

    public void StopShake()
    {
        if(anim.enabled)
        {
            redPoint.SetActive(false);
            anim.enabled = false;
        }
    }
}
