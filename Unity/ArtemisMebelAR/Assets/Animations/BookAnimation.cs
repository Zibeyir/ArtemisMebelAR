using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookAnimation : MonoBehaviour
{
    public Vector3 closeMove;
    private Vector3 openMove = new Vector3(-200, 0, 0);
    public Text Text;
    public Image rotationObj;
    public Sprite coverImage;
    private Vector3 initialPos;
    private Button btnComp;
    private RectTransform rectComp;
    public float closeTime;
    public float openTime;
    private void Awake()
    {
        btnComp = gameObject.GetComponent<Button>();
        rectComp = gameObject.GetComponent<RectTransform>();
        initialPos = rectComp.anchoredPosition3D;
    }
    public void open()
    {
        LeanTween.move(rectComp, openMove, openTime).setEase(LeanTweenType.easeInOutQuad);
        btnComp.enabled = false;
        LeanTween.rotateY(rotationObj.gameObject, 180, openTime).setEase(LeanTweenType.easeInOutQuad).setOnUpdate((float a) =>
        {
            if (rotationObj.transform.eulerAngles.y >= 90)
            {
                rotationObj.sprite = null;
                Text.gameObject.SetActive(true);
            }
        });
    }
    public void close()
    {
        
        LeanTween.move(rectComp, closeMove, closeTime).setEase(LeanTweenType.easeInOutQuad); 
        LeanTween.rotateY(rotationObj.gameObject, 0, closeTime).setEase(LeanTweenType.easeInOutQuad).setOnUpdate((float a) => {
          //  Debug.Log(rotationObj.transform.rotation.y);
            if (rotationObj.transform.eulerAngles.y <= 90)
            {
                rotationObj.sprite = coverImage;
                btnComp.enabled = true;
                Text.gameObject.SetActive(false);
            }
        });
    }

    public void goToInitial()
    {
        LeanTween.move(rectComp, initialPos, closeTime).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.rotateY(rotationObj.gameObject, 0, closeTime).setEase(LeanTweenType.easeInOutQuad).setOnUpdate((float a) => {
            if (rotationObj.transform.eulerAngles.y <= 90)
            {
                rotationObj.sprite = coverImage;
                btnComp.enabled = true;
                Text.gameObject.SetActive(false);
            }
        });
    }
}
