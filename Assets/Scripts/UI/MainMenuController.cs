using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    public float fadeInSpeed = 0.02f;
    public float stopTimePir = 1.0f;
    public GameObject allWhitePanel;
    public GameObject headphonePanel;
    public GameObject loadingPanel;
    public Slider processIndiSlider;
    CanvasGroup headphonePanelCG;
    UnityEngine.UI.Image allWhiteaPanelBG;
    bool isAWPFin = false, isHPFin = false, isStopTimeFin = false, onLoading=false, isOKforTransition=false;
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
            if(allWhiteaPanelBG.color.a<=0.01f)
            {
                allWhitePanel.SetActive(false);
                isAWPFin = true;
            }
        }
        else if(isStopTimeFin==false)
        {
            stopTimePir -= 0.02f;
            if(stopTimePir<=0.01f)
            {
                isStopTimeFin = true;
            }
        }
        else if(isHPFin==false)
        {
            headphonePanelCG.alpha -= fadeInSpeed;
            if(headphonePanelCG.alpha<=0.01f)
            {
                headphonePanel.SetActive(false);
                isHPFin = true;
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
            Debug.Log(operation.progress);
            yield return null;
        }
    }
}
