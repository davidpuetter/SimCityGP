using UnityEngine;
using System.Collections;

public class castle : MonoBehaviour {

    public Color hoverColor;
    public Material startColor;

    // Use this for initialization
    void Start () {
        
    }

    //when hovering over the castle
    void OnMouseEnter()
    {
        //colour all the objects that build the castle
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            //set colour as the defined one
            r.material.color = hoverColor;
        }
        
    }

    //reset colour when mouse leaves
    void OnMouseExit()
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material = startColor;
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
