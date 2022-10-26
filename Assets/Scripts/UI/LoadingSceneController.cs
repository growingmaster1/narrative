using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    public SpriteRenderer NPC1, NPC2, NPC3, NPC4, NPC5;
    public Image AllBlackPanelBG;
    AsyncOperation async;
    [SerializeField]
    bool isInitFin = false, isLoadingFin = false, isEndingFin = false;

    private void Awake()
    {
        Application.backgroundLoadingPriority = ThreadPriority.Low;
    }

    private void FixedUpdate()
    {
        if(!isInitFin)
        {
            NPC1.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC1.color.a + 0.02f);
            NPC2.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC2.color.a + 0.02f);
            NPC3.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC3.color.a + 0.02f);
            NPC4.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC4.color.a + 0.02f);
            NPC5.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC5.color.a + 0.02f);
            if(NPC1.color.a>=1.0f)
            {
                isInitFin = true;
                StartCoroutine(LoadGame());
                async.allowSceneActivation = false;
            }
        }
        else if(!isEndingFin&&isLoadingFin)
        {
            NPC1.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC1.color.a - 0.02f);
            NPC2.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC2.color.a - 0.02f);
            NPC3.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC3.color.a - 0.02f);
            NPC4.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC4.color.a - 0.02f);
            NPC5.color = new Color(NPC1.color.r, NPC1.color.g, NPC1.color.b, NPC5.color.a - 0.02f);
            AllBlackPanelBG.color = new Color(AllBlackPanelBG.color.r, AllBlackPanelBG.color.g, AllBlackPanelBG.color.b, AllBlackPanelBG.color.a + 0.02f);
            if(AllBlackPanelBG.color.a>=1.0f)
            {
                isEndingFin = true;
                async.allowSceneActivation = true;
            }
        }
    }

    IEnumerator LoadGame()
    {
        async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!async.isDone)
        {
            if(async.progress>=0.90f)
            {
                isLoadingFin = true;
                
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
