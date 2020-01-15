using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithVillagers : MonoBehaviour
{
    public GameObject LeapHands;
    public GameObject Villager;
    bool areWePinching;
    float distanceFromVillager;
    float requiredDistance;

    void Start()
    {
        requiredDistance = Vector3.Distance(LeapHands.transform.position, Villager.transform.position);
    }

    void OnPickUpGestureActivate()
    {
        areWePinching = true;
    }

    void OnPickUpGestureDeactivate()
    {
        areWePinching = false;
    }

    void Update()
    {
        Debug.Log(requiredDistance);
        //if(areWePinching == true & )
    }
}
