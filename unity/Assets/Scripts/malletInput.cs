using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class malletInput : MonoBehaviour
{
    public Transform lMallet;
    public Transform rMallet;
    public float dist;
    public float distTreshhold;

    public OVRInput.Controller Rcontroller, Lcontroller;

    // Start is called before the first frame update
    void Start()
    {
        Rcontroller = (OVRInput.Controller.RTouch);
        Lcontroller = (OVRInput.Controller.LTouch);
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(lMallet.position, rMallet.position);

        if (dist <= distTreshhold)
        {
            OVRInput.SetControllerVibration(1f, 1f, Lcontroller);
            OVRInput.SetControllerVibration(1f, 1f, Rcontroller);
        }
        else
        {
            OVRInput.SetControllerVibration(0f, 0f, Lcontroller);
            OVRInput.SetControllerVibration(0f, 0f, Rcontroller);
        }
    }
}
