using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureCameraController : MonoBehaviour
{
    public GameObject Camera;
    public GameObject HandControl;
    public bool handIsClosed;
    public float handRotationValueZ;

    public void CameraModeGesturesActivate()
    {
        if (ModeSwitch.CameraModeActive == true)
        {
            handIsClosed = true;
            //Camera.transform.position = HandControl.transform.position;
            //Debug.Log("We are in camera mode");
        }
    }

    public void CameraModeGesturesDeactivate()
    {
        if (ModeSwitch.CameraModeActive == true)
        {
            handIsClosed = false;
            //Camera.transform.position = HandControl.transform.position;
            //Debug.Log("We are in camera mode");
        }
    }

    // Update is called once per frame
    void Update()
    {
        handRotationValueZ = HandControl.transform.rotation.z;
        Debug.Log(handRotationValueZ);
        if (ModeSwitch.CameraModeActive == true & handIsClosed == true & handRotationValueZ > 0.4f & handRotationValueZ < 0.7f)
        {
            Camera.transform.Rotate(Vector3.down, 30.0f * Time.deltaTime);
            //Camera.transform.Rotate(00.0f, 0.0f, 0.5f, Space.Self);
            //Camera.transform.rotation.z += 0.1f;
        }

        else if (ModeSwitch.CameraModeActive == true & handIsClosed == true & handRotationValueZ < 0.15f & handRotationValueZ > -0.55f)
        {
            Camera.transform.Rotate(Vector3.up, 30.0f * Time.deltaTime);
            //Camera.transform.Rotate(00.0f, 0.0f, 0.5f, Space.Self);
            //Camera.transform.rotation.z += 0.1f;
        }
        //Camera.transform.position = HandControl.transform.position;
        //Camera.transform.rotation = HandControl.transform.rotation;
        //Debug.Log("We are in camera mode");
        //if (ModeSwitch.CameraModeActive == true)
        //{
        //Camera.transform.parent = HandControl.transform;
        //    Debug.Log("We are in camera mode");
        //}
    }
}
