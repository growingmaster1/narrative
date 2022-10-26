using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundingManager : MonoBehaviour,IInit
{
    public static SoundingManager instance;
    private Pool textPool;
    public GameObject soundingText;
    public GameObject soundingFolder;
    public Camera UICamera;

    private Pool statePool;
    public Dictionary<string, StatePlayer> states;
    public GameObject statePlayer;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    public void Init()
    {
        textPool = new Pool(soundingText, "sounding", 10, soundingFolder);
        statePool = new Pool(statePlayer, "statePlayer", 30);
        states = new Dictionary<string, StatePlayer>();
    }

    public GameObject GetText()
    {
        return textPool.CreateFromPool();
    }

    public void ReturnText(GameObject inText)
    {
        textPool.ReturnPool(inText);
    }

    public void PutText(GameObject textObject,Vector3 worldPos)
    {
        //Vector3 temp;
        //temp = Camera.main.WorldToScreenPoint(worldPos);
        //temp.z = 100;
        //worldPos = UICamera.ScreenToWorldPoint(temp);
        //worldPos.z = 0;
        //Vector3 pos = textObject.transform.InverseTransformPoint(worldPos);
        //pos = new Vector3(pos.x, pos.y, 0);
        //textObject.transform.localPosition = pos;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        screenPos.z = 0;
        textObject.transform.position = screenPos;
    }

    //使实体处于某状态
    public StatePlayer PutState(string entityName, string stateTechName)
    {
        if(states.ContainsKey(stateTechName))
        {
            states[stateTechName].AddEntity(entityName);
            return states[stateTechName];
        }
        else
        {
            StatePlayer newPlayer = statePool.CreateFromPool().GetComponent<StatePlayer>();
            newPlayer.AssignFlow(stateTechName);
            newPlayer.AddEntity(entityName);
            states.Add(stateTechName, newPlayer);
            return newPlayer;
        }
    }

    public void RemoveState(string stateTechName)
    {
        if(states.ContainsKey(stateTechName))
        {
            statePool.ReturnPool(states[stateTechName].gameObject);
            states.Remove(stateTechName);
        }
    }
}
