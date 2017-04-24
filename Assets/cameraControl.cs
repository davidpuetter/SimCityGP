using UnityEngine;
using UnityEngine.Extensions;
using System.Collections;

public class cameraControl : MonoBehaviour
{

    public float mouseX;
    public float mouseY;
    public bool orbitY = false;
    public float mousechangeX;

    //variables that can be altered in Unity
    public float cameraZoomMax = 20f;
    public float cameraZoomMin = -20f;
    public float cameraDistance = 10f;
    public float scrollSpeed = 0.5f;

    // camera drag variables
    private Vector3 lastMousePos;

    public GameObject target = null;

    void Start()
    {
        lastMousePos = Vector3.zero;
    }

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

    // cool version of update that waits until update is done, good for camera control
    void LateUpdate()
    {
        // establish a new move vector
        Vector3 moveVector = new Vector3(0, 0, 0);

        // detect key presses and move in relevant direction
        if (Input.GetKey(KeyCode.A))
        {
            moveVector.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVector.z -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVector.x += 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveVector.z += 1;
        }

        // detect middle mouse button
        if (Input.GetMouseButton(2))
        {
            // obtain difference between two mouse positions to get direction of drag
            Vector3 deltaMousePos = (Input.mousePosition - lastMousePos);

            // update movement, the (-) outside the variables allows for movement direction to be opposite of drag direction
            moveVector += new Vector3(-deltaMousePos.x / 10, 0, -deltaMousePos.y / 10);
        }

        /* so far, so good. this is where things get a little more tricky.
         * the panning so far would work if we couldn't rotate the camera, but
         * we can. this means that the drag and movement would be always set to
         * move in world co-ordinates, no matter the rotation. this would really
         * disorientate the player. sadly, since our camera is rotated towards the
         * plane, we can't use its local coordinates either (aka the easy fix), as the 
         * two axes we would pan on wouldn't be "flat".
         */

        // obtain current rotation
        var oldXRotation = transform.localEulerAngles.x;

        // set the local x rotation to 0, gotta do this so our camera will move
        // in the right direction with relevance to where it is facing
        transform.SetLocalEulerAngles(0.0f);

        // actually apply the final movement vector to the camera
        transform.Translate(moveVector);

        // set the old x rotation.
        transform.SetLocalEulerAngles(oldXRotation);

        // update lastMousePos and that's the panning done
        lastMousePos = Input.mousePosition;
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
            //force the camera to look at the target -- removed to allow panning
            //transform.LookAt(target.transform);

            //
            if (orbitY)
            {
                //rotate based on the mouse drag magnitude 
                transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * mousechangeX * 6);

            }
        }
    }
}

