using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogBox : MonoBehaviour,IInit,IPointerClickHandler
{
    public static DialogBox instance;
    public GameObject joystick;
    public GameObject dialogBox;
    public GameObject scrollRegion;
    public GameObject scrollContent;
    public GameObject branchButton;
    public GameObject buttonHolder;
    public GameObject continueButton;
    public GameObject scrollUp;
    public GameObject scrollDown;

    public Text speaker;
    public Text text;

    private Tweener textPrinter;

    private ScrollRect scroll;
    private RectTransform scrollRect;
    private RectTransform contentRect;

    private Branch next;
    private Vector3 basePos;

    private bool arrived = false;
    private bool continuable = false;

    private float speekSpeed = 0.05f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Init()
    {
        scroll = scrollRegion.GetComponent<ScrollRect>();
        scrollRect = scrollRegion.GetComponent<RectTransform>();
        contentRect = scrollContent.GetComponent<RectTransform>();
        basePos = dialogBox.transform.position;
    }

    public void Update()
    {
        if(arrived)
        {
            if (scrollRect.rect.height > contentRect.rect.height)
            {
                scrollUp.SetActive(false);
                scrollDown.SetActive(false);
            }
            else
            {
                if (scroll.verticalNormalizedPosition > float.Epsilon)
                {
                    scrollDown.SetActive(true);
                }
                else
                {
                    scrollDown.SetActive(false);
                }
                if (1 - scroll.verticalNormalizedPosition > float.Epsilon)
                {
                    scrollUp.SetActive(true);
                }
                else
                {
                    scrollUp.SetActive(false);
                }
            }
        }
    }

    public void ParseBranches(IList<Branch> aBranches)
    {
        foreach (Transform item in buttonHolder.transform)
        {
            Destroy(item.gameObject);
        }

        if (aBranches.Count == 0)
        {
            next = null;
            return;
        }

        if (aBranches.Count == 1)
        {
            next = aBranches[0];
            return;
        }

        //找到所有带有SingleBranch的组件并赋值
        for (int i = 0; i < aBranches.Count; ++i)
        {
            GameObject btn = Instantiate<GameObject>(branchButton);
            btn.transform.SetParent(buttonHolder.transform);

            btn.GetComponent<SingleBranch>().AssignBranch(aBranches[i]);
            btn.GetComponentInChildren<Image>().DOFade(0, 0);
            btn.GetComponentInChildren<Text>().DOFade(0, 0);
        }
        next = null;
    }

    public void startDialog()
    {
        joystick.SetActive(false);
        dialogBox.SetActive(true);
        dialogBox.transform.DOMove(dialogBox.transform.position + new Vector3(dialogBox.GetComponent<RectTransform>().rect.width, 0, 0), 0.2f).From().SetUpdate(true).OnComplete(Arrived);
    }

    public void Arrived()
    {
        arrived = true;
    }

    public void finishDialog()
    {
        arrived = false;
        TimeManager.instance.ContinueTime();
        Player.instance.atDialog = false;
        Player.instance.moveable = true;
        dialogBox.transform.DOMove(dialogBox.transform.position + new Vector3(dialogBox.GetComponent<RectTransform>().rect.width, 0, 0), 0.2f).SetUpdate(true).OnComplete(BackArrived);
    }

    public void BackArrived()
    {
        arrived = false;
        dialogBox.transform.position = basePos;
        dialogBox.SetActive(false);
        joystick.SetActive(true);
        DialogManager.instance.CompleteDialog();
    }

    public void DefineSpeaker(string inSpeaker)
    {
        speaker.text = inSpeaker + ":　";
    }

    public void PrintText(string content)
    {
        if(textPrinter!=null)
        {
            textPrinter.Kill();
        }
        continuable = false;
        TimeManager.instance.ContinueTime();
        continueButton.SetActive(false);
        text.text = "";
        textPrinter = text.DOText("　　" + content, content.Length * speekSpeed).SetEase(Ease.Linear).OnComplete(Paused);
    }

    public void Paused()
    {
        continuable = true;
        if(buttonHolder.transform.childCount != 0)
        {
            Sequence fadingSeq = DOTween.Sequence().SetUpdate(true);
            for(int i=0;i<buttonHolder.GetComponentsInChildren<Image>().Length;++i)
            {
                fadingSeq.Append(buttonHolder.GetComponentsInChildren<Image>()[i].DOFade(1, 0.1f));
                fadingSeq.Append(buttonHolder.GetComponentsInChildren<Text>()[i].DOFade(1, 0.1f));
            }
            fadingSeq.Play();
        }
        else
        {
            continueButton.SetActive(true);
        }
        TimeManager.instance.PauseTime();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(continuable)
        {
            if (next != null)
            {
                DialogManager.FlowPlayer.Play(next);
            }
            if(next == null)
            {
                if (buttonHolder.transform.childCount == 0)
                {
                    finishDialog();
                }
            }
        }
    }
}
