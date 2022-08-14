using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Littletown.GlobalVariables;
using Articy.Unity;
using Articy.Unity.Interfaces;
using Sirenix.OdinInspector;

public class ArticyReader : MonoBehaviour
{
    private ArticyGlobalVariables globalVariables;

    private void Start()
    {
        globalVariables = ArticyGlobalVariables.Default;
    }

    public bool GetBoolean(string group,string name)
    {
        IArticyNamespace variables =  globalVariables.GetType().GetProperty(group).GetValue(globalVariables) as IArticyNamespace;
        return (bool)(variables.GetType().GetProperty(name).GetValue(variables));
    }

    public int GetInteger(string group, string name)
    {
        IArticyNamespace variables = globalVariables.GetType().GetProperty(group).GetValue(globalVariables) as IArticyNamespace;
        return (int)(variables.GetType().GetProperty(name).GetValue(variables));
    }

    public void SetBoolean(string group, string name, bool value)
    {
        IArticyNamespace variables = globalVariables.GetType().GetProperty(group).GetValue(globalVariables) as IArticyNamespace;
        variables.GetType().GetProperty(name).SetValue(variables,value);
    }

    public void SetInteger(string group, string name, int value)
    {
        IArticyNamespace variables = globalVariables.GetType().GetProperty(group).GetValue(globalVariables) as IArticyNamespace;
        variables.GetType().GetProperty(name).SetValue(variables,value);
    }
}
