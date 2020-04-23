using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class GDN_Grabber : MonoBehaviour {

    [SerializeField] private GDN_Grabbable Grabbable;
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private SelectionRadial m_SelectionRadial;

    private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.

    private void Start()
    {
        m_GazeOver = false;
    }

    private void Update()
    {
    }

    //Initiate when gameobject is active
    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_InteractiveItem.OnUp += HandleUp;
        m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;

    }

    //Initiate when gameobject is inactive
    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOver -= HandleOut;
        m_InteractiveItem.OnUp -= HandleUp;
        m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
    }

    private void HandleOver()
    {
        m_SelectionRadial.Show();
        m_GazeOver = true;

    }

    private void HandleOut()
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

    private void RadialFilledComplete()
    {
        Grabbable.PickUp();
    }

    private void HandleUp()
    {
        Grabbable.PutDown();

    }


}
