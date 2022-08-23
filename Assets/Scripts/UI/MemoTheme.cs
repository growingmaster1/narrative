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

    public void AssignName(string inName)
    {
        themeName = inName;
    }

    public void Select()
    {
        GetComponent<Text>().color = Color.yellow;
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
