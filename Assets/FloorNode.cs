using UnityEngine;
using UnityEngine.UI;

public class FloorNode : MonoBehaviour
{

    public static FloorNode instance;

    //colour of floor when hovered over
    public Color hoverColor;

    //building to be placed on top of it (should be set as null initially)
    public GameObject building;

    //the effect spawned when a building is built
    public GameObject createEffect;

    //vector to align the building to the spawning node 
    public Vector3 positionOffset;

    //stored object renderer for easy reference
    private Renderer rend;

    //start colour of the node
    private Color startColor;

    //stores what building is selected to build, 0 = nothing
    public float buildingSelected = 0;

    //assign the buildings to the floor nodes so it knows what to build. 
    //This script is also in the buildings themselves to allow the stacking
    public GameObject tavernToBuild;
    public GameObject houseToBuild;
    public GameObject shopToBuild;
    public GameObject armoryToBuild;

    // GOs to hold master script
    public GameObject master;
    private gameMoney gameManager;



    //when possible to run from start
    void Awake()
    {
        //allow the object to be referenced with instance
        if (instance = null)
        {
            return;
        }
        instance = this;
        
    }

    void Start()
    {

        //set the object renderer to allow for material changes
        rend = GetComponent<Renderer>();

        //set the start colour as... the start colour
        startColor = rend.material.color;

        gameManager = master.GetComponent<gameMoney>();
    }
    void OnMouseDown()
    {
        //when clicked, build selected building
        buybuilding();
    }

    //function for costs and spawning
    void buybuilding()
    {

        //gameMoney gameManager = gameMoney.instance;
        //if building can be afforded,      If there isnt a building there already,        If selected building = 1(tavern),            Can afford the resource cost
        if (gameManager.Money >= gameManager.tavernCost && building == null && gameManager.SelectedBuilding == 1 && gameManager.Resources >= gameManager.resourceCost)
        {
            //deselect the floor node (avoids a colour bug)
            rend.material.color = startColor;

            //remove the cost from the money var
            gameManager.Money -= gameManager.tavernCost;

            //remove the resource cost from resources
            gameManager.Resources = gameManager.Resources - gameManager.resourceCost;

            //building is assigned to a building which instantiate spawns with the variables and offset position
            building = (GameObject)Instantiate(tavernToBuild, transform.position + positionOffset, tavernToBuild.transform.rotation);//, transform.rotation);
            GameObject effectIns = (GameObject)Instantiate(createEffect, transform.position + positionOffset, transform.rotation);

            //taverns individual effect/purpose on the game
            //increases the population growth by attracting people to the town
            gameManager.PPS += gameManager.tavernPopGrowth;

            //increases the cost of the building after one is built
            gameManager.tavernCost *= 1.4f;

        }

        //if building can be afforded,      If there isnt a building there already,        If selected building = 2(house),            Can afford the resource cost
        else if (gameManager.Money >= gameManager.houseCost && building == null && gameManager.SelectedBuilding == 2 && gameManager.Resources >= gameManager.resourceCost)
            {
            rend.material.color = startColor;

            gameManager.Money -= gameManager.houseCost;

            building = (GameObject)Instantiate(houseToBuild, transform.position + positionOffset, houseToBuild.transform.rotation);
            GameObject effectIns = (GameObject)Instantiate(createEffect, transform.position + positionOffset, transform.rotation);

            //houses individual effect/purpose on the game
            //increases the max amount of people the town can hold
            gameManager.PopulationMax += gameManager.houseMaxPopGrowth;

            gameManager.houseCost *= 1.4f;
            gameManager.Resources = gameManager.Resources - gameManager.resourceCost;

        }

        //if building can be afforded,      If there isnt a building there already,        If selected building = 3(shop),            Can afford the resource cost
        else if (gameManager.Money >= gameManager.shopCost && building == null && gameManager.SelectedBuilding == 3 && gameManager.Resources >= gameManager.resourceCost)
        {
            rend.material.color = startColor;

            gameManager.Money -= gameManager.shopCost;

            building = (GameObject)Instantiate(shopToBuild, transform.position + positionOffset, shopToBuild.transform.rotation);
           
            

            gameManager.Resources = gameManager.Resources - gameManager.resourceCost;



            GameObject effectIns = (GameObject)Instantiate(createEffect, transform.position + positionOffset, transform.rotation);

            //tavern individual effect/purpose on the game
            //CPS = "CPS + (~shopProfits~ * Population)"
            gameManager.shopProfits = gameManager.shopProfits + gameManager.shopProfitGrowth;

            gameManager.shopCost *= 1.4f;


        }


        //if building can be afforded,      If there isnt a building there already,        If selected building = 4(armory),            Can afford the resource cost (should be 0 so game is never impossible)
        else if (gameManager.Money >= gameManager.armoryCost && building == null && gameManager.SelectedBuilding == 4 && gameManager.Resources >= gameManager.resourceCost)
        {
            rend.material.color = startColor;

            gameManager.Money -= gameManager.armoryCost;

            building = (GameObject)Instantiate(armoryToBuild, transform.position + positionOffset, armoryToBuild.transform.rotation);// Quaternion.Euler(0, 90, 0));

            GameObject effectIns = (GameObject)Instantiate(createEffect, transform.position + positionOffset, transform.rotation);

            //armorys individual effect/purpose on the game
            //increases the energy resource by x amount.
            gameManager.Resources = gameManager.Resources + gameManager.armoryResourcesGiven;

            gameManager.armoryCost *= 1.4f;




        }
    }
    void OnMouseEnter()
    {
        //change colour on mouse hover to set colour
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        //reset colour when mouse leaves
        rend.material.color = startColor;
    }

}
