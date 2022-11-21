using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mebel : MonoBehaviour
{

    public Texture[] MebelTextures;

    public Transform[] MebelParts;

    public GameObject MebelObject;

    void Start()
    {
        MebelParts = MebelObject.GetComponentsInChildren<Transform>();
    }

  
}
