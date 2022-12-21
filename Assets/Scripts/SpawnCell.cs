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

            //set position of cell to mouse position
            // cellInstance.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //add tag Cell

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 newPos = hit.point;
                newPos.y = petriDishY;
                cellInstance.transform.position = newPos;
            }  

            //spawn it 1 unit in front of camera
            // cellInstance.transform.position += new Vector3(0,0,1);
            // cellInstance.AddComponent<SphereCollider>();
            //print to console
            Debug.Log("Cell Spawned");
        }else if( Input.GetButtonDown("Fire2") ){
            //create a new cell from Cell prefab
            GameObject foodInstance = Instantiate(food);

            //set position of cell to mouse position
            // foodInstance.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //add tag Cell
            foodInstance.tag = "Food";

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 newPos = hit.point;
                newPos.y = petriDishY;
                foodInstance.transform.position = newPos;
            }  

            //spawn it 1 unit in front of camera
            //print to console
            Debug.Log("Food Spawned");
        }else if( Input.GetButtonDown("Fire3") ){
            //create a new cell from Cell prefab
            GameObject bacterioPhageInstance = Instantiate(bacterioPhage);

            //set position of cell to mouse position
            // foodInstance.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //add tag Cell
            bacterioPhageInstance.tag = "BacterioPhage";

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 newPos = hit.point;
                newPos.y = petriDishY;
                bacterioPhageInstance.transform.position = newPos;
            }  

            //spawn it 1 unit in front of camera
            //print to console
            Debug.Log("BacterioPhage Spawned");
        }
    }
}
