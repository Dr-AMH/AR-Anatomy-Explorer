using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class PlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject infoPanel;

    public GameObject placedObject;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        infoPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began) return;

        // 🔹 1. Check if object tapped
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("ARObject"))
            {
                Debug.Log("Object tapped");
                infoPanel.SetActive(true);
                return;
            }
        }

        // 🔹 2. Place / Move object
        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;

            if (placedObject == null)
            {
                placedObject = Instantiate(objectToPlace, pose.position, pose.rotation);
                placedObject.tag = "ARObject";
            }
            else
            {
                placedObject.transform.position = pose.position;
            }
        }
    }
}