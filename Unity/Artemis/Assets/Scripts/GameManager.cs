using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Canvases")]
    public GameObject OtherCanvases;
    public GameObject ARCanvas;
    public GameObject LoginCanvas;
    [SerializeField]List<GameObject> AllCanvasList;

    void Awake()
    {
        instance = this;
        StartFunc();
    }

    private void StartFunc()
    {
        ARCanvas.SetActive(false);
        ActivatedCanvas(1 == PlayerPrefs.GetInt("Login", 0) ? OtherCanvases : LoginCanvas);
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
        foreach (GameObject item in AllCanvasList)
        {
            item.SetActive(gameObject == item);
        }
    }

}
//if (instance == null)
//{
//    instance = this;
//    DontDestroyOnLoad(gameObject);
//}
//else if (instance != this)
//{
//    Destroy(gameObject);
//}   
