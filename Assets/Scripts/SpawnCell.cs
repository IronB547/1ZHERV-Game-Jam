using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCell : MonoBehaviour
{
    public AnimationCurve curve;
    public GameObject cell;
    public GameObject food;

    public GameObject bacterioPhage;

    public GameObject UI;

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

    Vector3? getMousePosInPetriDish(){
        
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

        return null;
    }

    public void spawnCellRandomly(){

        int cellAmount = int.Parse(UI.GetComponent<UIManager>().CellNumber.text);
        
        for (int i = 0; i < cellAmount; i++)
        {
            GameObject cellInstance = Instantiate(cell);
            cellInstance.tag = "Cell";
            cellInstance.transform.position = getRandomPosInPetriDish();
        }
    }

    public void spawnFoodRandomly(){

        int foodAmount = int.Parse(UI.GetComponent<UIManager>().FoodNumber.text);
        
        for (int i = 0; i < foodAmount; i++)
        {
            GameObject foodInstance = Instantiate(food);
            foodInstance.tag = "Food";
            foodInstance.transform.position = getRandomPosInPetriDish();
        }
    }

    public void spawnPhageRandomly(){

        int phageAmount = int.Parse(UI.GetComponent<UIManager>().PhageNumber.text);
        
        for (int i = 0; i < phageAmount; i++)
        {
            GameObject phageInstance = Instantiate(bacterioPhage);
            phageInstance.tag = "BacterioPhage";
            phageInstance.transform.position = getRandomPosInPetriDish();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetButtonDown("Fire1") ){
            Vector3? initialPos = getMousePosInPetriDish();
            if(initialPos == null)
                return;

            GameObject cellInstance = Instantiate(cell);

            cellInstance.transform.position = (Vector3) initialPos;

        }else if( Input.GetButtonDown("Fire2") ){
            Vector3? initialPos = getMousePosInPetriDish();
            if(initialPos == null)
                return;

            GameObject foodInstance = Instantiate(food);
            foodInstance.tag = "Food";

            foodInstance.transform.position = (Vector3) initialPos;
        }else if( Input.GetButtonDown("Fire3") ){
            Vector3? initialPos = getMousePosInPetriDish();
            if(initialPos == null)
                return;
            
            GameObject bacterioPhageInstance = Instantiate(bacterioPhage);

            bacterioPhageInstance.tag = "BacterioPhage";

            bacterioPhageInstance.transform.position = (Vector3) initialPos;
        }
        else if( Input.GetKeyDown(KeyCode.C) ){
            spawnCellRandomly();
        }
        else if( Input.GetKeyDown(KeyCode.F) ){
            spawnFoodRandomly();
        }
        else if( Input.GetKeyDown(KeyCode.P) ){
            spawnPhageRandomly();
        }
    }
}
