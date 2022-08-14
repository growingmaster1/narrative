using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ڴ洢NPC��ص�����
/// </summary>
public class EntityManager:MonoBehaviour,IInit
{
    public static EntityManager instance;
    public static Dictionary<string, GameEntity> EntitiesDic;

    public void Init()
    {
        GameEntity[] entities = transform.GetComponentsInChildren<GameEntity>();
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
