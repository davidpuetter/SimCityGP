using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class button : MonoBehaviour {

    public float buttonVal;

    public GameObject master;
    private gameMoney gameManager;


    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        gameManager = master.GetComponent<gameMoney>();

    }
    public void OnMouseDown()
    {

        TaskOnClick();
    }
    public void TaskOnClick ()
    {

        //gameMoney.instance.SelectedBuilding = buttonVal;

        gameManager.SelectedBuilding = buttonVal;


        //If the button is the tavern
        if (buttonVal == 1)
        {
            //the resource cost is set to the cost of the tavern
            gameManager.resourceCost = gameManager.tavernResourceCost;
        }
        //house
        else if (buttonVal == 2)
        {
            gameManager.resourceCost = gameManager.houseResourceCost;

        }

        //shop
        else if (buttonVal == 3)
        {
            gameManager.resourceCost = gameManager.shopResourceCost;

        }

        //armory
        else if (buttonVal == 4)
        {
            gameManager.resourceCost = 0;

        }
    }
}
