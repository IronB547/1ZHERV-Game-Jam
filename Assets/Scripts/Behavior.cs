using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //function to get the field of view of the renderer
    float GetFOVOfObject(Renderer renderer){
        
        //get the field of view of the renderer
        float rendererFOV = renderer.material.GetFloat("_FieldOfView");
        //return the field of view
        return rendererFOV;
    }

    //check if object is in the field of view of the renderer
    bool IsObjectInFOVOfObject(Renderer renderer, GameObject obj){
        //get the field of view of the renderer
        float rendererFOV = GetFOVOfObject(renderer);
        //get the position of the object
        Vector3 objPosition = obj.transform.position;
        //get the position of the renderer
        Vector3 rendererPosition = transform.position;
        //get the direction of the renderer
        Vector3 rendererDirection = transform.forward;
        //get the vector from the renderer to the object
        Vector3 vectorToObj = objPosition - rendererPosition;
        //get the angle between the renderer direction and the vector to the object
        float angleToObj = Vector3.Angle(rendererDirection, vectorToObj);
        //check if the angle is less than the field of view
        if( angleToObj < rendererFOV ){
            //object is in the field of view
            return true;
        }else{
            //object is not in the field of view
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //change color based on key press
        if( Input.GetKeyDown(KeyCode.R) ){
            GetComponent<Renderer>().material.color = Color.red;
        }else if( Input.GetKeyDown(KeyCode.G) ){
            GetComponent<Renderer>().material.color = Color.green;
        }else if( Input.GetKeyDown(KeyCode.B) ){
            GetComponent<Renderer>().material.color = Color.blue;
        }

        //get field of view of the renderer

        GetComponent<Renderer>().material.SetFloat("_FieldOfView", 90.0f);
    
        //compute list of all objects located in the field of view
        //get all objects with tag Cell
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        allObjects = GameObject.FindGameObjectsWithTag("Cell");
        //create a list of objects in the field of view
        List<GameObject> objectsInFOV = new List<GameObject>();
        //loop through all objects
        foreach(GameObject obj in allObjects){
            //check if object is in the field of view
            if( IsObjectInFOVOfObject(GetComponent<Renderer>(), obj) ){
                //add object to list
                objectsInFOV.Add(obj);
            }
        }

        //change color of objects in the field of view
        foreach(GameObject obj in objectsInFOV){
            obj.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
