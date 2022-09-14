using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AnimationController))]
public abstract class IAnimation:MonoBehaviour
{
    public float Time = 1;
    public bool isAppear;
    protected RectTransform objectRect;
    [HideInInspector]
    public UnityEvent apperEnd;
    [HideInInspector]
    public UnityEvent disApperEnd;

    private void Awake()
   {
       objectRect = GetComponent<RectTransform>();
   }

    public abstract void Appear();
    public abstract void DisApear();
}
