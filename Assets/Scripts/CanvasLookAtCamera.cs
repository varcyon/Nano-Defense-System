using UnityEngine;
using System.Collections;
using Cinemachine;
 
public class CanvasLookAtCamera : MonoBehaviour
{
    public CinemachineFreeLook m_Camera;
 
    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
