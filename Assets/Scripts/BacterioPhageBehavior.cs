using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacterioPhageBehavior : MonoBehaviour
{

    public float lifetime = 60f;
    
    //get the time at which the object was created
    private float startTime;

    private void Start()
    {
        // playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(CheckRoutine());

        startTime = Time.time;
    }

    private IEnumerator CheckRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            lifetimeCheck();
            movementCheck();
        }
    }

    private void movementCheck(){
        //if the speed is less than 1, then move towards random direction
        if(GetComponent<Rigidbody>().velocity.magnitude < 1){
            
            float x = Random.Range(0.5f, 1);
            float z = Random.Range(0.5f, 1);

            //50% chance to go negative
            if(Random.Range(0, 2) == 0)
                x *= -1;

            if(Random.Range(0, 2) == 0)
                z *= -1;

            GetComponent<Rigidbody>().AddForce(new Vector3(x, 0, z) * 10);
        }
    }

    private void lifetimeCheck(){
        //change color based on lifetime
        float timeLeft = lifetime - (Time.time - startTime);
        float percentLeft = timeLeft / lifetime;
        float customRed = (1 - percentLeft) * 0.5f;
        //0 is the starting color, 0.5 is the end color
        GetComponent<Renderer>().material.color = new Color(1, customRed, customRed);

        if(Time.time - startTime > lifetime){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Cell")
        {
            Destroy(collision.gameObject);
            // Destroy(gameObject);
            //duplicate the object 
            GameObject cellInstance = Instantiate(gameObject);
            cellInstance.transform.position = transform.position;
        }
    }
}
