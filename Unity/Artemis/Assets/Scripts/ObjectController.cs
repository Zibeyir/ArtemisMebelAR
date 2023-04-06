using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
public class ObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(.1f, .1f, 0.1f);
        gameObject.AddComponent<LeanDragTranslate>();
        gameObject.AddComponent<LeanTwistRotateAxis>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
