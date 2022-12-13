using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtons : MonoBehaviour
{
    [SerializeField] GameObject[] Canvases;
    [SerializeField] GameObject[] ActiveButtons;
    [SerializeField] GameObject[] PassiveButtons;

    bool Activator;

    private void Start()
    {
        SelenstCanvas(0);
    }
    public void SelenstCanvas(int NumCanvas)
    {
        for (int i = 0; i < Canvases.Length; i++)
        {
            Activator = NumCanvas == i ? true : false;
            Canvases[i].SetActive(Activator);
            ActiveButtons[i].SetActive(Activator);
            PassiveButtons[i].SetActive(!Activator);

        }
    }

}
