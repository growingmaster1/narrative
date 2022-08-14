using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Unity.Interfaces;
using UnityEngine.EventSystems;

/// <summary>
/// 游戏中所有的可与玩家交互的对象，包括物品，地标等
/// </summary>
public class GameEntity : MonoBehaviour, ITalkable,IInit,IPointerClickHandler
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
        if(dialog!=null)
        {
            DialogManager.instance.SetStart(dialog);
            DialogManager.flowPlayer.Play();
            Player.instance.moveable = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        float dis = (transform.position - Player.instance.transform.position).magnitude;
        if(dis<20)
        {
            RaiseDialog();
        }
    }
}
