﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;


public class GDN_Interaction : MonoBehaviour {



    [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click.
    [SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
    [SerializeField] private GDN_Transformations transformations;

    private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.
    private bool isRotating;


    // Use this for initialization
    private void Start()
    {
        m_GazeOver = false;
        isRotating = false;
    }

    // Update is called once per frame
    private void Update()
    {
        Loop();
    }

    //Initiate when gameobject is active
    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_InteractiveItem.OnUp += HandleUp;
        m_InteractiveItem.OnDown += HandleDown;
        m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
    }

    //Initiate when gameobject is inactive
    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_InteractiveItem.OnUp -= HandleUp;
        m_InteractiveItem.OnDown -= HandleDown;
        m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
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

    // Initiate when the controller trigger is pressed
    void HandleDown()
    {
        m_SelectionRadial.Show();
    }

    // Initiate when the controller trigger is released
    void HandleUp()
    {
        //If the Trigger is released ..Do This
    }

    // Initiate when the controller trigger is doubleclicked
    private void HandleDoubleClick()
    {
        isRotating = true;
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
        //Once the Radial fills.. Do this


    }

    private void Loop()
    {
        if (isRotating)
        {
            transformations.Rotating();

        }
    }
}