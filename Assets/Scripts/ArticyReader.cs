using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Littletown.GlobalVariables;
using Articy.Unity;
using Articy.Unity.Interfaces;
using Sirenix.OdinInspector;

public class ArticyReader : MonoBehaviour
{
    public static ArticyReader instance;
    private ArticyGlobalVariables globalVariables;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        globalVariables = ArticyGlobalVariables.Default;
    }

    public bool GetBoolean(string group,string name)
    {
        try
        {
            IArticyNamespace variables = globalVariables.GetType().GetProperty(group).GetValue(globalVariables) as IArticyNamespace;
            return (bool)(variables.GetType().GetProperty(name).GetValue(variables));
        }
        catch
        {
            Debug.LogError("获取articy中数据有误：变量集：" + group + "   变量：" + name);
            return false;
        }
    }

    public int GetInteger(string group, string name)
    {
        try
        {
            IArticyNamespace variables = globalVariables.GetType().GetProperty(group).GetValue(globalVariables) as IArticyNamespace;
            return (int)(variables.GetType().GetProperty(name).GetValue(variables));
        }
        catch
        {
            Debug.LogError("获取articy中数据有误：变量集：" + group + "   变量：" + name);
            return -1;
        }
    }

    public string GetString(string group, string name)
    {
        try
        {
            IArticyNamespace variables = globalVariables.GetType().GetProperty(group).GetValue(globalVariables) as IArticyNamespace;
            return (string)(variables.GetType().GetProperty(name).GetValue(variables));
        }
        catch
        {
            Debug.LogError("获取articy中数据有误：变量集：" + group + "   变量：" + name);
            return "";
        }
    }

    public void SetBoolean(string group, string name, bool value)
    {
        try
        {
            IArticyNamespace variables = globalVariables.GetType().GetProperty(group).GetValue(globalVariables) as IArticyNamespace;
            variables.GetType().GetProperty(name).SetValue(variables, value);
        }
        catch
        {
            Debug.LogError("修改articy中数据有误：变量集：" + group + "   变量：" + name);
        }
    }

    public void SetInteger(string group, string name, int value)
    {
        try
        {
            IArticyNamespace variables = globalVariables.GetType().GetProperty(group).GetValue(globalVariables) as IArticyNamespace;
            variables.GetType().GetProperty(name).SetValue(variables, value);
        }
        catch
        {
            Debug.LogError("修改articy中数据有误：变量集：" + group + "   变量：" + name);
        }
    }

    public void SetString(string group, string name, string value)
    {
        try
        {
            IArticyNamespace variables = globalVariables.GetType().GetProperty(group).GetValue(globalVariables) as IArticyNamespace;
            variables.GetType().GetProperty(name).SetValue(variables, value);
        }
        catch
        {
            Debug.LogError("修改articy中数据有误：变量集：" + group + "   变量：" + name);
        }
    }
}
