using UnityEngine;

public class ARReset : MonoBehaviour
{
    public PlaceObject placeScript;

    public void ResetScene()
    {
        if (placeScript.placedObject != null)
        {
            Destroy(placeScript.placedObject);
            placeScript.placedObject = null;
        }
    }
}