using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingCutsceneManager : MonoBehaviour
{
    public Image EndingCutsceneIMG;
    public Canvas EndingCanvas;
    bool isCutsceneEnter = false;
    static public EndingCutsceneManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void FixedUpdate()
    {
        if(isCutsceneEnter)
        {
            EndingCutsceneIMG.color = new Color(EndingCutsceneIMG.color.r, EndingCutsceneIMG.color.g, EndingCutsceneIMG.color.b, EndingCutsceneIMG.color.a + 0.02f);
            if(EndingCutsceneIMG.color.a>=0.99f)
            {
                isCutsceneEnter = false;
                SceneManager.LoadScene(0);
            }
        }

    }

    public void EnterEndingCutscene()
    {
        EndingCanvas.gameObject.SetActive(true);
        isCutsceneEnter = true;
    }
}
