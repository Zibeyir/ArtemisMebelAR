using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCollorAnimation : IAnimation
{
    private Text animObject;
    public Color active;
    public Color inactive;

    public override void Appear()
    {
        LeanTween.value(gameObject, inactive, active, Time).setOnUpdate(
              (Color val) => {
                  animObject.color = val;
              }).setEaseInOutQuad();
    }

    public override void DisApear()
    {
        LeanTween.value(gameObject, active, inactive, Time).setOnUpdate(
         (Color val) =>
         {
             animObject.color = val;
         }).setEaseInOutQuad(); 
    }

  
    private void Awake()
    {
        animObject = GetComponent<Text>();
    }

  

}
