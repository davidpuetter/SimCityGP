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

        if (buttonVal == 1)
        {
            gameMoney.instance.resourceCost = gameMoney.instance.tavernResourceCost;
        }
        else if (buttonVal == 2)
        {
            gameMoney.instance.resourceCost = gameMoney.instance.houseResourceCost;

        }
        else if (buttonVal == 3)
        {
            gameMoney.instance.resourceCost = gameMoney.instance.shopResourceCost;

        }
        else if (buttonVal == 4)
        {
            gameMoney.instance.resourceCost = 0;

        }
    }
}
