using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject infoPanel;

    public void ShowInfo()
    {
        infoPanel.SetActive(true);
    }
}