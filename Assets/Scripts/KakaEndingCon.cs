using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class KakaEndingCon : MonoBehaviour
{
    public PlayableDirector startPerformancePD, endPerformancePD, showSpaceshipPD, leaveEarthPD;
    public Renderer signalTowerTilemapRenderer;
    public GameObject CMVcam1;
    public AudioClip clip;
    public GameObject meteorPS;
    // Start is called before the first frame update
    
    public void EnterPerformance()
    {
        startPerformancePD.Play();
    }

    public void EndPerfarmance()
    {
        endPerformancePD.Play();
    }

    public void SignalTowerOrderinLayer(int order)
    {
        signalTowerTilemapRenderer.sortingOrder = order;
    }

    public void setCMVcam1Active(bool set)
    {
        CMVcam1.SetActive(set);
    }

    public void SwitchKakaEndingMusic()
    {
        MusicController.instance.SwitchMusic(clip);
    }

    public void StopMeteor()
    {
        meteorPS.GetComponent<ParticleSystem>().Stop();
    }

    public void ShowKakaSpaceship()
    {
        showSpaceshipPD.Play();
    }

    public void KakaStayOnEarth()
    {
        EndingCutsceneManager.Instance.EnterEndingCutscene();
    }

    public void KakaLeaveEarth()
    {
        leaveEarthPD.Play();
        leaveEarthPD.stopped += LeaveEarth;
    }

    void LeaveEarth(PlayableDirector whatever)
    {
        leaveEarthPD.stopped -= LeaveEarth;
        EndingCutsceneManager.Instance.EnterEndingCutscene();
    }
}
