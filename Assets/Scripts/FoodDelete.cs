using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodDelete : MonoBehaviour
{
    public GameObject cell;
    public int foodEaten = 0;

    Vector3 getNewScale(){
        return getNewScale(foodEaten);
    }

    Vector3 getNewScale(int foodEaten){
        float newScale = Mathf.Log(foodEaten, 5) + 1;
        return new Vector3(newScale, newScale, newScale);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected " + collision.gameObject +", "+ gameObject.tag);

        if(collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);

            Renderer rend = GetComponent<Renderer>();

            foodEaten++;

            //make the object larger
            transform.localScale = getNewScale();

            //set the mass
            GetComponent<Rigidbody>().mass = foodEaten;


            if(foodEaten > 10){
                //destroy the object and spawn 2 new ones which are smaller
                Destroy(gameObject);

                foodEaten = 0;

                Vector3 initialScale = getNewScale(1);

                GameObject cellInstance = Instantiate(cell);
                cellInstance.transform.position = transform.position;
                cellInstance.transform.localScale = initialScale;
                cellInstance.GetComponent<FieldOfView>().enabled = true;

                GameObject cellInstance2 = Instantiate(cell);
                cellInstance2.transform.position = transform.position;
                cellInstance2.transform.localScale = initialScale;
                cellInstance2.GetComponent<FieldOfView>().enabled = true;
            }
        }
    }
}
