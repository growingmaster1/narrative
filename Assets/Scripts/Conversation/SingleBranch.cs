using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Unity.Interfaces;

public class SingleBranch : MonoBehaviour
{
    private Branch branch;
    private IFlowObject target;
    private string menuWords;

    public SingleBranch(Branch inBranch)
    {
        branch = inBranch;
        target = branch.Target;
    }

    //��ֵ�������͹��캯��һ��������unity�ڲ��ֶ����أ�����ô˺������и�ֵ
    public void AssignBranch(Branch inBranch)
    {
        branch = inBranch;
        target = branch.Target;
    }

    //��branch���н�������ȡ��Ҫ����Ϣ
    public void ParseBranch()
    {
        menuWords = "";
        IObjectWithMenuText withMenuText = target as IObjectWithMenuText;
        if (target != null)
        {
            menuWords = withMenuText.MenuText;
            return;
        }

        IObjectWithDisplayName withDisplayName = target as IObjectWithDisplayName;
        if (target != null)
        {
            menuWords = withDisplayName.DisplayName;
            return;
        }

        IObjectWithText withText = target as IObjectWithText;
        if (target != null)
        {
            menuWords = withText.Text;
            return;
        }

        IArticyObject articyObject = target as IArticyObject;
        if (target != null)
        {
            menuWords = articyObject.TechnicalName;
            return;
        }

        menuWords = target == null ? "null" : target.GetType().Name;
    }

    public void SelectBranch()
    {
        DialogManager.flowPlayer.Play(branch);
    }
}
