using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimbreID2dPlane : MonoBehaviour
{
    public TextAsset textFile;        // drop your file here in inspector
    private string[] lines = { };    // the array holding each line of text
    public int Xplot, Yplot, Zplot, triRes; // the user-defined choice for each axis
    private int pXplot, pYplot, pZplot, ptriRes; // so that we dont update on unnecessary plots
    public float scale;
    private float pscale; // same here
    Mesh mesh;
    private Vector3[] vertices;
    // Start is called before the first frame update
    void Start()
    {
        Xplot = 2;
        Yplot = 3;
        Zplot = 4;
        scale = 2.0f;
        triRes = 3;
        // read the lines of the text into a private array of strings
        lines = textFile.text.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        var meshShader = gameObject.GetComponent<Renderer>().material.shader;
        Debug.Log(meshShader);

    }

    // Update is called once per frame
    void Update()
    {

        // only update if user changed some value
        if (Xplot != pXplot || Yplot != pYplot || Zplot != pZplot || scale != pscale || triRes != ptriRes)
        {
            MakeShape();
            pXplot = Xplot;
            pYplot = Yplot;
            pZplot = Zplot;
        }
    }
    void MakeShape()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            // split the line (v) in fields using a space as separator
            string[] l = lines[i].Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);
            // position

            vertices[i].x = float.Parse(l[Xplot]) * scale;
            vertices[i].y = float.Parse(l[Yplot]) * scale;
            vertices[i].z = float.Parse(l[Zplot]) * scale;



        }
        
        mesh.vertices = vertices;

       mesh.RecalculateBounds();
    }
}
