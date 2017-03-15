using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {

    public float mouseX;
    public float mouseY;
    public bool orbitY = false;
    public float mousechangeX;

    public float cameraDistanceMax = 20f;
    public float cameraDistanceMin = -20f;
    public float cameraDistance = 10f;
    public float scrollSpeed = 0.5f;

    public GameObject target = null;

    // Update is called once per frame
    void Update()
    {
        mouseRotation();
        mouseX = Input.mousePosition.x;

        cameraDistance = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);

        if (transform.position.y >= 150 && cameraDistance > 0)
        {
            transform.Translate(new Vector3(0, 0, cameraDistance));
        }
        else if (transform.position.y <= 250 && cameraDistance < 0)
        {
            transform.Translate(new Vector3(0, 0, cameraDistance));
        }
    }

    public void mouseRotation()
            {
        if (Input.GetMouseButton(1))
        {
            if (Input.mousePosition.x != mouseX)
            {
                mousechangeX = Input.mousePosition.x - mouseX;
            }
            else
                mousechangeX = 0;
        }
        
    

            if (target != null)
            {
                transform.LookAt(target.transform);
                
                if(orbitY)
                {
                    transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * mousechangeX * 6);

                 }


        }
        }

        
    }

