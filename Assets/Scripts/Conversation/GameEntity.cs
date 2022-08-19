using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Unity.Interfaces;
using UnityEngine.EventSystems;

/// <summary>
/// 游戏中所有的可与玩家交互的对象，包括物品，地标等
/// </summary>
public class GameEntity : MonoBehaviour, ITalkable,IInit,IPointerClickHandler,IWithEntity
{
    public ArticyRef givenEntity;
    public ArticyRef givenDialog;
    public IArticyObject entity { get; set; }
    public IArticyObject dialog;

    [HideInInspector]
    public string entityName { get; set; }
    public IMyFlowPlayer atFlow = null;

    public virtual void Init()
    {
        dialog = givenDialog.GetObject();
        entity = givenEntity.GetObject();
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
            if(EntityManager.EntitiesDic.ContainsKey(entityName))
            {
                Debug.Log("Warning: Entity Name equals");
            }
            else
            {
                EntityManager.EntitiesDic.Add(entityName, this);
            }
        }
    }

    public virtual void RaiseDialog()
    {
        if(dialog!=null)
        {
            DialogManager.instance.SetStart(dialog as IArticyObject);
            //DialogManager.flowPlayer.Play();
            Player.instance.moveable = false;
        }
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        //TODO：寻路
        float dis = (transform.position - Player.instance.transform.position).magnitude;
        if(dis<20)
        {
            RaiseDialog();
        }
    }
}
