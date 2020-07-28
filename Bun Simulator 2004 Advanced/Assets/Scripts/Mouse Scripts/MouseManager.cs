using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager: MonoBehaviour
{
    private static MouseManager _instance;
    public static MouseManager Instance
    {
        get
        {
            //Checks if the MouseManager has been instantiated
            if (_instance == null)
                Debug.LogError("The MouseManager is NULL");
            return _instance;
        }
        
    }
        private void Awake()
    {

        //Initializes the MouseManager
        _instance = this;
        Debug.Log("Mouse Manager, Online!");
    }

    private RaycastHit2D mouseOver;
    void Update()
    {
        DetectMouseover();
    }

    //Mouse Manager must have functionality for:
        //Detecting if your mouse is over something you can click on
        //Detecting where your mouse is so the bunny can react
        //Switching cursors i.e. for petting, or to scritchy hand to tempt the bunny to hop to a place on the carpet
        //Clicking and dragging draggable objects
        //Tossing draggable objects
        //Detecting mouse velocity for petting the rabbit


    GameObject DetectMouseover() //Returns GameObject that the mouse is over. Must have a collider.
    {
        Camera cam = Camera.main;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2 (cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0);
       
        if (hit)
        {
            Debug.Log("Mouse over "+ hit.transform.name);

            return hit.transform.gameObject;
        }

        else return null;
    }

    GameObject DetectMouseClick() 
    {

    }
}


