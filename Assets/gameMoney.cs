using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameMoney : MonoBehaviour
{

    public static gameMoney instance;

    //the variables that hold the current amount of a "currency"
    public float Money = 1f;
    public float Resource = 1f;
    public float Population = 1f;

    //cash per second and population per second
    //public float CPS = 1f;
    public float PPS = 0.3f;
    public float RRS = 0.1f;

    //Current max population,
    public float PopulationMax = 1f;

    //Starting cost of the buildings and alters as more are bought
    public float shopCost = 1f;
    public float houseCost = 1f;
    public float tavernCost = 1f;
    public float armoryCost = 1f;

    //how many resources to build the buildings
    public float shopResourceCost = 1f;
    public float houseResourceCost = 1f;
    public float tavernResourceCost = 1f;

    //the current building selected to be built (changed from button press)
    public float SelectedBuilding = 0f;

    //the frequency of cash collecting
    //tracks the countdown value
    public float cashTimer = 1f;
    //the length of the interval between cash collection
    public float cashCooldown = 1f;

    //links the UI text to the changing values
    public Text moneyText;
    public Text populationText;
    public Text CPMText;
    public Text PPSText;
    public Text housecostLbl;
    public Text shopcostLbl;
    public Text taverncostLbl;
    public Text armorycostLbl;
    public Text powerText;
    public Text happinessText;


    //variables that affect various effects of buildings
    public float tavernPopGrowth = 1f;
    public float houseMaxPopGrowth = 1f;
    public float shopProfitGrowth = 1f;
    public float armoryResourcesGiven = 1f;
    public float resourceCost;

    float populationmoneymod;
    public float sumupkeep;
    float inithappiness;
    public float happiness;
    public float maxhappiness;
    public float happinessmodifier;
    //current gold multiplier from shops
    public float shopProfits = 0f;
    

    //allows this object to be called elsewhere
    void Awake()
    {
        inithappiness = 50;
        maxhappiness = 100;
        happinessmodifier = 1.0f;
        happiness = inithappiness;
        if (instance == null)
        {
            return;
        }
        instance = this;
    }



    public void Update()
    {
        //countsdown the timer in real time
        cashTimer -= Time.deltaTime;

     
        //when the countdown hits 0
        if (cashTimer <= 0)
        {
            //reset the timer to the cooldown value
            cashTimer = cashCooldown;

            //---------MAIN MONEY EQUATION---------
            Money = Money + (shopProfits + populationmoneymod) * happinessmodifier - sumupkeep;
            if (happiness >= 50)
            {
                happinessmodifier = 1.0f;
            }

            if (happiness < 50)
            {
                happinessmodifier = 0.8f;
            }

            if (happiness <= 30)
            {
                happinessmodifier = 0.6f;
                PPS = -0.5f;
            }


            if (happiness >= 80)
            {
                happinessmodifier = 1.1f;
            }

            if (happiness == 100)
            {
                happinessmodifier = 1.5f;
            }

            if (happiness >= maxhappiness)
            {
                happiness = maxhappiness;
            }

            //if the population is at its max
            if (Population + PPS >= PopulationMax)
            {
                //dont allow any increase
                Population = PopulationMax;
            }
            else if (Population + PPS == 0)
            {
                Population = 0;
            }

            
            else
            {
                //increase by the current PPS 
                
                Population = Population + PPS;
                populationmoneymod = Population / 50;
            }
            Resource = Resource + RRS;
        }

        //fills the labels with the values that change
        moneyText.text = "Gold: " + System.Math.Round(Money, 0).ToString() + 'G';
        populationText.text = "Population: " + Mathf.Round(Population).ToString() + '/' + PopulationMax.ToString();
        powerText.text = "Resources: " + Mathf.Round(Resource).ToString();
        happinessText.text = "Happiness: " + Mathf.Round(happiness).ToString();
        CPMText.text = '+' + System.String.Format("{0:n}", System.Math.Round(((shopProfits + populationmoneymod*happinessmodifier - sumupkeep)), 2).ToString()) + "Gp/s";
        PPSText.text = '+' + System.Math.Round(PPS, 2).ToString() + "pp/s";

        housecostLbl.text = System.Math.Round(houseCost, 0).ToString() + 'G';
        shopcostLbl.text = System.Math.Round(shopCost, 0).ToString() + 'G';
        taverncostLbl.text = System.Math.Round(tavernCost, 0).ToString() + 'G';
        armorycostLbl.text = System.Math.Round(armoryCost, 0).ToString() + 'G';


    }
}
