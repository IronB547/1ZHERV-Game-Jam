using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCell : MonoBehaviour
{
    public AnimationCurve curve;
    public GameObject cell;
    public GameObject food;

    public GameObject bacterioPhage;

    private float petriDishY = 42f;

    Vector3 getRandomPosInPetriDish(){
        //new vector which will be centered in the petri dish
        Vector3 newPos = new Vector3(0.8f, petriDishY, -10.4f);

        //get a random angle between 0 and 360
        float angle = Random.Range(0, 360);

        //get a random radius between 0 and 24
        float radius = Random.Range(0, 24);

        //convert the angle to radians
        float angleInRadians = angle * Mathf.Deg2Rad;

        //calculate the x and z coordinates
        float x = radius * Mathf.Cos(angleInRadians);
        float z = radius * Mathf.Sin(angleInRadians);

        //set the new position
        newPos.x += x;
        newPos.z += z;

        return newPos;
    }

    Vector3 getMousePosInPetriDish(){
        
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
        RaycastHit hit;
        Vector3 newPos;

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.name == "Petri_dish"){
                newPos = hit.point;
                newPos.y = petriDishY;
                return newPos;
            }
        }

        return getRandomPosInPetriDish();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetButtonDown("Fire1") ){

            GameObject cellInstance = Instantiate(cell);

            cellInstance.transform.position = getMousePosInPetriDish();

        }else if( Input.GetButtonDown("Fire2") ){
            GameObject foodInstance = Instantiate(food);
            foodInstance.tag = "Food";

            foodInstance.transform.position = getMousePosInPetriDish();
        }else if( Input.GetButtonDown("Fire3") ){
            
            GameObject bacterioPhageInstance = Instantiate(bacterioPhage);

            bacterioPhageInstance.tag = "BacterioPhage";

            bacterioPhageInstance.transform.position = getMousePosInPetriDish();
        }
        //else if g key is pressed, spawn a new bacteriophage
        else if( Input.GetKeyDown(KeyCode.F) ){
            for(int i = 0; i < 40; i++){
                GameObject bacterioPhageInstance = Instantiate(food);
                bacterioPhageInstance.tag = "Food";
                bacterioPhageInstance.transform.position = getRandomPosInPetriDish();
            }
        }
    }
}
