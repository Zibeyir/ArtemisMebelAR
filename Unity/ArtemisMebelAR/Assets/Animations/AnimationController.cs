using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationController : MonoBehaviour
{
    public UnityEvent apperEnd;
    public UnityEvent disApperEnd;

    public IAnimation[] animations;
    public float Time { get; protected set; }
    public float smallTime { get; protected set; }
    public bool opened;
    

    private void Awake()
    {
        animations = GetComponents<IAnimation>();

            animations[0].apperEnd = apperEnd;
            animations[0].disApperEnd = disApperEnd;

        //     foreach (var item in animations)
        //     {
        //         item.apperEnd = apperEnd;
        //         item.disApperEnd = disApperEnd;
        //     }
        SetBiggesTime();
    }


    private void SetBiggesTime()
    {
        foreach (var item in animations)
        {
            if (Time < item.Time)
            {
                Time = item.Time;
            }
        }
        smallTime = Time;
        SetSmallestTime();
    }
    private void SetSmallestTime()
    {
        foreach (var item in animations)
        {
            if (smallTime > item.Time)
            {
                smallTime = item.Time;
            }
        }
    }
    public void PlayApearAnim()
    {
       foreach (var item in animations)
       {
           if (item.isAppear)
           {
               continue;
           }
           item.Appear();
           item.isAppear = true;
           opened = true;
       }
       
    }

    public void PlayDisApearAnim()
    {

        foreach (var item in animations)
        {
            if (!item.isAppear)
            {
                continue;
            }
            item.DisApear();
            item.isAppear = false;
            opened = false;
        }
    }
    
}
