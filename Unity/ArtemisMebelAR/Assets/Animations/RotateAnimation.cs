using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : IAnimation
{
    public LeanTweenType leanTypeAppear;
    public LeanTweenType leanTypeDisApear;
    public Vector3 rotAppear;
    public Vector3 rotDisApear;


    public override void Appear()
    {
        LeanTween.rotate(gameObject, rotAppear, Time).setEase(leanTypeAppear);
    }

    public override void DisApear()
    {
        LeanTween.rotate(gameObject, rotDisApear, Time).setEase(leanTypeDisApear);
    }
}
