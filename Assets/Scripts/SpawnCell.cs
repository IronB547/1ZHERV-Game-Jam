using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnCell : MonoBehaviour
{
    public GameObject cell;
    public GameObject food;

    public GameObject bacterioPhage;

    private float petriDishY = 42f;

    // Update is called once per frame
    void Update()
    {
        if( Input.GetButtonDown("Fire1") ){

            //create a new cell from Cell prefab
            GameObject cellInstance = Instantiate(cell);

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 newPos = hit.point;
                newPos.y = petriDishY;
                cellInstance.transform.position = newPos;
            }  

        }else if( Input.GetButtonDown("Fire2") ){
            //create a new food from Food prefab
            GameObject foodInstance = Instantiate(food);


            //add tag Food
            foodInstance.tag = "Food";

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 newPos = hit.point;
                newPos.y = petriDishY;
                foodInstance.transform.position = newPos;
            }  
            Debug.Log("Food Spawned");
        }else if( Input.GetButtonDown("Fire3") ){
            //create a new phage from prefab
            GameObject bacterioPhageInstance = Instantiate(bacterioPhage);

            //add tag BacterioPhage
            bacterioPhageInstance.tag = "BacterioPhage";

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 newPos = hit.point;
                newPos.y = petriDishY;
                bacterioPhageInstance.transform.position = newPos;
            }  
        }
    }
}
