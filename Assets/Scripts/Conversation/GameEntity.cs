using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Unity.Interfaces;

public class GameEntity : MonoBehaviour, ITalkable,IInit
{
    //[ArticyTypeConstraint(typeof(Entity))]
    public ArticyRef entity;
    public IArticyObject startCenter;
    private string entityName;

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
            if(EntityData.NPCDic.ContainsKey(entityName))
            {
                Debug.Log("Warning: Entity Name equals");
            }
            else
            {
                EntityData.NPCDic.Add(entityName, this);
            }
        }
    }

    public void RaiseConversation()
    {
        DialogManager.flowPlayer.StartOn = startCenter;
        DialogManager.flowPlayer.Play();
    }
}
