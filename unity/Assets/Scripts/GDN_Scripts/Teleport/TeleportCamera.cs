using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCamera : MonoBehaviour {

    // Target Object
    public GameObject Player;

    // Target To
    public GameObject LivingPresepctive;
    public GameObject DiningbPrespective;
    public GameObject KitchenPrespective;
    public GameObject OfficePosition;
    public GameObject UpStairsPresepctive;
    public GameObject PopeRoomPrespective;
    public GameObject DaughtersRoomPrespective;
    public GameObject BalconyPosition;
    public GameObject StartingPosition;

    //Bool
    private bool Living;
    private bool Dining;
    private bool Kitchen;
    private bool Office;
    private bool Upstairs;
    private bool PopeRoom;
    private bool DaughterRoom;
    private bool Balcony;
    private bool Starting;

    float currentpos;

    void Start()
    {
        Living = true;
        Dining = false;
        Kitchen = false;
        Office = false;
        Upstairs = false;
        PopeRoom = false;
        DaughterRoom = false;
        Balcony = false;
        Starting = false;

        currentpos = Player.transform.position.y;
    }

        void Update()
    {
        moveAround();
    }

private void moveAround()
    {

        if (OVRInput.GetUp(OVRInput.Button.One) && Living == true)
        {
            Player.gameObject.transform.position = new Vector3(LivingPresepctive.transform.position.x, currentpos, LivingPresepctive.transform.position.z);
            Living = false;
            Dining = true;
        }

        else if (OVRInput.GetUp(OVRInput.Button.One) && Dining == true)
        {
            Player.gameObject.transform.position = new Vector3(DiningbPrespective.transform.position.x, currentpos, DiningbPrespective.transform.position.z);
            Living = false;
            Dining = false;
            Kitchen = true;
        }

        else if (OVRInput.GetUp(OVRInput.Button.One) && Kitchen == true)
        {
            Player.gameObject.transform.position = new Vector3(KitchenPrespective.transform.position.x, currentpos, KitchenPrespective.transform.position.z);
            Living = false;
            Dining = false;
            Kitchen = false;
            Office = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.One) && Office == true)
        {
            Player.gameObject.transform.position = new Vector3(OfficePosition.transform.position.x, currentpos, OfficePosition.transform.position.z);
            Living = false;
            Dining = false;
            Kitchen = false;
            Office = false;
            Upstairs = true;
        }

        else if (OVRInput.GetUp(OVRInput.Button.One) && Upstairs == true)
        {
            Player.gameObject.transform.position = new Vector3(UpStairsPresepctive.transform.position.x, currentpos + UpStairsPresepctive.transform.position.y, UpStairsPresepctive.transform.position.z);
            Living = false;
            Dining = false;
            Kitchen = false;
            Office = false;
            Upstairs = false;
            PopeRoom = true;
        }

        else if (OVRInput.GetUp(OVRInput.Button.One) && PopeRoom == true)
        {
            Player.gameObject.transform.position = new Vector3(PopeRoomPrespective.transform.position.x, currentpos + PopeRoomPrespective.transform.position.y, PopeRoomPrespective.transform.position.z);
            Living = false;
            Dining = false;
            Kitchen = false;
            Office = false;
            Upstairs = false;
            PopeRoom = false;
            DaughterRoom = true;
        }

        else if (OVRInput.GetUp(OVRInput.Button.One) && DaughterRoom == true)
        {
            Player.gameObject.transform.position = new Vector3(DaughtersRoomPrespective.transform.position.x, currentpos + DaughtersRoomPrespective.transform.position.y, DaughtersRoomPrespective.transform.position.z);
            Living = false;
            Dining = false;
            Kitchen = false;
            Office = false;
            Upstairs = false;
            PopeRoom = false;
            DaughterRoom = false;
            Balcony = true;
        }

        else if (OVRInput.GetUp(OVRInput.Button.One) && Balcony == true)
        {
            Player.gameObject.transform.position = new Vector3(BalconyPosition.transform.position.x, currentpos + BalconyPosition.transform.position.y, BalconyPosition.transform.position.z);
            Living = false;
            Dining = false;
            Kitchen = false;
            Office = false;
            Upstairs = false;
            PopeRoom = false;
            DaughterRoom = false;
            Balcony = false;
            Starting = true;
        }

        else if (OVRInput.GetUp(OVRInput.Button.One) && Starting == true)
        {
            Player.gameObject.transform.position = new Vector3(StartingPosition.transform.position.x, currentpos, StartingPosition.transform.position.z);
            Living = true;
            Dining = false;
            Kitchen = false;
            Office = false;
            Upstairs = false;
            PopeRoom = false;
            DaughterRoom = false;
            Balcony = false;
            Starting = false;
        }

    }

}
