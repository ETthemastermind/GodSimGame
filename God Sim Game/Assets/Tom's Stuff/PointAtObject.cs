using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtObject : MonoBehaviour
{
    public GameObject Finger;
    public LayerMask layerMask;
    float currentHitDistance;
    float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        RaycastHit hit;
        if (Physics.SphereCast(Finger.transform.position, 3.0f, Finger.transform.forward, out hit, 10.0f, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currentHitDistance = hit.distance;
            //Debug.Log("We hit a " + hit.collider.name);
        }
        else
        {
            currentHitDistance = 30.0f;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(Finger.transform.position, Finger.transform.position + Finger.transform.forward * currentHitDistance);
        Gizmos.DrawWireSphere(Finger.transform.position + Finger.transform.forward * currentHitDistance, 2.5f);
    }
}
