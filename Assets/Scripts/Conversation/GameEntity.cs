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
    public List<ArticyRef> givenEntity = new List<ArticyRef>();
    public ArticyRef givenDialog;
    public IArticyObject entity { get; set; }
    public IArticyObject dialog;

    [HideInInspector]
    public string entityName { get; set; }
    public bool atDialog { get; set; }

    public IMyFlowPlayer atFlow = null;

    public virtual void Init()
    {
        dialog = givenDialog.GetObject();
        for(int i=0;i<givenEntity.Count;++i)
        {
            entity = givenEntity[i].GetObject();
            if (entity == null)
            {
                Debug.Log("Warning: an NPC doesn't have an entity");
            }

            entityName = (entity as IObjectWithDisplayName)?.DisplayName;
            if (entityName == null)
            {
                entityName = (entity as ArticyObject)?.TechnicalName;
            }


            if (entityName != null)
            {
                if (EntityManager.EntitiesDic.ContainsKey(entityName))
                {
                    Debug.Log("Warning: Entity Name equals");
                }
                else
                {
                    EntityManager.EntitiesDic.Add(entityName, this);
                }
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

    public void SwitchEntity(int i)
    {
        entity = givenEntity[i].GetObject();
        if (entity == null)
        {
            Debug.Log("Warning: an NPC doesn't have an entity");
        }

        entityName = (entity as IObjectWithDisplayName)?.DisplayName;
        if (entityName == null)
        {
            entityName = (entity as ArticyObject)?.TechnicalName;
        }
    }
}
