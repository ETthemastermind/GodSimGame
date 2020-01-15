using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureCameraController : MonoBehaviour
{
    public GameObject Camera;
    public GameObject HandControl;
    public GameObject HandControlPan;
    public GameObject LeapHands;
    public bool handIsClosed;
    public bool handIsClosedPan;
    float handRotationValueZ;
    float handRotationValueX;
    public Vector3 handsOffset;
    public Vector3 handStartPos;
    public Vector3 handCurrentPos;

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

    /*public void CameraModePanActivate()
    {
        if (ModeSwitch.CameraModeActive == true)
        {
            handIsClosed = true;
            handStartPos = HandControlPan.transform.position;
            //Camera.transform.position = HandControl.transform.position;
            //Debug.Log("We are in camera mode");
        }
    }

    public void CameraModePanDeactivate()
    {
        if (ModeSwitch.CameraModeActive == true)
        {
            handIsClosed = false;
            //Camera.transform.position = HandControl.transform.position;
            //Debug.Log("We are in camera mode");
        }
    }*/

    void Awake()
    {
        //handsOffset = (newVector3(-0.35f, -0.3f, 0.45f));
        LeapHands.transform.position = Camera.transform.position + handsOffset;
    }

    // Update is called once per frame
    void Update()
    {
        handRotationValueZ = HandControl.transform.rotation.z;
        //Debug.Log(handRotationValueZ);
        if (ModeSwitch.CameraModeActive == true & handIsClosed == true & handRotationValueZ > 0.4f & handRotationValueZ < 0.7f)
        {
            Camera.transform.Rotate(Vector3.down, 30.0f * Time.deltaTime);
            //Camera.transform.Rotate(00.0f, 0.0f, 0.5f, Space.Self);
            //Camera.transform.rotation.z += 0.1f;
        }

        else if (ModeSwitch.CameraModeActive == true & handIsClosed == true & handRotationValueZ < 0.1f & handRotationValueZ > -0.55f)
        {
            Camera.transform.Rotate(Vector3.up, 30.0f * Time.deltaTime);
            //Camera.transform.Rotate(00.0f, 0.0f, 0.5f, Space.Self);
            //Camera.transform.rotation.z += 0.1f;
        }


        handRotationValueX = HandControl.transform.rotation.x;
        //Debug.Log(handRotationValueX);
        if (ModeSwitch.CameraModeActive == true & handIsClosed == true & handRotationValueX > 0.52f & handRotationValueX < 0.8f)
        {
            Camera.transform.Rotate(Vector3.right, 30.0f * Time.deltaTime);
            //Camera.transform.Rotate(00.0f, 0.0f, 0.5f, Space.Self);
            //Camera.transform.rotation.z += 0.1f;
        }

        else if (ModeSwitch.CameraModeActive == true & handIsClosed == true & handRotationValueX < 0.2f & handRotationValueX > -0.5f)
        {
            Camera.transform.Rotate(Vector3.left, 30.0f * Time.deltaTime);
            //Camera.transform.Rotate(00.0f, 0.0f, 0.5f, Space.Self);
            //Camera.transform.rotation.z += 0.1f;
        }

        LeapHands.transform.position = Vector3.MoveTowards(LeapHands.transform.position, Camera.transform.position + handsOffset, Time.deltaTime * 3.0f);

        /*if (ModeSwitch.CameraModeActive == true & handIsClosedPan == true)
        {
            handCurrentPos = HandControlPan.transform.position;
            if (handStartPos < handCurrentPos)
            {
                Camera.transform.forward;
            }
        }*/

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
