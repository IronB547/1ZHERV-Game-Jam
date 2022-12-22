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

    public LayerMask spawnAreaMask;

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

    Vector3 getInitialVelocity(){
            //initial speed
            float speed = 0.1f;

            //initial direction
            Vector3 direction = new Vector3(0, 0, 0);

            //get a random angle between 0 and 360
            float angle = Random.Range(0, 360);

            //convert the angle to radians
            float angleInRadians = angle * Mathf.Deg2Rad;

            //calculate the x and z coordinates
            float x = speed * Mathf.Cos(angleInRadians);
            float z = speed * Mathf.Sin(angleInRadians);

            //set the new position
            direction.x += x;
            direction.z += z;

            return direction;
    }

    Vector3? getMousePosInPetriDish(){
        
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
        RaycastHit hit;
        Vector3 newPos;

        //perform the raycast with the spawnAreaMask
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, spawnAreaMask))
        {
            if(hit.collider.name == "Petri_dish" || hit.collider.name == "Addon"){
                newPos = hit.point;
                newPos.y = petriDishY;
                return newPos;
            }
        }

        return null;
    }

    void spawnCell(Vector3 initialPos){
        GameObject cellInstance = Instantiate(cell);
        cellInstance.transform.position = initialPos;
        cellInstance.GetComponent<Rigidbody>().velocity = getInitialVelocity();
    }

    void spawnFood(Vector3 initialPos){
        GameObject foodInstance = Instantiate(food);
        foodInstance.tag = "Food";
        foodInstance.transform.position = initialPos;
    }

    void spawnPhage(Vector3 initialPos){
        GameObject bacterioPhageInstance = Instantiate(bacterioPhage);
        bacterioPhageInstance.transform.position = initialPos;
        bacterioPhageInstance.GetComponent<Rigidbody>().velocity = getInitialVelocity();
        bacterioPhageInstance.tag = "BacterioPhage";
    }

    public void spawnCellRandomly(){

        int cellAmount = int.Parse(UI.GetComponent<UIManager>().CellNumber.text);
        
        for (int i = 0; i < cellAmount; i++)
        {
            spawnCell(getRandomPosInPetriDish());
        }
    }

    public void spawnFoodRandomly(){

        int foodAmount = int.Parse(UI.GetComponent<UIManager>().FoodNumber.text);
        
        for (int i = 0; i < foodAmount; i++)
        {
            spawnFood(getRandomPosInPetriDish());
        }
    }

    public void spawnPhageRandomly(){

        int phageAmount = int.Parse(UI.GetComponent<UIManager>().PhageNumber.text);
        
        for (int i = 0; i < phageAmount; i++)
        {
            spawnPhage(getRandomPosInPetriDish());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetButtonDown("Fire1") ){
            Vector3? initialPos = getMousePosInPetriDish();
            if(initialPos == null)
                return;

            spawnCell((Vector3) initialPos);
        }else if( Input.GetButtonDown("Fire2") ){
            Vector3? initialPos = getMousePosInPetriDish();
            if(initialPos == null)
                return;

            spawnFood((Vector3) initialPos);
        }else if( Input.GetButtonDown("Fire3") ){
            Vector3? initialPos = getMousePosInPetriDish();
            if(initialPos == null)
                return;
            
            spawnPhage((Vector3) initialPos);
        }
        else if( Input.GetKeyDown(KeyCode.C) ){
            spawnCellRandomly();
        }
        else if( Input.GetKeyDown(KeyCode.F) ){
            spawnFoodRandomly();
        }
        else if( Input.GetKeyDown(KeyCode.X) ){
            spawnPhageRandomly();
        }
    }
}
