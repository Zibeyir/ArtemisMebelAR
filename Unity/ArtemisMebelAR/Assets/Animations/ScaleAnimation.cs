using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimation : IAnimation
{
    public LeanTweenType leanTypeAppear;
    public LeanTweenType leanTypeDisApear;
    public Vector3 appearSize;
    public Vector3 disappearSize;

    public override void Appear()
    {
        LeanTween.scale(objectRect, appearSize, Time).setEase(leanTypeAppear).setOnComplete(()=> apperEnd.Invoke());
    }

    public override void DisApear()
    {
        LeanTween.scale(objectRect, disappearSize, Time).setEase(leanTypeDisApear).setOnComplete(() => disApperEnd.Invoke());
    }
}
