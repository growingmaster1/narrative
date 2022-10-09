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
    public Slider processIndiSlider;
    CanvasGroup headphonePanelCG;
    UnityEngine.UI.Image allWhiteaPanelBG;
    bool isAWPFin = false, isHPFin = false, isStopTime1Fin = false, isStopTime2Fin = false, isHPFinFin=false, onLoading=false, isOKforTransition=false;
    float realProgress = 0.0f;

    private void Awake()
    {
        headphonePanelCG = headphonePanel.GetComponent<CanvasGroup>();
        allWhiteaPanelBG = allWhitePanel.GetComponent<UnityEngine.UI.Image>();
        processIndiSlider = loadingPanel.transform.GetChild(1).GetComponent<Slider>();
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
        if(onLoading==true)
        {
            if(processIndiSlider.value<0.88f)
            {
                processIndiSlider.value += 0.006f;
            }
            else if(realProgress>=0.88f)
            {
                processIndiSlider.value += 0.006f;
                if(processIndiSlider.value>=0.95f)
                {
                    isOKforTransition = true;
                }
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

        onLoading = true;
        while(!operation.isDone)
        {
            realProgress = operation.progress;
            operation.allowSceneActivation = isOKforTransition;
            //Debug.Log(operation.progress);
            yield return null;
        }
    }
}
