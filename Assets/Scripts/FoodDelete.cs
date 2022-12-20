using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodDelete : MonoBehaviour
{
    public GameObject cell;
    public int foodEaten = 0;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected " + collision.gameObject +", "+ gameObject.tag);

        if(collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);

            Renderer rend = GetComponent<Renderer>();

            foodEaten++;

            //make the object larger
            float newScale = Mathf.Log(foodEaten, 5) + 1;
            transform.localScale = new Vector3(newScale, newScale, newScale);


            if(foodEaten > 10){
                //destroy the object and spawn 2 new ones
                Destroy(gameObject);
                
                
                GameObject cellInstance = Instantiate(cell);
                GameObject cellInstance2 = Instantiate(cell);
                cellInstance.transform.position += new Vector3(0,0,1);
                cellInstance2.transform.position += new Vector3(0,0,-1);
                
            }
        }
    }
}
