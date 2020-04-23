/* <copyright file="PDTest.cs" company="Playdots, Inc.">
 * Copyright (C) 2017 Playdots, Inc.
 * </copyright>
 * ----------------------------
 */
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class PDTest : MonoBehaviour {



    public string patchName;
    private int _dollarZero = -1;

    
    IEnumerator Start()
    {
        print("Waiting 1 second to initialize libpd plugin...");
        yield return new WaitForSeconds (1f);
        print("...done. Initializing...");

        UnityPD.Init ();
        
        print("Waiting 2 seconds to open audio patch...");
        yield return new WaitForSeconds (2f);
        print("...done. Opening Audio patch...");

        _dollarZero = UnityPD.OpenPatch(patchName);


        print("...done.");
        print("Waiting 5 seconds to record audio...");
        yield return new WaitForSeconds(5f);
        print("...done");
        print("Recording Audio...");

        UnityPD.SendFloat("record", 1f);


    }

    private void Update()
    {


    }

    void OnApplicationQuit()
    {
        print("Closing Recording...");
        UnityPD.SendFloat("record", 0f);
        print("Closing Patch...");
        UnityPD.ClosePatch(_dollarZero);
        print("DeInitializing libpd plugin...");
        UnityPD.Deinit ();
    }

}
