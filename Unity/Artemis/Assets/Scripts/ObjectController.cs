using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
public class ObjectController : MonoBehaviour
{
  
    void Start()
    {
        

        transform.localScale = new Vector3(.1f, .1f, 0.1f);
        gameObject.AddComponent<LeanDragTranslate>();
        gameObject.AddComponent<LeanTwistRotateAxis>();
        ARPlacement ar = FindObjectOfType<ARPlacement>();
        transform.position = ar.position;
        transform.rotation = ar.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
