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

    
    IEnumerator Start() {
        yield return new WaitForSeconds (1f);

        UnityPD.Init ();
        yield return new WaitForSeconds (2f);
        _dollarZero = UnityPD.OpenPatch(patchName);

    }

    private void Update()
    {


    }

    void OnApplicationQuit() {
        UnityPD.ClosePatch(_dollarZero);
        UnityPD.Deinit ();
    }

}
