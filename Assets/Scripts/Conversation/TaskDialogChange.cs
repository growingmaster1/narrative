using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using Articy.Unity;
using Articy.Unity.Interfaces;

public class TaskDialogChange : ActionTask
{
    public ArticyRef dialogState;

    protected override void OnExecute()
    {
        base.OnExecute();
        SmartEntity entity = agent as SmartEntity;
        entity.state = dialogState as IArticyObject;
        //TODO�����ô�ʱ����ҶԻ�ʱ�����ĶԻ�

        EndAction(true);
    }
}
