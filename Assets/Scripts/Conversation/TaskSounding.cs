using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using Articy.Unity;
using Articy.Unity.Interfaces;

public class TaskSounding : ActionTask
{
    public string dialogState;

    protected override void OnExecute()
    {
        base.OnExecute();
        SmartEntity entity = agent.gameObject.GetComponent<SmartEntity>();
        entity.state = ArticyDatabase.GetObject(dialogState);
        entity.ArouseChat();

        EndAction(true);
    }
}
