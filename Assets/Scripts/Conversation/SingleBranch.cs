using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Articy.Unity;
using Articy.Unity.Interfaces;

public class SingleBranch : MonoBehaviour
{
    private Branch branch;
    private Text text;
    private IFlowObject target;
    private string menuWords;

    public SingleBranch()
    {

    }

    public SingleBranch(Branch inBranch)
    {
        branch = inBranch;
        target = branch.Target;
    }

    //��ֵ�������͹��캯��һ��������unity�ڲ��ֶ����أ�����ô˺������и�ֵ
    public void AssignBranch(Branch inBranch)
    {
        if(text == null)
        {
            text = GetComponentInChildren<Text>();
        }
        branch = inBranch;
        target = branch.Target;
        ParseBranch();
        text.text = menuWords;
    }

    //��branch���н�������ȡ��Ҫ����Ϣ
    public void ParseBranch()
    {
        menuWords = "";
        IObjectWithMenuText withMenuText = target as IObjectWithMenuText;
        if (withMenuText != null && withMenuText.MenuText != "")
        {
            menuWords = withMenuText.MenuText;
            return;
        }

        IObjectWithDisplayName withDisplayName = target as IObjectWithDisplayName;
        if (withDisplayName != null)
        {
            menuWords = withDisplayName.DisplayName;
            return;
        }

        IObjectWithText withText = target as IObjectWithText;
        if (withText != null)
        {
            menuWords = withText.Text;
            return;
        }

        IArticyObject articyObject = target as IArticyObject;
        if (articyObject != null)
        {
            menuWords = articyObject.TechnicalName;
            return;
        }

        menuWords = target == null ? "null" : target.GetType().Name;
    }

    public void SelectBranch()
    {
        if(DialogBox.instance.continuable)
        {
            if (branch != null)
            {
                DialogManager.FlowPlayer.Play(branch);
            }
        }
    }
}
