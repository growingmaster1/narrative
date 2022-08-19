using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using Articy.Unity;
using Articy.Unity.Interfaces;

public class TaskTalking : ActionTask
{
    public string dialogName;

    protected override void OnExecute()
    {
        base.OnExecute();
        GameEntity entity = agent.gameObject.GetComponent<GameEntity>();
        entity.dialog = ArticyDatabase.GetObject(dialogName);

        EndAction(true);
        Debug.Log("Hello");
    }
    
}