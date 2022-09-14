using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorAnimation : MonoBehaviour
{
    public Color active;
    public Color inactive;
    public float Time;
    private Image imgComp;
    void Awake()
    {
        imgComp = GetComponent<Image>();
    }

    // Update is called once per frame
    public void Open()
    {
        LeanTween.value(gameObject, inactive, active, Time).setOnUpdate(
            (Color val) => {
                imgComp.color = val;
            }).setEaseInOutQuad();
    }

    public void Close()
    {
        LeanTween.value(gameObject, active, inactive, Time).setOnUpdate(
          (Color val) =>
          {
              imgComp.color = val;
          });
    }
}
