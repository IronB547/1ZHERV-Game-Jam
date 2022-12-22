using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAddonManager : MonoBehaviour
{
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

    void OnMouseDown()
    {
        if(gameObject.tag == "TealAddon")
        {
            Debug.Log(gameObject.tag);
        }

        if (gameObject.tag == "YellowAddon")
        {
            Debug.Log(gameObject.tag);
        }

        if (gameObject.tag == "GreenAddon")
        {
            Debug.Log(gameObject.tag);
        }

        if (gameObject.tag == "BlueAddon")
        {
            Debug.Log(gameObject.tag);
        }

        if (gameObject.tag == "PurpleAddon")
        {
            Debug.Log(gameObject.tag);
        }
    }
}
