using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollider : MonoBehaviour
{

//    private float distThreshold=0.5f;
    private float objID;
    private int objNum;
    private bool enter = true, stay = true, exit = true;
 //   private OVRInput.Controller Rcontroller;
 //   private OVRInput.Controller Lcontroller;
    private Vector3 myPosition;

    // Start is called before the first frame update
    void Start()
    {
//        Rcontroller = (OVRInput.Controller.RTouch);
//        Lcontroller = (OVRInput.Controller.LTouch);
    }

    // Update is called once per frame
    void Update()
    { 
        


//        if (distThreshold > Vector3.Distance(myPosition, OVRInput.GetLocalControllerPosition(Rcontroller)))
//        {
//            //UnityPD.SendFloat(string.Format("bird_pos-{0}",objNum), objID);
//            UnityPD.SendFloat("bird_pos", objID);
//            OVRInput.SetControllerVibration(0.01f, 0.8f, Rcontroller);
//        } else
//        {
//            OVRInput.SetControllerVibration(0, 0, Rcontroller);
//        }
//
//
//        if (distThreshold > Vector3.Distance(myPosition, OVRInput.GetLocalControllerPosition(Lcontroller)))
//        {
//            //UnityPD.SendFloat(string.Format("bird_pos-{0}",objNum), objID);
//            
//            
//        } else
//        {
//            OVRInput.SetControllerVibration(0, 0, Lcontroller);
//        }


    }

    public void SetId( float idNum, int idIdx ) {
        objID = idNum;
        objNum = idIdx;
    }
    public void UpdatePosition()
    {
        myPosition = this.gameObject.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            UnityPD.SendFloat("bird_pos", objID);
            //OVRInput.SetControllerVibration(0, 0, Lcontroller);
            Debug.Log("Collided");
        }
    }

    // stayCount allows the OnTriggerStay to be displayed less often
    // than it actually occurs.
//    private float stayCount = 0.0f;
//    private void OnTriggerStay(Collider other)
//    {
//        if (stay)
//        {
//            if (stayCount > 0.25f)
//            {
//                Debug.Log("staying");
//                stayCount = stayCount - 0.25f;
//            }
//            else
//            {
//                stayCount = stayCount + Time.deltaTime;
//            }
//        }
//    }
//
//    private void OnTriggerExit(Collider other)
//    {
//        if (exit)
//        {
//            Debug.Log("exit");
//        }
//    }


}
