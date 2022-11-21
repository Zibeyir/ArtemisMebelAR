using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject OtherCanvases;
    public GameObject ARCanvas;
    public GameObject LoginCanvas;

    [SerializeField]List<GameObject> Canvases;

    void Awake()
    {
        instance = this;
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else if (instance != this)
        //{
        //    Destroy(gameObject);
        //}   

        StartFunc();
    }

    private void StartFunc()
    {
        ARCanvas.SetActive(false);
        if (1 == PlayerPrefs.GetInt("Login", 0) ? true : false)
        {
            ActivatedCanvas(OtherCanvases);
        }
        else
        {
            ActivatedCanvas(LoginCanvas);
        }
    }

    public void MebelButton()
    {
        ActivatedCanvas(ARCanvas);
    }
    public void BackfromARButton()
    {
        ActivatedCanvas(OtherCanvases);
    }
    public void LoginFunc()
    {
        ActivatedCanvas(OtherCanvases);
    }

    public void ActivatedCanvas(GameObject gameObject)
    {
        foreach (GameObject item in Canvases)
        {
            item.SetActive(gameObject == item);
        }
    }

}
