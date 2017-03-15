using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameMoney : MonoBehaviour {

    public static gameMoney instance;

    public float Money = 1f;
    public float Resources = 1f;

    public float Population = 1f;
    public float PopulationMax = 1f;
    public float CPS = 1f;
    public float PPM = 1f;

    public float shopCost = 1f;
    public float houseCost = 1f;
    public float tavernCost = 1f;
    public float armoryCost = 1f;

    public float shopResourceCost = 1f;
    public float houseResourceCost = 1f;
    public float tavernResourceCost = 1f;

    public float SelectedBuilding = 0f;

    public float cashTimer = 1f;
    public float cashCooldown = 1f;

    public Text moneyText;
    public Text populationText;
    public Text CPMText;
    public Text PPSText;
    public Text housecostLbl;
    public Text shopcostLbl;
    public Text bankcostLbl;
    public Text armorycostLbl;

    public Text powerText;



    public float tavernPopGrowth = 1f;
    public float houseMaxPopGrowth = 1f;
    public float shopProfitGrowth = 1f;
    public float armoryResourcesGiven = 1f;



    public float resourceCost;

    public float shopProfits = 1f;
    void Awake()
    {
        if (instance = null)
        {
            return;
        }
        instance = this;
    }



    public void Update ()
    {
        cashTimer -= Time.deltaTime;


        if (cashTimer <= 0)
        {
            cashTimer = cashCooldown;
            Money = Money + (CPS + (shopProfits * Population));

            if (Population + PPM >= PopulationMax)
            {
                Population = PopulationMax;
            }
            else
            Population = Population + PPM;

        }

        moneyText.text = "Gold: " + System.Math.Round(Money,0).ToString() + 'G';
        populationText.text = "Population: " + Mathf.Round(Population).ToString() + '/' + PopulationMax.ToString();

        CPMText.text = '+' + System.String.Format("{0:n}", System.Math.Round((CPS + (shopProfits * Population)), 2).ToString()) + "Gp/s";

        PPSText.text = '+' + System.Math.Round(PPM,2).ToString() + "pp/s";
        housecostLbl.text = System.Math.Round(houseCost,0).ToString() + 'G';
        shopcostLbl.text = System.Math.Round(shopCost, 0).ToString() + 'G';
        bankcostLbl.text = System.Math.Round(tavernCost, 0).ToString() + 'G';
        powerText.text = "Resources: " + Resources.ToString();
        armorycostLbl.text = System.Math.Round(armoryCost, 0).ToString() + 'G';
    }
}
