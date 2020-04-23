using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class GDN_PlaySound : MonoBehaviour
{
    [SerializeField] private VRInteractiveItem m_InteractiveItem;

    //Audio
    [SerializeField] private AudioSource e_AudioSource;
    [SerializeField] private AudioClip e_OnOverClip;
    [SerializeField] private AudioClip e_OnSelctClip;

    private void Start()
    {
    }
    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnUp += HandleUp;
    }

    //Initiate when gameobject is inactive
    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnUp -= HandleUp;
    }

    private void HandleOver()
    {
        e_AudioSource.clip = e_OnOverClip;
        e_AudioSource.Play();
    }

    private void HandleUp()
    {
        e_AudioSource.clip = e_OnSelctClip;
        e_AudioSource.Play();
    }
}
