using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ThunderController : MonoBehaviour
{
    PlayableDirector ThunderPD;
    public PlayableAsset Thunder1, Thunder2;
    public float thunderDuration = 1.2f;
    public bool isThunderOK = true, isThunderING = false;
    int thunderPAselector;
    private void Awake()
    {
        ThunderPD = GetComponent<PlayableDirector>();
        ThunderPD.playOnAwake = false;
        thunderPAselector = Random.Range(1, 3);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isThunderOK&&!isThunderING)
        {
            thunderDuration -= 0.02f;
            if(thunderDuration<=0.02f)
            {
                if(thunderPAselector==1)
                {
                    ThunderPD.Play(Thunder1);
                    isThunderING = true;
                }
                else
                {
                    ThunderPD.Play(Thunder2);
                    isThunderING = true;
                }
                ThunderPD.stopped += ThunderReset;
            }
        }
    }

    void ThunderReset(PlayableDirector Whatever)
    {
        thunderDuration = Random.Range(5.8f, 8.4f);
        thunderPAselector= Random.Range(1, 3);
        isThunderING = false;
        ThunderPD.stopped -= ThunderReset;
    }

    public void SetThunder(bool isThunder, float duration)
    {
        isThunderOK = isThunder;
        thunderDuration = duration;
    }
}
