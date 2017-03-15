using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {

    public float mouseX;
    public float mouseY;
    public bool orbitY = false;
    public float mousechangeX;

    //variables that can be altered in Unity
    public float cameraZoomMax = 20f;
    public float cameraZoomMin = -20f;
    public float cameraDistance = 10f;
    public float scrollSpeed = 0.5f;

    public GameObject target = null;

    // Update is called once per frame
    void Update()
    {
        mouseRotation();

        //tracks mouse position
        mouseX = Input.mousePosition.x;

        //set cameradistance as the amount scrolled * speed variable
        cameraDistance = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

        //limits the scroll speed
        cameraDistance = Mathf.Clamp(cameraDistance, cameraZoomMin, cameraZoomMax);

        //stops the camera zooming into the floor void
        if (transform.position.y >= 150 && cameraDistance > 0)
        {
            transform.Translate(new Vector3(0, 0, cameraDistance));
        }

        //limits the amount the camera can zoom out
        else if (transform.position.y <= 250 && cameraDistance < 0)
        {
            transform.Translate(new Vector3(0, 0, cameraDistance));
        }
    }

    public void mouseRotation()
            {
        //right click
        if (Input.GetMouseButton(1))
        {
            //if the mouse has moved
            if (Input.mousePosition.x != mouseX)
            {
                //rotation magnitude based on mouse distance moved
                mousechangeX = Input.mousePosition.x - mouseX;
            }
            else
                //dont move
                mousechangeX = 0;
        }
            //if the camera target exists
            if (target != null)
            {
                //force the camera to look at the target
                transform.LookAt(target.transform);
                
                //
                if(orbitY)
                {
                    //rotate based on the mouse drag magnitude 
                    transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * mousechangeX * 6);

                 }
            }
        }
    }

