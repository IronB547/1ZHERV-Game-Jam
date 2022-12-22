using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddonBehavior : MonoBehaviour
{
    public float spawnTime;

    public float duration = 10f;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
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
            //change rendering mode to fade
            GetComponent<Renderer>().material.SetFloat("_Mode", 2);

            GetComponent<Renderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);

            // Debug.Log(opacity);
        }
    }
}
