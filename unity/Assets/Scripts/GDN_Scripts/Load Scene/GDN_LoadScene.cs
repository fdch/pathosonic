using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;
using UnityEngine;

public class GDN_LoadScene : MonoBehaviour

{
    [SerializeField] private VRCameraFade m_CameraFade;                 // Reference to the script that fades the scene to black.
    [SerializeField] private string SceneToLoad;                     // The name of the scene to load.




    public IEnumerator LoadNewScene()                                   // Function must be public to access from another script
    {
        Debug.Log("loading scene");

        // If the camera is already fading, ignore.
        if (m_CameraFade.IsFading)
            yield break;

        // Wait for the camera to fade out.
        yield return StartCoroutine(m_CameraFade.BeginFadeOut(true));

        // Load the level.
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);

    }
}