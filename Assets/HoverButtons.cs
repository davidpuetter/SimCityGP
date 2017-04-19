using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverButtons : MonoBehaviour {

    public GameObject Tavern;
    public GameObject House;
    public GameObject Shop;
    public GameObject Armory;

    void Start ()
    {
		
	}

	void Update ()
    {
		
	}

    public void ToggleTavern()
    {
        Tavern.SetActive(!Tavern.activeSelf);
    }

    public void ToggleHouse()
    {
        House.SetActive(!House.activeSelf);
    }

    public void ToggleShop()
    {
        Shop.SetActive(!Shop.activeSelf);
    }

    public void ToggleArmory()
    {
        Armory.SetActive(!Armory.activeSelf);
    }
}
