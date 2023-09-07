using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRotate : MonoBehaviour
{
    public Camera camera;
    private Renderer rend;
    private GameObject boxx,obj;
    Vector3 mouseinitial;
    Vector3 mouseend;
    public float speed = 0.01f;
    public List<GameObject> gameobjects=new List<GameObject>();
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<Target>() != null)
                {
                    boxx = hitInfo.collider.gameObject;
                    rend = boxx.GetComponent<Renderer>();
                    rend.material.color = Color.yellow;
                    gameobjects.Add(boxx);
                }
            }
        }
        obj = gameobjects.Last();
    }  


    private void OnMouseDrag()
    {
        mouseend = Input.mousePosition;
        float initialangle = Mathf.Atan2(mouseinitial.x - obj.transform.position.x, mouseinitial.z - obj.transform.position.z) * Mathf.Rad2Deg * speed;
        float finalangle = Mathf.Atan2(mouseend.x - obj.transform.position.x, mouseend.z - obj.transform.position.z) * Mathf.Rad2Deg * speed;
        float difference = finalangle - initialangle;
        //Debug.Log(difference + "");
        obj.transform.RotateAround(Vector3.up, difference);
    }

    private void OnMouseDown()
    {
        mouseinitial = Input.mousePosition;
    }

}
