using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AddonBehavior : MonoBehaviour
{
    public float spawnTime;

    public Addon addon;

    public LayerMask addonMask;

    public float duration = 10f;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
        StartCoroutine(FOVRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime > duration)
        {
            Destroy(gameObject);
        }else{
            //set the opacity from 1 to 0.5
            float opacity = 1 - (Time.time - spawnTime) / duration;
            Color color = GetComponent<Renderer>().material.color;
            color.a = opacity;
            GetComponent<Renderer>().material.color = color;
        }
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        // Debug.Log("FieldOfViewCheck");

        Collider[] checks = Physics.OverlapSphere(transform.position, 25f, addonMask);

        addon.startingTime = Time.time;

        foreach (Collider check in checks)
        {
            if (check.gameObject.GetComponent<EntityAddon>() != null && Array.Exists(addon.tags,x => x == check.gameObject.tag))
            {
                check.gameObject.GetComponent<EntityAddon>().addon = addon;
            }
        }        
    }
}
