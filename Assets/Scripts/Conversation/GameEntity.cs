using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Unity.Interfaces;
using UnityEngine.EventSystems;
using PolyNav;

/// <summary>
/// 游戏中所有的可与玩家交互的对象，包括物品，地标等
/// </summary>
public class GameEntity : MonoBehaviour, ITalkable,IInit,IPointerClickHandler,IWithEntity
{
    public List<ArticyRef> givenEntity = new List<ArticyRef>();
    public ArticyRef givenDialog;
    public PolyNavAgent PlayerAgent;
    public bool beingTraced = false;
    public IArticyObject entity { get; set; }
    public IArticyObject dialog;

    [HideInInspector]
    public string entityName { get; set; }
    public bool atDialog { get; set; }

    public IMyFlowPlayer atFlow = null;

    public virtual void Init()
    {
        dialog = givenDialog.GetObject();
        PlayerAgent = Player.instance.GetComponent<PolyNavAgent>();
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

    private void FixedUpdate()
    {
        if(beingTraced)
        {
            PlayerAgent.SetDestination(transform.position);
        }
    }

    public virtual void RaiseDialog()
    {
        if (Player.instance.atDialog)
        {
            return;
        }
        if (dialog!=null)
        {
            
            Player.instance.atDialog = true;
            Player.instance.StopMoving();
            DialogManager.instance.SetStart(dialog as IArticyObject);
            //DialogManager.flowPlayer.Play();
        }
        beingTraced = false;
        PlayerAgent.OnDestinationReached -= RaiseDialog;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        //TODO：寻路

        PlayerAgent.SetDestination(transform.position);
        if(PlayerAgent.remainingDistance>50.0f)
        {
            PlayerAgent.Stop();
        }
        else
        {
            Player.instance.TracedTarget = gameObject;
            Player.instance.GetComponent<Animator>().enabled = true;
            beingTraced = true;
            PlayerAgent.OnDestinationReached += RaiseDialog;
        }
        /*
        float dis = (transform.position - Player.instance.transform.position).magnitude;
        if(dis<20)
        {
            RaiseDialog();
        }
        */
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

    public void SetOutline(Color outlineColor, float outlineWidth)
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_outlineOffset", outlineWidth);
        gameObject.GetComponent<Renderer>().material.SetColor("_outlineColor", outlineColor);
    }
}
