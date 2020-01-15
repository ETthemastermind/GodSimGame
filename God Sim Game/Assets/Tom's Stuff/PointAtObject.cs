using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointAtObject : MonoBehaviour
{
    float maxDistance;
    public GameObject hand;
    public LayerMask LayerMask;
    float radius;
    bool areWePointing;
    [SerializeField]
    Collider[] listOfColliders;

    void pointAt(RaycastHit info, float _radius)
    {
        listOfColliders = Physics.OverlapSphere(info.collider.transform.position, _radius); // Create a sphere ray, and save all the object it collides with inside the list.

        foreach (Collider hits in listOfColliders) // Just go through all the objects in the list..
        {
            Debug.Log("We hit: " + hits.gameObject.name); // For now, just print the names..
        }
    }

    public void pointingGestureActivate()
    {
        areWePointing = true;
    }

    public void pointingGestureDeactivate()
    {
        areWePointing = false;
    }

    // Use this for initialization
    void Start()
    {
        maxDistance = 50.0f;
        radius = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (areWePointing == true)
        {
            Ray ray = new Ray(hand.transform.position, hand.transform.forward); // We create a ray.
            RaycastHit hit; // Variable to hold all the inforamtion about the colliders we hit with the ray cast.
            if (Physics.Raycast(ray, out hit, maxDistance, LayerMask)) // IF we hit an object with the ray we created above..
            {
                pointAt(hit, radius); // Creating a sphere around it to detect multiple objects surrounding it.    
            }
            else
            {
                Array.Clear(listOfColliders, 0, listOfColliders.Length); // Empty the list if the raycast doesn't hit anything.
            }

            Debug.DrawRay(hand.transform.position, hand.transform.forward * maxDistance, Color.red); // Draw the created ray.
        }
        
    }
    /*
    public GameObject Finger;
    public LayerMask layerMask;
    float currentHitDistance;
    float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void PointAt()
    {
        RaycastHit hit;
        if (Physics.SphereCast(Finger.transform.position, 5.5f, Finger.transform.forward, out hit, 20.0f, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currentHitDistance = hit.distance;
            Debug.Log("We hit a " + hit.collider.name);
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
    */
}
