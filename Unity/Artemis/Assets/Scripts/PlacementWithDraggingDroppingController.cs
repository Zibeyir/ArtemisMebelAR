using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacementWithDraggingDroppingController : MonoBehaviour
{
    [SerializeField]
    private GameObject placedPrefab;

    [SerializeField]
    private GameObject welcomePanel;

    [SerializeField]
    private Button dismissButton;

    [SerializeField]
    private Button lockButton;

    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private float defaultRotation = 0;

    public GameObject placedObject;

    private Vector2 touchPosition = default;

    private ARRaycastManager arRaycastManager;

    private bool isLocked = false;

    private bool onTouchHold = false;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        //dismissButton.onClick.AddListener(Dismiss);

        //if (lockButton != null)
        //{
        //    lockButton.onClick.AddListener(Lock);
        //}
    }
    //private void Dismiss() => welcomePanel.SetActive(false);

    private void Lock()
    {
        isLocked = !isLocked;
        //lockButton.GetComponentInChildren<Text>().text = isLocked ? "Locked" : "Unlocked";
        //if (placedObject != null)
        //{
        //    placedObject.GetComponent<PlacementObject>()
        //        .SetOverlayText(isLocked ? "AR Object Locked" : "AR Object Unlocked");
        //}
    }

    void Update()
    {
        // do not capture events unless the welcome panel is hidden
   

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    //PlacementObject placementObject = hitObject.transform.GetComponent<PlacementObject>();
                    if (placedObject != null)
                    {
                        onTouchHold = true;

                        //onTouchHold = isLocked ? false : true;
                        //  placementObject.SetOverlayText(isLocked ? "AR Object Locked" : "AR Object Unlocked");
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                onTouchHold = false;
            }
        }

        if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (placedObject != null)
            {
                if (onTouchHold)
                {
                    placedObject.transform.position = hitPose.position;

                }
            }
            else
            {
              
            }
        }
    }
}