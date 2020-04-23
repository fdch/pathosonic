using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDN_ChangeTexture : MonoBehaviour {

    private Renderer objectRenderer;
    public Material[] objectMaterials;

    // Use this for initialization
    void Start()
    {
        if (objectRenderer == null)
        {
            objectRenderer = this.gameObject.GetComponent<Renderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void textureOne()
    {
        objectRenderer.material = objectMaterials[0];
    }

    public void textureTwo()
    {
        objectRenderer.material = objectMaterials[1];
    }
}
