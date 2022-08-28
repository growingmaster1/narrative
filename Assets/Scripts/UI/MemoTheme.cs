using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MemoTheme : MonoBehaviour,IPointerClickHandler
{
    public string themeName;
    public bool read = false;
    public GameObject redPoint;

    public MemoTheme()
    {
        
    }

    public void AssignData(MemoThemeData data)
    {
        themeName = data.name;
        read = data.read;
        if(!read)
        {
            redPoint.SetActive(true);
        }
        else
        {
            redPoint.SetActive(false);
        }
    }

    public void Select()
    {
        GetComponent<Text>().color = Color.yellow;
        if(read == false)
        {
            read = true;
            redPoint.SetActive(false);
        }
    }

    public void UnSelect()
    {
        GetComponent<Text>().color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Select();
        MemoManager.instance.SwitchTheme(this);
    }
}
