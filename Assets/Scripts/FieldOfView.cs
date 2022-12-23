using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask foodMask;
    public LayerMask phageMask;

    public LayerMask obstructionMask;

    public bool canSeeFood;

    public Vector3 directionToTarget;

    private float getRadius(){
        //get the multiplier
        if(GetComponent<EntityAddon>().addon == null)
            return radius;

        float multiplier = GetComponent<EntityAddon>().addon.rangeMultiplier;
        // Debug.Log("Radius multiplier: " + multiplier);
        return radius * multiplier;
    }

    private float getSpeedMultiplier(){
        //get the multiplier
        if(GetComponent<EntityAddon>().addon == null)
            return 1.0f;

        float multiplier = GetComponent<EntityAddon>().addon.speedMultiplier;
        return multiplier;
    } 

    private void Start()
    {
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] phageChecks = Physics.OverlapSphere(transform.position, getRadius() * 0.4f, phageMask);
        if(phageChecks.Length != 0){
            Transform target = phageChecks[0].transform;
            
            //escape from the phage
            directionToTarget = (transform.position - target.position).normalized;

            GetComponent<Rigidbody>().AddForce(directionToTarget * 10 * getSpeedMultiplier());

            return;
        }

        Collider[] foodChecks = Physics.OverlapSphere(transform.position, getRadius(), foodMask);

        if (foodChecks.Length != 0)
        {
            Transform target = foodChecks[0].transform;
            
            directionToTarget = (target.position - transform.position).normalized;

            canSeeFood = true;

            GetComponent<Rigidbody>().AddForce(directionToTarget * 10 * getSpeedMultiplier());

        }
        else if (canSeeFood)
            canSeeFood = false;
    }
}