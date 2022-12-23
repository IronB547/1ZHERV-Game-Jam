using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAddon : MonoBehaviour
{
    public Addon addon; 

    public float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(addon == null)
        {
            //set color to black
            // GetComponent<Renderer>().material.color = Color.black;
            // transform.GetChild(0).gameObject.SetActive(false);
            Transform childObj = transform.Find("Outline");
            if(childObj != null)
                childObj.gameObject.SetActive(false);
            return;
        }

        timeLeft = addon.duration - (Time.time - addon.startingTime);

        //check the time of the addon and remove it if it's expired
        //todo should be in a coroutine
        if (Time.time - addon.startingTime > addon.duration)
        {
            addon = null;
        }else{
            //set color to green
            // GetComponent<Renderer>().material.color = Color.green;
            Transform childObj = transform.Find("Outline");
            if(childObj != null)
                childObj.gameObject.SetActive(true);
        }
    }
}
