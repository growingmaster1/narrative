using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class KakaEndingCon : MonoBehaviour
{
    public PlayableDirector startMeteorPD, endMeteorPD;
    public Renderer signalTowerTilemapRenderer;
    public GameObject CMVcam1;
    // Start is called before the first frame update
    
    public void EnterMeteor()
    {
        startMeteorPD.Play();
    }

    public void EndMeteor()
    {
        endMeteorPD.Play();
    }

    public void SignalTowerOrderinLayer(int order)
    {
        signalTowerTilemapRenderer.sortingOrder = order;
    }

    public void setCMVcam1Active(bool set)
    {
        CMVcam1.SetActive(set);
    }
}
