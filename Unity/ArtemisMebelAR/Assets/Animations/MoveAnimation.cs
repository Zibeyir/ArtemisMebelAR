using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class MoveAnimation : IAnimation
{
    public LeanTweenType leanTypeAppear;
    public LeanTweenType leanTypeDisApear;
    public Vector3 positionApear;
    public Vector3 disApear;
    public bool getCurrentPos;
    void Awake()
    {
        if(getCurrentPos)
            disApear = transform.localPosition;
    }
    
    public override void Appear()
    {
       LeanTween.moveLocal(gameObject, positionApear, Time).setEase(leanTypeAppear).setOnComplete(()=>apperEnd.Invoke());
    }

    public override void DisApear()
    {
       LeanTween.moveLocal(gameObject, disApear, Time).setEase(leanTypeDisApear).setOnComplete(() => disApperEnd.Invoke());
    }
}
