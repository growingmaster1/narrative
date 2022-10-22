using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    public float fadeInSpeed = 0.02f;
    public float stopTimePir = 1.0f;
    float stopTimePirTemp;
    public GameObject allWhitePanel;
    public GameObject headphonePanel;
    public GameObject loadingPanel;
    CanvasGroup headphonePanelCG;
    UnityEngine.UI.Image allWhiteaPanelBG;
    bool isAWPFin = false, isHPFin = false, isStopTime1Fin = false, isStopTime2Fin = false, isHPFinFin=false;

    private void Awake()
    {
        headphonePanelCG = headphonePanel.GetComponent<CanvasGroup>();
        allWhiteaPanelBG = allWhitePanel.GetComponent<UnityEngine.UI.Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void StartGame()
    {
        loadingPanel.SetActive(true);
        StartCoroutine(LoadGame());
    }



    IEnumerator LoadGame()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        while(!operation.isDone)
        {
            operation.allowSceneActivation = true;
            //Debug.Log(operation.progress);
            yield return null;
        }
    }
}
