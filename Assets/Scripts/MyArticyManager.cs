using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Littletown;

public class MyArticyManager : MonoBehaviour
{
    public static MyArticyManager instance;
    public static Dictionary<string, Object> articyGlobalVariables;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }
}
