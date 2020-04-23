using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDN_Timer : MonoBehaviour {

    public GameObject showMe;
    public float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time >= time)
        {
            showMe.SetActive(true);
        }
    }
}
