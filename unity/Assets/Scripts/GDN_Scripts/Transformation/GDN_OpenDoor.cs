using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;


public class GDN_OpenDoor : MonoBehaviour
{



    [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click.
    [SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.

    Animator door;
    public bool isOpen;

    private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.


    // Use this for initialization
    private void Start()
    {
        m_GazeOver = false;
        door = GetComponent<Animator>();
        isOpen = false;
    }

    // Update is called once per frame
    private void Update()
    {
        DoorOpen();
        DoorClose();
    }

    //Initiate when gameobject is active
    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
    }

    //Initiate when gameobject is inactive
    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
    }

    // Initiate when pointer enters gameobject
    void HandleOver()
    {

        m_SelectionRadial.Show();
        m_GazeOver = true;
    }

    // Initiate when pointer exits gameobject
    void HandleOut()
    {

        m_SelectionRadial.Hide();
        m_GazeOver = false;
    }
    // If the user is looking at the rendering of the scene when the radial's selection finishes, activate functions.
    private void HandleSelectionComplete()
    {
        if (m_GazeOver)
        {

            RadialFilledComplete(); //Reference RadialFilledComplete function below
        }
    }


    // Initiate when gaze is over object and radial fills up
    private void RadialFilledComplete()
    {

        isOpen =! isOpen;

    }

    private void DoorOpen()
    {
        if (isOpen == false)
            door.SetBool("open", false);
    }

    private void DoorClose()
    {
        if (isOpen == true)
            door.SetBool("open", true);
    }


}