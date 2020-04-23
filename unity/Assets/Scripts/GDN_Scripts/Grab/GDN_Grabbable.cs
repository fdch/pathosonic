using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;


public class GDN_Grabbable : MonoBehaviour {

    [SerializeField] private Reticle Reticle;

    private float distance = 1;                 // distance of object from camera when grabbed
    private float speed = 5;                    // translation speed when object is put downed

    private Vector3 startPos;
    private Quaternion startRot;

    private bool IsHeld;



    // Use this for initialization
    void Start()
    {
        IsHeld = false;
        startPos = this.gameObject.transform.position;
        startRot = this.gameObject.transform.rotation;


    }

    private void Update()
    {
        ResetPos();
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        if (IsHeld == true)
        {
            Ray holdPoint = new Ray(Reticle.transform.position, Reticle.transform.forward);
            transform.position = holdPoint.GetPoint(distance);
            transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);

        }

    }


    public void PickUp()
    {
        IsHeld = true;
    }


    public void PutDown()
    {
        IsHeld = false;
        ResetPos();
    }

    public void ResetPos()
    {
        if (IsHeld == false)

        {
            transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * speed);
            transform.rotation = startRot;
        }
    }
}
