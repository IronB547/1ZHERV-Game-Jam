using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

/**
    Teal addon: 2x visibility range for cells
    Yellow addon: 2x speed for cells
    Green addon: 2x speed for phages
    Blue addon: faster cell reproduction
    Purple addon: 2x speed for everything
**/

public class SelectAddonManager : MonoBehaviour
{
    public GameObject PurpleAddonDescritpion;
    public GameObject BlueAddonDescritpion;
    public GameObject GreenAddonDescritpion;
    public GameObject YellowAddonDescritpion;
    public GameObject TealAddonDescritpion;

    public GameObject AddonTimer;
    public TextMeshProUGUI AddonColorText;
    public TextMeshProUGUI AddonTimeLeft;
    private static bool startTimer;
    private static float totalTime = 20.0f;
    private static float elapsedTime;

    public GameObject Addon;

    public Addon addon;

    public Material TealAddonLiquid;
    public Material YellowAddonLiquid;
    public Material GreenAddonLiquid;
    public Material BlueAddonLiquid;
    public Material PurpleAddonLiquid;
    private float LastAddonSpawnTime = 0;

    private Vector3 displayPos;

    public float AddonDuration = 10f;

    // Start is called before the first frame update
    void Start()
    {
     PurpleAddonDescritpion.SetActive(false);
     BlueAddonDescritpion.SetActive(false);
     GreenAddonDescritpion.SetActive(false);
     YellowAddonDescritpion.SetActive(false);
     TealAddonDescritpion.SetActive(false);

     AddonTimer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }

        if (startTimer)
        {
            elapsedTime += Time.deltaTime/5;
            AddonTimeLeft.text = (totalTime - (int)elapsedTime).ToString();

            if (elapsedTime >= totalTime)
            {
                elapsedTime = 0.0f;
                AddonTimer.SetActive(false);
                startTimer = false;
            }
        }

    }

    private Color hoverColor;
    public Material Hover;

    void OnMouseEnter()
    {
        hoverColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.SetColor("_Color", Hover.color);

        displayPos = Input.mousePosition;
        if (gameObject.tag == "PurpleAddon")
        {
            displayPos.x += 120;
            displayPos.y += 20;
            PurpleAddonDescritpion.SetActive(true);
            PurpleAddonDescritpion.transform.position = displayPos;
            
        }

        if (gameObject.tag == "BlueAddon")
        {
            displayPos.x += 125;
            displayPos.y += 20;
            BlueAddonDescritpion.SetActive(true);
            BlueAddonDescritpion.transform.position = displayPos;
        }

        if (gameObject.tag == "GreenAddon")
        {
            displayPos.x += 120;
            displayPos.y += 20;
            GreenAddonDescritpion.SetActive(true);
            GreenAddonDescritpion.transform.position = displayPos;
        }

        if (gameObject.tag == "YellowAddon")
        {
            displayPos.x += 120;
            displayPos.y += 20;
            YellowAddonDescritpion.SetActive(true);
            YellowAddonDescritpion.transform.position = displayPos;
        }

        if (gameObject.tag == "TealAddon")
        {
            displayPos.x += 125;
            displayPos.y += 20;
            TealAddonDescritpion.SetActive(true);
            TealAddonDescritpion.transform.position = displayPos;
        }

    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", hoverColor);

        if (gameObject.tag == "PurpleAddon")
        {
            PurpleAddonDescritpion.SetActive(false);
        }

        if (gameObject.tag == "BlueAddon")
        {
            BlueAddonDescritpion.SetActive(false);
        }

        if (gameObject.tag == "GreenAddon")
        {
            GreenAddonDescritpion.SetActive(false);
        }

        if (gameObject.tag == "YellowAddon")
        {
            YellowAddonDescritpion.SetActive(false);
        }

        if (gameObject.tag == "TealAddon")
        {
            TealAddonDescritpion.SetActive(false);
        }
    }

    GameObject SpawnAddon()
    {
        Vector3 petriDishPosition = GameObject.Find("Petri_dish").transform.position;
        petriDishPosition.y = 40.5f;
        GameObject addon = Instantiate(Addon, petriDishPosition, Quaternion.identity);
        addon.name = "Addon";
        addon.tag = "Addon";

        LastAddonSpawnTime = Time.time;
        Invoke("RemoveAddons", AddonDuration);
        return addon;
    }

    void RemoveAddons(bool force = false){
        //check if the addons have been in the petri dish for the duration
        if ((Time.time - LastAddonSpawnTime > AddonDuration) || force )
        {
            //remove any addons that are already in the petri dish
            GameObject[] addons = GameObject.FindGameObjectsWithTag("Addon");
            foreach (GameObject addon in addons)
            {
                Destroy(addon);
            }
        }
    }

    void OnMouseDown()
    {
        RemoveAddons(true);
        elapsedTime = 0.0f;

        if (gameObject.tag == "TealAddon")
        {
            AddonTimer.SetActive(true);
            AddonColorText.text = "Teal";
            startTimer = true;

            GameObject addon = SpawnAddon();

            //set the color of the addon liquid
            addon.GetComponent<Renderer>().material.color = TealAddonLiquid.color;
            addon.GetComponent<AddonBehavior>().addon = new TealAddon();
        }

        if (gameObject.tag == "YellowAddon")
        {
            AddonTimer.SetActive(true);
            AddonColorText.text = "Yellow";
            startTimer = true;

            GameObject addon = SpawnAddon();
            //set the color of the addon liquid
            // addon.GetComponent<Renderer>().material.color = YellowAddonLiquid.color;
            addon.GetComponent<Renderer>().material.color = YellowAddonLiquid.color;
            addon.GetComponent<AddonBehavior>().addon = new YellowAddon();
        }

        if (gameObject.tag == "GreenAddon")
        {
            AddonTimer.SetActive(true);
            AddonColorText.text = "Green";
            startTimer = true;

            GameObject addon = SpawnAddon();
            addon.GetComponent<Renderer>().material.color = GreenAddonLiquid.color;
            addon.GetComponent<AddonBehavior>().addon = new GreenAddon();
        }

        if (gameObject.tag == "BlueAddon")
        {
            AddonTimer.SetActive(true);
            AddonColorText.text = "Blue";
            startTimer = true;

            GameObject addon = SpawnAddon();
            addon.GetComponent<Renderer>().material.color = BlueAddonLiquid.color;
            addon.GetComponent<AddonBehavior>().addon = new BlueAddon();
        }

        if (gameObject.tag == "PurpleAddon")
        {
            AddonTimer.SetActive(true);
            AddonColorText.text = "Purple";
            startTimer = true;

            GameObject addon = SpawnAddon();
            addon.GetComponent<Renderer>().material.color = PurpleAddonLiquid.color;
            addon.GetComponent<AddonBehavior>().addon = new PurpleAddon();
        }
    }
}
