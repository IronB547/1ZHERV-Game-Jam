using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodConsume : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Collision Detected", collision.gameObject.tag, collision.tag);

        if(collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
        }
    }
}
