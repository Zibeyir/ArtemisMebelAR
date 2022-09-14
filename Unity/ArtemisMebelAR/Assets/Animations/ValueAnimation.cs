using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueAnimation : IAnimation
{
  //  public float fillAmountTime;
    public float fillAmountEnd;
    public override void Appear()
    {
         LeanTween.value(gameObject, updateAmountValue, 0,  fillAmountEnd , Time);
    }

    void updateAmountValue(float val)
    {
        gameObject.GetComponent<Image>().fillAmount = val;
    }


    public override void DisApear()
    {
        // throw new System.NotImplementedException();
    }
}
