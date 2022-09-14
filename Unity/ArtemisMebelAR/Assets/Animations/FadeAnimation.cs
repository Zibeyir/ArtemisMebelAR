using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadeAnimation : IAnimation
{

    public LeanTweenType leanTypeAppear;
    public LeanTweenType leanTypeDisApear;
    public override void Appear()
    {
       LeanTween.alpha(objectRect, 1, Time).setEase(leanTypeAppear).setOnComplete(() => {
           apperEnd.Invoke();
       });
    }

    public override void DisApear()
    {
       LeanTween.alpha(objectRect, 0, Time).setEase(leanTypeDisApear).setOnComplete(()=> {
           disApperEnd.Invoke(); });
    }
}
