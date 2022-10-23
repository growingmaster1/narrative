using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;


public class MainMenuController : MonoBehaviour
{
    public float fadeInSpeed = 0.02f;
    public float stopTimePir = 1.0f, cutScenePir = 1.0f;
    float stopTimePirTemp;
    public GameObject allWhitePanel;
    public GameObject headphonePanel;
    public GameObject loadingPanel;
    CanvasGroup headphonePanelCG;
    UnityEngine.UI.Image allWhiteaPanelBG;
    public Image allAllWhitePanelBG;
    public SpriteRenderer NPC1, NPC2, NPC3, NPC4, NPC5;
    public PlayableDirector cutScenePD;
    AsyncOperation async;
    [SerializeField]
    bool isAWPFin = false, isHPFin = false, isStopTime1Fin = false, isStopTime2Fin = false, isHPFinFin = false, isCutsceneFin = true, isCutsceneWaitFin = true, isCutsceneEndFin = true;

    private void Awake()
    {
        headphonePanelCG = headphonePanel.GetComponent<CanvasGroup>();
        allWhiteaPanelBG = allWhitePanel.GetComponent<UnityEngine.UI.Image>();
        Application.backgroundLoadingPriority = ThreadPriority.Low;
    }

    private void FixedUpdate()
    {
        if(isAWPFin==false)
        {
            allWhiteaPanelBG.color = new Color(allWhiteaPanelBG.color.r, allWhiteaPanelBG.color.g, allWhiteaPanelBG.color.b, allWhiteaPanelBG.color.a - fadeInSpeed);
            if(allWhiteaPanelBG.color.a<=0.001f)
            {
                isAWPFin = true;
                stopTimePirTemp = stopTimePir;
            }
        }
        else if(isStopTime1Fin==false)
        {
            stopTimePirTemp -= 0.02f;
            if(stopTimePirTemp<=0.01f)
            {
                isStopTime1Fin = true;
            }
        }
        else if(isHPFin==false)
        {
            allWhiteaPanelBG.color = new Color(allWhiteaPanelBG.color.r, allWhiteaPanelBG.color.g, allWhiteaPanelBG.color.b, allWhiteaPanelBG.color.a + fadeInSpeed);
            if (allWhiteaPanelBG.color.a >= 0.99f)
            {
                headphonePanel.SetActive(false);
                isHPFin = true;
                stopTimePirTemp = stopTimePir;
            }
        }
        else if (isStopTime2Fin == false)
        {
            stopTimePirTemp -= 0.04f;
            if (stopTimePirTemp <= 0.01f)
            {
                isStopTime2Fin = true;
            }
        }
        else if(isHPFinFin==false)
        {
            allWhiteaPanelBG.color = new Color(allWhiteaPanelBG.color.r, allWhiteaPanelBG.color.g, allWhiteaPanelBG.color.b, allWhiteaPanelBG.color.a - fadeInSpeed);
            if (allWhiteaPanelBG.color.a <= 0.01f)
            {
                allWhitePanel.SetActive(false);
                isHPFinFin = true;
            }
        }

        if(!isCutsceneFin)
        {
            allAllWhitePanelBG.color = new Color(allAllWhitePanelBG.color.r, allAllWhitePanelBG.color.g, allAllWhitePanelBG.color.b, allAllWhitePanelBG.color.a - 0.02f);
            NPC1.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC1.color.a + 0.02f);
            NPC2.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC1.color.a + 0.02f);
            NPC3.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC1.color.a + 0.02f);
            NPC4.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC1.color.a + 0.02f);
            NPC5.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC1.color.a + 0.02f);
            if (allAllWhitePanelBG.color.a<=0.02f)
            {
                isCutsceneFin = true;
                isCutsceneWaitFin = false;
            }
        }

        if(!isCutsceneWaitFin)
        {
            cutScenePir -= 0.02f;
            if(cutScenePir<=0.02f)
            {
                isCutsceneWaitFin = true;
                isCutsceneEndFin = false;
                allWhitePanel.SetActive(true);
                allAllWhitePanelBG.gameObject.SetActive(false);
                allWhiteaPanelBG.color = new Color(allWhiteaPanelBG.color.r, allWhiteaPanelBG.color.g, allWhiteaPanelBG.color.b, 0.0f);
            }
        }
        
        if(!isCutsceneEndFin)
        {
            NPC1.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC1.color.a - 0.02f);
            NPC2.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC1.color.a - 0.02f);
            NPC3.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC1.color.a - 0.02f);
            NPC4.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC1.color.a - 0.02f);
            NPC5.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC1.color.a - 0.02f);
            allWhiteaPanelBG.color = new Color(allWhiteaPanelBG.color.r, allWhiteaPanelBG.color.g, allWhiteaPanelBG.color.b, allWhiteaPanelBG.color.a + 0.02f);
            if (allWhiteaPanelBG.color.a>=0.98f)
            {
                isCutsceneEndFin = true;
                StartCoroutine(LoadGame());
            }
        }
    }

    public void StartGame()
    {
        cutScenePD.stopped += EnterLoading;
        cutScenePD.Play();
    }

    void EnterLoading(PlayableDirector whatever)
    {
        cutScenePD.stopped -= EnterLoading;
        loadingPanel.SetActive(true);
        //StartCoroutine(LoadGame());
        isCutsceneFin = false;
    }

    IEnumerator LoadGame()
    {
        //yield return new WaitForEndOfFrame();
        async = SceneManager.LoadSceneAsync(1);
        yield return null;
    }
}
