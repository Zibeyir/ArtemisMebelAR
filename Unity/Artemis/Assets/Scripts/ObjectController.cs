using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
public class ObjectController : MonoBehaviour
{
  
    void Start()
    {
        

        transform.localScale = new Vector3(.05f, .05f, 0.05f);
        //gameObject.AddComponent<LeanDragTranslate>();
        gameObject.AddComponent<LeanTwistRotateAxis>();
        ARPlacement ar = FindObjectOfType<ARPlacement>();
        ar.SpawnObjectActive();
        transform.position = ar.position;
        transform.rotation = ar.rotation;
        BoxCollider col= gameObject.AddComponent<BoxCollider>();
        col.center = new Vector3(0, 10, 0);
        col.size = new Vector3(40, 20, 10);
        
        FindObjectOfType<PlacementWithDraggingDroppingController>().placedObject=this.gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
