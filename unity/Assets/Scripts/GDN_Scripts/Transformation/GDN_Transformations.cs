using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDN_Transformations : MonoBehaviour {

    private float speed = 3f;                       //Speed of moving object

    private Vector3 currPosition;                   //Use Vector3 to get current position of gameobject
    private Vector3 newPosition;                    //Use Vector3 to set new position
    private Vector3 controllerPos;


    private void Start()
    {
        currPosition = this.gameObject.transform.position;
        newPosition = new Vector3(0f, 2f, -5f);
    }

    public void Rotating()
    {
        this.gameObject.transform.Rotate(1f, 1f, 1f);
    }


    public void Scale()
    {
        this.gameObject.transform.localScale += new Vector3(0.5F, 0.5f, 0.5f);
    }


    public void Translate()
    {
        //Alternate gameobject between two points. Time.time is the total time in seconds since the game started
        this.gameObject.transform.position = Vector3.Lerp(currPosition, newPosition, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }

    public void TranslateForward()
    {
        //Vector3 can be .forward .back .left, .right .up . down / Time.deltaTime is the the time between the current and previous frame
        this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    public void Position()
    {
        // if gameobject position is the currPosition, set it to newPosition
        if (this.gameObject.transform.position == currPosition)
        {
            this.gameObject.transform.position = newPosition;
        }

        // otherwise or else if gameobject position is the currPosition, set it to newPosition
        else if (this.gameObject.transform.position == newPosition)
        {
            this.gameObject.transform.position = currPosition;
        }

        // if neither of the if statements are true, then create a new Vector3 position
        else
        {
            this.gameObject.transform.position = new Vector3(1f, 2f, 2f); //use new Vector3 to establish new x,y,z positions
        }
    }
}