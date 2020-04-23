using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Animator door;
    bool isOpened = false;
    float dist;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<Animator>();
      
    }

    //if the tag player collides with door, seet isOpen bool to true
    //private void OnTriggerEnter(Collider other)
    //{
        //if (other.tag == "Player")
        //{ 
        //isOpened = true;
        //}
    //}

    //if the tag player collides with door, seet isOpen bool to false
    //private void OnTriggerExit(Collider other)
    //{
        //if (other.tag == "Player")
        //{
        //isOpened = false;
        //}
    //}

    // Update is called once per frame
    // open door if player enter trigger and close door if
    // if player exit trigger and distance is greater 3f
    void Update()
    {
        if (dist <= 2f)
        {
            door.SetBool("open", true);
        }
       else if (dist >= 2f)
        {
            door.SetBool("open", false);
        }

        //call distance function
        Distance();
    }

    //measure distance player and door
    void Distance()
    {
        if (player)
        {
             dist = Vector3.Distance(player.position, transform.position);
        }
    }
}
