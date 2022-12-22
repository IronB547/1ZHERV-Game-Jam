using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddonLiquid : MonoBehaviour
{

    public float radius;
    public LayerMask addonMask;

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

        Collider[] checks = Physics.OverlapSphere(transform.position, radius, addonMask);

        foreach (Collider check in checks)
        {
            if (check.gameObject.GetComponent<Addon>() != null)
            {
                check.gameObject.GetComponent<Addon>().speedMultiplier = 1.5f;
                check.gameObject.GetComponent<Addon>().replicationRateMultiplier = 1.5f;
                check.gameObject.GetComponent<Addon>().rangeMultiplier = 1.5f;
                check.gameObject.GetComponent<Addon>().startingTime = 0;
                check.gameObject.GetComponent<Addon>().duration = 10;
            }
        }        
    }
}
