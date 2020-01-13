using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureDetectionScript : MonoBehaviour
{
    public void OnGestureActivate()
    {
        Debug.Log("HandClosed");
    }

    public void OnGestureDeactivate()
    {
        Debug.Log("HandOpen");
    }
}
