using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class button : MonoBehaviour {

    public float buttonVal;




    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        

    }
    public void OnMouseDown()
    {

        TaskOnClick();
    }
    public void TaskOnClick ()
    {

        gameMoney.instance.SelectedBuilding = buttonVal;

        //If the button is the tavern
        if (buttonVal == 1)
        {
            //the resource cost is set to the cost of the tavern
            gameMoney.instance.resourceCost = gameMoney.instance.tavernResourceCost;
        }
        //house
        else if (buttonVal == 2)
        {
            gameMoney.instance.resourceCost = gameMoney.instance.houseResourceCost;

        }

        //shop
        else if (buttonVal == 3)
        {
            gameMoney.instance.resourceCost = gameMoney.instance.shopResourceCost;

        }

        //armory
        else if (buttonVal == 4)
        {
            gameMoney.instance.resourceCost = 0;

        }
    }
}
