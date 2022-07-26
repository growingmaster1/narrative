using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Unity.Interfaces;

public class GameEntity : MonoBehaviour, ITalkable,IInit
{
    public ArticyRef entity;
    public IArticyObject dialog;
    private string entityName;
    public IArticyFlowPlayerCallbacks atFlow = null;

    public void Init()
    {
        if(entity == null)
        {
            Debug.Log("Warning: an NPC doesn't have an entity");
        }

        entityName = (entity as IObjectWithDisplayName)?.DisplayName;
        if(entityName == null)
        {
            entityName = ((ArticyObject)entity).TechnicalName;
        }
        

        if(entityName!=null)
        {
            if(EntityData.EntitiesDic.ContainsKey(entityName))
            {
                Debug.Log("Warning: Entity Name equals");
            }
            else
            {
                EntityData.EntitiesDic.Add(entityName, this);
            }
        }
    }

    public void RaiseDialog()
    {
        DialogManager.flowPlayer.StartOn = dialog;
        DialogManager.flowPlayer.Play();
    }
}
