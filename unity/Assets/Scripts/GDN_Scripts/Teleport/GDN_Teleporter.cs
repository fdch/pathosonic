using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;


public class GDN_Teleporter : MonoBehaviour {


    [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click.
    [SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
    [SerializeField] private GDN_Teleport teleport;                      // This calls functions within the teleportCamera script.

    private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.




    // Use this for initialization
    private void Start()
    {
        m_GazeOver = false;

    }

    // Update is called once per frame
    private void Update()
    {
        Gazing();
    }

    //Initiate when gameobject is active
    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_InteractiveItem.OnUp += HandleUp;
    }

    //Initiate when gameobject is inactive
    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_InteractiveItem.OnUp -= HandleUp;
    }

    // Initiate when pointer enters gameobject
    void HandleOver()
    {
        m_SelectionRadial.Show();
        m_GazeOver = true;
        teleport.FeetUI();
    }

    // Initiate when pointer exits gameobject
    void HandleOut()
    {
        m_SelectionRadial.Hide();
        m_GazeOver = false;
        teleport.ResetUI();
    }
    // Initiate when gaze is over object and radial fills up
    private void HandleUp()
    {
       
        teleport.changeLocation();
    }


    void Gazing()
    {
        if (m_GazeOver)
        {
            teleport.RotateReticle();
        }
        else
            return;
    }


}