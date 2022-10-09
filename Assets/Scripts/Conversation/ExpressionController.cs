using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionController : MonoBehaviour
{
    public GameObject Emoji;
    public GameObject Angry;
    public GameObject Amazed;
    public GameObject Note;
    public GameObject Sleep;
    public GameObject Awkward;
    public GameObject Speechless;
    public GameObject Confused;

    public Sprite Sad;
    public Sprite Eat;
    public Sprite Daze;
    public Sprite Happy;
    public Sprite Smile;
    public Sprite Disappoint;
    public Sprite Cool;
    public Sprite Despise;
    public Sprite Xwx;
    public Sprite Busy;

    public void PlayExpression(string expression)
    {
        GameObject signal = GetType().GetField(expression)?.GetValue(this) as GameObject;
        if(signal!=null)
        {
            signal.SetActive(true);
        }
        else
        {
            PlayEmoji(expression);
        }
    }

    public void PlayEmoji(string expression)
    {
        Sprite signal = GetType().GetField(expression)?.GetValue(this) as Sprite;
        if(signal != null)
        {
            Emoji.GetComponent<SpriteRenderer>().sprite = signal;
            Emoji.SetActive(true);
        }
    }

    public void StopExpression(string expression)
    {
        GameObject signal = GetType().GetField(expression).GetValue(this) as GameObject;
        if (signal != null)
        {
            signal.SetActive(false);
        }
        else
        {
            Emoji.SetActive(false);
        }
    }
}
