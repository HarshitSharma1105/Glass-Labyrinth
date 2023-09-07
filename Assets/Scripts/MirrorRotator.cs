using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MirrorRotator : MonoBehaviour
{
    Vector3 mouseinitial;
    Vector3 mouseend;
    public float speed = 0.01f;

    private void OnMouseDown()
    {
        mouseinitial = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        mouseend = Input.mousePosition;
        float initialangle = Mathf.Atan2(mouseinitial.x - transform.position.x, mouseinitial.z - transform.position.z) * Mathf.Rad2Deg * speed;
        float finalangle = Mathf.Atan2(mouseend.x - transform.position.x, mouseend.z - transform.position.z) * Mathf.Rad2Deg * speed;
        float difference = finalangle - initialangle;
        //Debug.Log(difference + "");
        transform.RotateAround(Vector3.up, difference);
    }
}