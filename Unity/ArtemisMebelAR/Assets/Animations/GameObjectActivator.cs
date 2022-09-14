using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectActivator : IAnimation
{
   public Behaviour[] Component;
    public override void Appear()
    {
        StartCoroutine(Waiter(true));
    }
    IEnumerator Waiter(bool active)
    {
        yield return new WaitForSeconds(Time);
        foreach (var item in Component)
        {
            item.enabled = active;
        }
    }

    public override void DisApear()
    {
        StartCoroutine(Waiter(false));
    }
    
}
