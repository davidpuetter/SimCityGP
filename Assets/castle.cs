using UnityEngine;
using System.Collections;

public class castle : MonoBehaviour {

    public Color hoverColor;
    public Material startColor;

    // Use this for initialization
    void Start () {
        
    }
    void OnMouseEnter()
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = hoverColor;
        }
        
    }

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
