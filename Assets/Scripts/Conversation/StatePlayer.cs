using Articy.Unity;
using Articy.Unity.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlayer :  MonoBehaviour,IMyFlowPlayer
{
    private ArticyObject flow;
    public string techName;

    public ArticyFlowPlayer flowPlayer { get; set; }
    public List<SmartEntity> speakers { get; set; }
    public bool atDialog { get; set; }

    private bool playing;
    private SmartEntity speaker;

    private List<ArticyObject> attachedDialog = new List<ArticyObject>();
    private int attachTalkPlace;

    public void Awake()
    {
        flowPlayer = GetComponent<ArticyFlowPlayer>();
        speakers = new List<SmartEntity>();
    }

    public void AssignFlow(string inTechName)
    {
        flow = ArticyDatabase.GetObject(inTechName);
        techName = inTechName;
        IObjectWithAttachments attached = flow as IObjectWithAttachments;
        if (attached != null)
        {
            attachedDialog = attached.Attachments;
            attachTalkPlace = 0;
        }
        else
        {
            Debug.LogError("Articy don't have state \"" + inTechName + "\"");
        }
        playing = false;
        flowPlayer.StartOn = flow;
        flowPlayer.StartOn = null;
    }

    public void AddEntity(string entityName)
    {
        SmartEntity inEntity = EntityManager.EntitiesDic[entityName] as SmartEntity;
        if(inEntity == null)
        {
            Debug.LogError("Entity" + "\"" + entityName + "\"??????");
        }
        if (!speakers.Contains(inEntity))
        {
            speakers.Add(inEntity);
        }
        if(attachedDialog.Count > 0)
        {
            inEntity.SetOutline(0.01f);
        }
        else
        {
            inEntity.SetOutline(0f);
        }
    }

    public void RemoveEntity(string entityName)
    {
        SmartEntity inEntity = EntityManager.EntitiesDic[entityName] as SmartEntity;
        if (speakers.Contains(inEntity))
        {
            inEntity.StopSounding();
            speakers.Remove(inEntity);
        }
        if(speakers.Count==0)
        {
            SoundingManager.instance.RemoveState(techName);
        }
    }

    public void StartSounding()
    {
        if(playing == false && flowPlayer.StartOn!=null)
        {
            playing = true;
            PlayChat();
        }
        playing = true;
        if (flowPlayer.StartOn==null)
        {
            flowPlayer.StartOn = flow;
            //flowPlayer.StartOn = flow;
        }
    }

    public void OnFlowPlayerPaused(IFlowObject aObject)
    {
        if (aObject == null)
        {
            Debug.Log("Warning: aObject is null");
            return;
        }

        if(playing == false)
        {
            return;
        }

        speaker = DialogManager.instance.DefineSpeaker(aObject) as SmartEntity;
        if (speaker == null)
        {
            //Debug.Log("talking to " + DialogManager.instance.DefineSpeaker(aObject).entityName + " is wooden");
            return;
        }
        if (speaker.atFlow != this)
        {
            speaker.SetState(techName);
        }
        speaker.ArouseSound((aObject as IObjectWithText).Text);
    }

    public void OnBranchesUpdated(IList<Branch> aBranches)
    {
        if (aBranches.Count < 1)
        {
            flowPlayer.FinishCurrentPausedObject();
            flowPlayer.StartOn = null;
            foreach(SmartEntity entity in speakers)
            {
                entity.StopSounding();
            }
        }
        else
        {
            Invoke("PlayChat", 2);
        }
    }

    public void PlayChat()
    {
        if (playing)
        {
            flowPlayer.Play();
        }
    }

    public void ContinueChat()
    {
        playing = true;
        PlayChat();
    }

    public void PauseChat()
    {
        playing = false;
    }

    public void StopChat()
    {
        playing = false;
        flowPlayer.StartOn = null;
    }

    public void PlayOnce()
    {
        playing = true;
        if (flowPlayer.StartOn == null)
        {
            flowPlayer.StartOn = flow;
            //flowPlayer.StartOn = flow;
        }
        else
        {
            PlayChat();
        }
        playing = false;
    }

    public void PlayDialog()
    {
        if(Player.instance.atDialog)
        {
            return;
        }
        IArticyObject dialog = null;
        if (attachedDialog.Count>attachTalkPlace)
        {
            dialog = attachedDialog[attachTalkPlace];
        }
        
        if (dialog != null)
        {
            playing = false;
            Player.instance.atDialog = true;
            Player.instance.StopMoving();
            foreach (SmartEntity entity in speakers)
            {
                entity.ReturnText();
                entity.atDialog = true;
                DialogManager.instance.speakers.Add(entity);
            }
            DialogManager.instance.SetStart(dialog);
            if (attachTalkPlace + 1 < attachedDialog.Count)
            {
                attachTalkPlace++;
            }
        }
    }

    public bool IsInDialog()
    {
        return atDialog;
    }
}
