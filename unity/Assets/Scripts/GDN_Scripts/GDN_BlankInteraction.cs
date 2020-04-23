using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class GDN_BlankInteraction : MonoBehaviour
{
    //Reference the VRInteractiveItem Class
    [SerializeField] private VRInteractiveItem m_InteractiveItem;

    //Initiate when gameobject is active
    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_InteractiveItem.OnUp += HandleUp;
        m_InteractiveItem.OnDown += HandleDown;
        m_InteractiveItem.OnClick += HandleClick;
        m_InteractiveItem.OnDoubleClick += HandleDoubleClick;

    }

    //Initiate when gameobject is inactive
    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_InteractiveItem.OnUp -= HandleUp;
        m_InteractiveItem.OnDown -= HandleDown;
        m_InteractiveItem.OnClick -= HandleClick;
        m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
    }

    // Called when the gaze moves over this object
    private void HandleOver()
    {

    }

    // Called when the gaze leaves this object
    private void HandleOut()
    {
       
    }

    // Called when click input is detected whilst the gaze is over this object.
    private void HandleUp()
    {

    }

    // Called when double click input is detected whilst the gaze is over this object.
    private void HandleDown()
    {

    }

    // Called when Fire1 is released whilst the gaze is over this object.
    private void HandleClick()
    {

    }

    // Called when Fire1 is pressed whilst the gaze is over this object.
    private void HandleDoubleClick()
    {

    }
}

