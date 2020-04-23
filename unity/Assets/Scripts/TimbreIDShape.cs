using System.Linq;
using UnityEngine;

public class TimbreIDShape : MonoBehaviour
{

    #region Variables

    public TextAsset textFile, featText;            // drop your file here in inspector
    public string[] lines = { }, feats= { };       // the array holding each line of text, and each feature
    public int Xplot, Yplot, Zplot, triRes;         // the user-defined choice for each axis
    public int Rplot, Gplot, Bplot, Aplot;          // the user-defined choice for each color
    public int pRplot, pGplot, pBplot, pAplot;      // 
    public int pXplot, pYplot, pZplot, ptriRes;    // so that we dont update on unnecessary plots
    private int plotSize;
    private GameObject[] o_O;                       // the empty objects for proximity triggering
    public GameObject sndFrame;                     // the prefab sphere to plot as each frame
    public float scale;                             // optional scale
    private float pscale;                           // same here
    public float xof,yof,zof;                       // apply some offsets

    public Material gM;
    private Mesh mesh;
    private Vector3[] vertices;     
    private int[] triangles;


    #endregion


    #region Start

    void Start()
    {
        Xplot = 1;
        Yplot = 2;
        Zplot = 3;
        Rplot = 4;
        Gplot = 5;
        Bplot = 6;
        Aplot = 7;
        scale = 2f;
        triRes = 3;
        yof = -2.8f;
        xof = 7.5f;
        zof = -1.5f;
        // read the lines of the text into a private array of strings
        lines = textFile.text.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        feats = featText.text.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        plotSize = (lines[0].Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries)).Length;
        // Initialize object's mesh filter, renderer, and place a new mesh that we can edit afterwards

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<LineRenderer>();
        gameObject.AddComponent<MeshRenderer>();
        var lr = gameObject.GetComponent<LineRenderer>();
        var mf = gameObject.GetComponent<MeshFilter>();
        var mr = gameObject.GetComponent<MeshRenderer>();
        mesh = new Mesh();
        mf.mesh = mesh;
        mr.material = lr.material = gM;
        lr.widthMultiplier = scale / 2f;
        lr.positionCount = lines.Length;       
        
        gameObject.transform.position = new Vector3(0,0,0);



        // The last thing Start does is instantiate Prefabas... please dont add anything after!
        InstantiatePrefabs();
    }

    #endregion


    #region Update

    void Update()
    {
        // only update if user changed some value
        if (Xplot != pXplot || Yplot != pYplot ||
            Zplot != pZplot || scale != pscale || triRes != ptriRes || 
            Rplot != pRplot || Gplot != pGplot || Bplot != pBplot || Aplot != pAplot)
        {
            UpdateShape();
            pXplot = Xplot;
            pYplot = Yplot;
            pZplot = Zplot;
            pRplot = Rplot;
            pGplot = Gplot;
            pBplot = Bplot;
            pAplot = Aplot;
        }
    }

    #endregion
    public int UpdateIt(ref int current, ref int prev)
    {
        int temp = prev;
        int curr = (temp + 1) % plotSize;
        current = curr;
        UnityPD.SendBang("test_bang");
        prev = curr;
        return curr;
    }

    public float[] GetValues(int i)
    {
        float[] vals = new float[8];
        // split the line (v) in fields using a space as separator
        string[] l = lines[i].Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);
        // position
        vals[0]= ((float.Parse(l[Xplot])) - 0.5f ) * 2f;
        vals[1]= ( float.Parse(l[Yplot])) * 1.5f + 0.5f;
        vals[2]= ((float.Parse(l[Zplot])) - 0.5f ) * 2f;
        // color
        vals[3]=   float.Parse(l[Rplot]);
        vals[4]=   float.Parse(l[Gplot]);
        vals[5]=   float.Parse(l[Bplot]);
        vals[6]=   float.Parse(l[Aplot]);
        // ID
        vals[7] =  float.Parse(l[1]);
        
        return vals;
    }

    #region UpdateShape

    void UpdateShape()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        vertices = new Vector3[lines.Length];
        triangles = new int[lines.Length * triRes];

        for (int i = 0; i < lines.Length; i++)
        {
            float[] vals = GetValues(i);
            vertices[i] = new Vector3(vals[0], vals[1], vals[2]);
           

            // make each triangle and wrap around the last 'triRes' points...
            for (int j = 0; j < triRes; j++)
            {
                triangles[i * triRes + j] = (i + j) % lines.Length;
            }
            o_O[i].transform.position = vertices[i];
            DistanceTrigger cpm = (DistanceTrigger)o_O[i].GetComponent(typeof (DistanceTrigger));
            cpm.UpdatePosition();
            cpm.UpdateColor(new Color(vals[3], vals[4], vals[5], vals[6]));
        }
        lr.SetPositions(vertices);
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();
    }

    #endregion


    #region InstantiatePrefabs
    void InstantiatePrefabs()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        
        o_O = new GameObject[lines.Length];
        vertices = new Vector3[lines.Length];
        triangles = new int[lines.Length * triRes];

        for (int i = 0; i < lines.Length; i++)
        {
            float[] vals = GetValues(i);
            vertices[i] = new Vector3(vals[0], vals[1], vals[2]);
            // make each triangle and wrap around the last 'triRes' points...
            for (int j = 0; j < triRes; j++)
            {
                triangles[i * triRes + j] = (i + j) % lines.Length;
            }
            
            o_O[i] = Instantiate(sndFrame, vertices[i], Quaternion.identity);
            DistanceTrigger cpm = (DistanceTrigger)o_O[i].GetComponent(typeof (DistanceTrigger));
            cpm.UpdateColor(new Color(vals[3], vals[4], vals[5], vals[6]));
            cpm.SetId(vals[7], i);


        }
        lr.SetPositions(vertices);
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();
    }

    #endregion

}
