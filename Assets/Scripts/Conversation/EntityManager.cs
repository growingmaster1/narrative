using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于存储NPC相关的数据
/// </summary>
public class EntityManager:MonoBehaviour,IInit
{
    public static EntityManager instance;
    public static Dictionary<string, IWithEntity> EntitiesDic;

    public void Init()
    {
        GameEntity[] entities = transform.GetComponentsInChildren<GameEntity>();
        EntitiesDic = new Dictionary<string, IWithEntity>();
        foreach(GameEntity item in entities)
        {
            item.Init();
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


}
