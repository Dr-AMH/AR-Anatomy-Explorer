using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    void OnMouseDown()
    {
        //Debug.Log("Object Clicked - Show Info");
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 10, Color.red);
    }
}