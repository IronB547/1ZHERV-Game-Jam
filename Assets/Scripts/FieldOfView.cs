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
        Collider[] phageChecks = Physics.OverlapSphere(transform.position, radius * 0.4f, phageMask);
        if(phageChecks.Length != 0){
            Transform target = phageChecks[0].transform;
            
            //escape from the phage
            directionToTarget = (transform.position - target.position).normalized;

            GetComponent<Rigidbody>().AddForce(directionToTarget * 10);

            return;
        }

        Collider[] foodChecks = Physics.OverlapSphere(transform.position, radius, foodMask);

        if (foodChecks.Length != 0)
        {
            Transform target = foodChecks[0].transform;
            
            directionToTarget = (target.position - transform.position).normalized;

            canSeeFood = true;

            GetComponent<Rigidbody>().AddForce(directionToTarget * 10);

        }
        else if (canSeeFood)
            canSeeFood = false;
    }
}