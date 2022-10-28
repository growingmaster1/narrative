using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Floating : MonoBehaviour
{
    private Vector3 startPos = Vector3.zero;
    public float duration;
    public float offset;
    private Tweener tweener;

    public bool isHorizontal;

    private void OnEnable()
    {
        if(tweener!=null)
        {
            tweener.Kill();
        }
        if(startPos == Vector3.zero)
        {
            startPos = transform.position;
        }
        transform.position = startPos;
        if(!isHorizontal)
        {
            tweener = transform.DOMove(startPos + new Vector3(0, offset, 0), duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
        }
        else
        {
            tweener = transform.DOMove(startPos + new Vector3(offset, 0, 0), duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
        }
    }
}
