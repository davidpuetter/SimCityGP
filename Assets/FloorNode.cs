using UnityEngine;
using UnityEngine.UI;

public class FloorNode : MonoBehaviour
{

    public static FloorNode instance;

    public Color hoverColor;

    public GameObject building;
    public GameObject createEffect;
    public float buildingPrice = 1f; 
    public Vector3 positionOffset;


    private Renderer rend;
    private Color startColor;

    public float blockValue = 1f;


    public float buildingSelected = 0;
    public GameObject businessToBuild;
    public GameObject houseToBuild;
    public GameObject bankToBuild;
    public GameObject powerToBuild;


    void Awake()
    {

        if (instance = null)
        {
            return;
        }
        instance = this;

        
    }

    void Start()
    {

        this.buildingPrice *= 2;


        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    void Update()
    {

    }
    void OnMouseDown()
    {

        buybuilding();
    }
    void buybuilding()
    {

        gameMoney gameManager = gameMoney.instance;

        if (gameManager.Money >= gameManager.tavernCost && building == null && gameManager.SelectedBuilding == 1 && gameManager.Resources >= gameManager.resourceCost)
        {
            rend.material.color = startColor;

            gameManager.Money -= gameManager.tavernCost;


            gameManager.Resources = gameManager.Resources - gameManager.resourceCost;

            building = (GameObject)Instantiate(businessToBuild, transform.position + positionOffset, transform.rotation);
            gameManager.PPM += gameManager.tavernPopGrowth;

            gameManager.tavernCost *= 1.4f;

        }
    
        else if (gameManager.Money >= gameManager.houseCost && building == null && gameManager.SelectedBuilding == 2 && gameManager.Resources >= gameManager.resourceCost)
            {
            rend.material.color = startColor;

            gameManager.Money -= gameManager.houseCost;

            building = (GameObject)Instantiate(houseToBuild, transform.position + positionOffset, transform.rotation);
            gameManager.PopulationMax += gameManager.houseMaxPopGrowth;



            gameManager.houseCost *= 1.4f;


            gameManager.Resources = gameManager.Resources - gameManager.resourceCost;





            GameObject effectIns = (GameObject)Instantiate(createEffect, transform.position + positionOffset, transform.rotation);



        }
        else if (gameManager.Money >= gameManager.tavernCost && building == null && gameManager.SelectedBuilding == 3 && gameManager.Resources >= gameManager.resourceCost)
        {
            rend.material.color = startColor;

            gameManager.Money -= gameManager.tavernCost;

            building = (GameObject)Instantiate(bankToBuild, transform.position + positionOffset, transform.rotation);
           
            gameManager.shopCost *= 1.4f;

            gameManager.shopProfits = gameManager.shopProfits + gameManager.shopProfitGrowth;

            gameManager.Resources = gameManager.Resources - gameManager.resourceCost;



            GameObject effectIns = (GameObject)Instantiate(createEffect, transform.position + positionOffset, transform.rotation);



        }
        else if (gameManager.Money >= gameManager.armoryCost && building == null && gameManager.SelectedBuilding == 4 && gameManager.Resources >= gameManager.resourceCost)
        {
            rend.material.color = startColor;

            gameManager.Money -= gameManager.armoryCost;

            building = (GameObject)Instantiate(powerToBuild, transform.position + positionOffset, Quaternion.Euler(0, 90, 0));


            gameManager.Resources = gameManager.Resources + gameManager.armoryResourcesGiven;

            gameManager.armoryCost *= 1.5f;




            GameObject effectIns = (GameObject)Instantiate(createEffect, transform.position + positionOffset, transform.rotation);



        }
    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
