using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceTrigger : MonoBehaviour
{
    private bool played = false, enableStoring = true;
    private float distThreshold=0.05f;
    private float objID;
    private int objNum;
    private float Ldist, Rdist;
    private GameObject rHand, lHand;
    private Vector3 myPosition;
    public OVRInput.Controller Rcontroller, Lcontroller;
    //private Text distText;
    private Color cColor, tColor;
    private Renderer myRend;
    public TimbreIDLine timbreIDLine;
    private int[] lineIndexArray;


    // Start is called before the first frame update
    void Start()
    {
        myRend = gameObject.GetComponent<Renderer>();
        cColor = myRend.material.color;
        tColor = new Color(0, 0, 1f, 1f);
        rHand = GameObject.FindGameObjectWithTag("RHAND");
        lHand = GameObject.FindGameObjectWithTag("LHAND");
        Rcontroller = (OVRInput.Controller.RTouch);
        Lcontroller = (OVRInput.Controller.LTouch);

        timbreIDLine = GameObject.FindGameObjectWithTag("LineBase").GetComponent<TimbreIDLine>();
        //distText = gameObject.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Ldist = Vector3.Distance(myPosition, lHand.transform.position);
        Rdist = Vector3.Distance(myPosition, rHand.transform.position);
        //distText.text = string.Format("L:{0}\nR:{1}", Ldist, Rdist);
        




        if (Ldist<=distThreshold || Rdist<=distThreshold)
        {
            if (!played)
            {
                this.gameObject.transform.Rotate(Vector3.up);
                //UnityPD.SendFloat(string.Format("bird_pos-{0}",objNum), objID);
                UnityPD.SendFloat("bird_pos", objID);
                myRend.material.color = tColor;
               OVRInput.SetControllerVibration(1f, 1f, Lcontroller);
               OVRInput.SetControllerVibration(1f, 1f, Rcontroller);

                if(timbreIDLine.pressedR)
                {
                    // get current length of positions array
                    int curr = timbreIDLine.storedPositions.Length;
                    int next = curr + 1;
                    // create a temporary array to copy values
                    Vector3[] tempArray = new Vector3[curr];
                    float[] tempArrayObj = new float[curr];
                    // only copy values if you have values
                    if (curr > 0)
                    {
                        // fill temp array with current values
                        for (int i = 0; i < curr; i++)
                        {
                            tempArray[i] = timbreIDLine.storedPositions[i];
                            tempArrayObj[i] = timbreIDLine.storedObjIDs[i];
                        }
                    }
                    // increment array by one
                    timbreIDLine.storedPositions = new Vector3[next];
                    timbreIDLine.storedObjIDs = new float[next];
                    if (curr > 0)
                    {
                        // copy old positions into incremented array
                        for (int i = 0; i < curr; i++)
                        {
                            timbreIDLine.storedPositions[i] = tempArray[i];
                            timbreIDLine.storedObjIDs[i] = tempArrayObj[i];
                        }
                    }
                    // add new position at last (curr) element of array
                    timbreIDLine.storedPositions[curr] = myPosition;
                    timbreIDLine.storedObjIDs[curr] = objID;
                    // increment current points
                    timbreIDLine.currPoints = next;
                    timbreIDLine.prevPoints = curr;

                }




                played = true;
            }

            //if (timbreIDLine.pressedR && timbreIDLine.cubeSelectArrayLength>0 && enableStoring)
            //{
            //    int lineID = timbreIDLine.cubeSelectArrayLength - 1;
            //    timbreIDLine.cubeSelectArray[lineID].Add(new CubeSelector(objNum, timbreIDLine.cubeSelectArrayLength));
            //    LineRenderer lr = timbreIDLine.o_Seq[lineID].GetComponent<LineRenderer>();
            //    lr.material = timbreIDLine.gM;
            //    lr.widthMultiplier = 0.02f;
            //    lr.SetPosition(lineIndexArray[lineID],myPosition);
            //    lineIndexArray[lineID]++;
            //    enableStoring = false;
            //}

            
        } else {
            played = false;
            enableStoring = true;
            myRend.material.color = cColor;
            OVRInput.SetControllerVibration(0, 0, Rcontroller);
            OVRInput.SetControllerVibration(0, 0, Lcontroller);
        }
    }

    public void SetId( float idNum, int idIdx ) {
        objID = idNum;
        objNum = idIdx;
    }

    public void UpdatePosition()
    {
        myPosition = this.gameObject.transform.position;
    }
    public Vector3 GetPosition()
    {
        return myPosition;
    }
    public void UpdateColor(Color c)
    {
        cColor = c;
    }

    public float GetID()
    {
        return objID;
    }


}
