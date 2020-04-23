using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spherePos : MonoBehaviour
{

    public Transform soundParticle;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(soundParticle, new Vector3(i * 2.0F, i * 2.0F, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
