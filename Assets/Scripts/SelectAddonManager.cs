using System.Collections;
using System.Collections.Generic;
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

    public GameObject Addon;

    public Addon addon;

    public Material TealAddonLiquid;
    public Material YellowAddonLiquid;
    public Material GreenAddonLiquid;
    public Material BlueAddonLiquid;
    public Material PurpleAddonLiquid;
    private float LastAddonSpawnTime = 0;

    public float AddonDuration = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
    }

    public Color hoverColor;
    public Material Hover;

    void OnMouseEnter()
    {
        hoverColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.SetColor("_Color", Hover.color);
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", hoverColor);
        
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
        // //remove any addons that are already in the petri dish
        // GameObject[] addons = GameObject.FindGameObjectsWithTag("Addon");
        // foreach (GameObject addon in addons)
        // {
        //     Destroy(addon);
        // }
    }

    void OnMouseDown()
    {
        RemoveAddons(true);

        if(gameObject.tag == "TealAddon")
        {
            Debug.Log(gameObject.tag);

            GameObject addon = SpawnAddon();

            //set the color of the addon liquid
            addon.GetComponent<Renderer>().material.color = TealAddonLiquid.color;
        }

        if (gameObject.tag == "YellowAddon")
        {
            Debug.Log(gameObject.tag);

            GameObject addon = SpawnAddon();
            //set the color of the addon liquid
            // addon.GetComponent<Renderer>().material.color = YellowAddonLiquid.color;
            addon.GetComponent<Renderer>().material.color = YellowAddonLiquid.color;
        }

        if (gameObject.tag == "GreenAddon")
        {
            Debug.Log(gameObject.tag);

            GameObject addon = SpawnAddon();
            addon.GetComponent<Renderer>().material.color = GreenAddonLiquid.color;
        }

        if (gameObject.tag == "BlueAddon")
        {
            Debug.Log(gameObject.tag);

            GameObject addon = SpawnAddon();
            addon.GetComponent<Renderer>().material.color = BlueAddonLiquid.color;
        }

        if (gameObject.tag == "PurpleAddon")
        {
            Debug.Log(gameObject.tag);

            GameObject addon = SpawnAddon();
            addon.GetComponent<Renderer>().material.color = PurpleAddonLiquid.color;
        }
    }
}
